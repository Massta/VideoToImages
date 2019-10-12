using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace VideoToImages
{
    public partial class Form1 : Form
    {
        public bool IsValidFile { get; set; } = false;
        public Form1()
        {
            InitializeComponent();
            UpdateVideoInfo();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = openFileDialog1.FileName;
                textBox1.Text = sSelectedPath;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateVideoInfo();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = folderBrowserDialog1.SelectedPath;
                textBox2.Text = sSelectedPath;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!IsValidFile)
            {
                return;
            }
            var filePath = textBox1.Text;
            var targetPath = textBox2.Text;

            double startValue = 0;
            if (double.TryParse(TextBoxStart.Text, out double startResult))
            {
                startValue = startResult;
            }
            double? stopValue = null;
            if (double.TryParse(TextBoxEnd.Text, out double stopResult))
            {
                stopValue = stopResult;
            }
            double stepValue = 1;
            if (double.TryParse(TextBoxStep.Text, out double stepResult))
            {
                stepValue = stepResult;
            }
            button2.Text = "Working...";
            button2.Enabled = false;
            CaptureFrames(filePath, targetPath, startValue, stopValue, stepValue);
            button2.Text = "Generate images";
            button2.Enabled = true;
        }

        private void TextBoxStart_TextChanged(object sender, EventArgs e)
        {
            UpdateVideoInfo();
        }

        private void TextBoxEnd_TextChanged(object sender, EventArgs e)
        {
            UpdateVideoInfo();
        }

        private void TextBoxStep_TextChanged(object sender, EventArgs e)
        {
            UpdateVideoInfo();
        }

        public void UpdateVideoInfo()
        {
            var filePath = textBox1.Text;
            if (!File.Exists(filePath))
            {
                LabelIsMp4.Text = "-";
                LabelResolution.Text = "-";
                LabelDuration.Text = "-";
                TextBoxEnd.Text = null;
                LabelImageAmount.Text = "The chosen setup will generate - images";
                return;
            }

            var fi = new FileInfo(filePath);
            if (fi.Extension.ToLower() != ".mp4")
            {
                LabelIsMp4.Text = "-";
                LabelResolution.Text = "-";
                LabelDuration.Text = "-";
                TextBoxEnd.Text = null;
                LabelImageAmount.Text = "The chosen setup will generate - images";
                return;
            }
            LabelIsMp4.Text = "+";

            using (var engine = new Engine())
            {
                var mp4 = new MediaFile { Filename = filePath };
                engine.GetMetadata(mp4);
                LabelResolution.Text = mp4.Metadata.VideoData.FrameSize + "@" + mp4.Metadata.VideoData.Fps + " fps";
                LabelDuration.Text = mp4.Metadata.Duration.TotalSeconds + "s";
                TextBoxEnd.Text = mp4.Metadata.Duration.TotalSeconds.ToString();
                LabelImageAmount.Text = $"The chosen setup will generate {GetImageAmount()} images";
            }

            textBox2.Text = Path.Combine(fi.DirectoryName, Path.GetFileNameWithoutExtension(filePath));
            folderBrowserDialog1.SelectedPath = textBox2.Text;
            IsValidFile = true;
        }

        public int? GetImageAmount()
        {
            var start = TextBoxStart.Text.ToDouble();
            var end = TextBoxEnd.Text.ToDouble();
            var step = TextBoxStep.Text.ToDouble();
            if (start == null || end == null || step == null)
            {
                return null;
            }
            return (int)Math.Floor((end.Value - start.Value) / step.Value);
        }

        public void CaptureFrames(string filePath, string destinationPath, double startIndex = 0, double? stopIndex = null, double stepSize = 1)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            using (var engine = new Engine())
            {
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                var mp4 = new MediaFile { Filename = filePath };
                engine.GetMetadata(mp4);
                if (stopIndex == null || stopIndex == 0 || stopIndex > mp4.Metadata.Duration.TotalSeconds)
                {
                    stopIndex = mp4.Metadata.Duration.TotalSeconds;
                }

                stepSize = Math.Max(stepSize, 0.1d);

                for (int i = 0; startIndex < stopIndex; startIndex += stepSize, i++)
                {
                    var options = new ConversionOptions
                    {
                        Seek = TimeSpan.FromSeconds(startIndex)
                    };
                    var outputFile = new MediaFile
                    {
                        Filename = Path.Combine(destinationPath, $"{fileName}-{i}.jpg")
                    };
                    engine.GetThumbnail(mp4, outputFile, options);
                }
            }
        }

        private async void Button4_ClickAsync(object sender, EventArgs e)
        {
            var links = textBox3.Lines;
            if (links == null || !links.Any())
            {
                return;
            }
            var firstLink = links[0];
            var linkParts = firstLink.Split("?v=".ToCharArray());
            if (linkParts.Length < 2)
            {
                return;
            }
            var ytId = linkParts[3];

            var client = new YoutubeClient();
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(ytId);
            var selectedStreamInfo = comboBox1.SelectedText;
            var streamInfo = streamInfoSet.Video
               .Where(s => s.Container == YoutubeExplode.Models.MediaStreams.Container.Mp4)
               .Where(s => $"{s.Resolution.Height.ToString()}p {s.Framerate} fps" == selectedStreamInfo)
               .FirstOrDefault();
            if (streamInfo == null)
            {
                return;
            }

            // Get file extension based on stream's container
            var ext = streamInfo.Container.GetFileExtension();

            // Download stream to file
            Progress<double> testProgress = new Progress<double>(HasProgress);
            await client.DownloadMediaStreamAsync(streamInfo, ytId + ext, progress: testProgress);
        }

        public void HasProgress(double input)
        {
            label10.Text = input.ToString();
        }

        private async void TextBox3_TextChangedAsync(object sender, EventArgs e)
        {
            var links = textBox3.Lines;
            if (links == null || !links.Any())
            {
                return;
            }
            var firstLink = links[0];
            var linkParts = firstLink.Split("?v=".ToCharArray());
            if (linkParts.Length < 2)
            {
                return;
            }
            var ytId = linkParts[3];

            var client = new YoutubeClient();
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(ytId);
            if (streamInfoSet == null)
            {
                return;
            }
            comboBox1.Items.AddRange(streamInfoSet.Video
                .Where(v => v.Container == YoutubeExplode.Models.MediaStreams.Container.Mp4)
                .Select(v => $"{v.Resolution.Height.ToString()}p {v.Framerate} fps").ToArray());
            comboBox1.SelectedIndex = 0;
        }
    }
}
