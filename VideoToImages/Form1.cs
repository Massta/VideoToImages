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
            button2.Text = "Working...";
            button2.Enabled = false;
            CaptureFrames(filePath, targetPath, 0, 10);
            button2.Text = "Generate images";
            button2.Enabled = true;
        }

        public void UpdateVideoInfo()
        {
            var filePath = textBox1.Text;
            if (!File.Exists(filePath))
            {
                LabelIsMp4.Text = "-";
                LabelResolution.Text = "-";
                return;
            }

            var fi = new FileInfo(filePath);
            if (fi.Extension.ToLower() != ".mp4")
            {
                LabelIsMp4.Text = "-";
                LabelResolution.Text = "-";
                return;
            }
            LabelIsMp4.Text = "+";

            using (var engine = new Engine())
            {
                var mp4 = new MediaFile { Filename = filePath };
                engine.GetMetadata(mp4);
                LabelResolution.Text = mp4.Metadata.VideoData.FrameSize + "@" + mp4.Metadata.VideoData.Fps + " fps";
            }

            textBox2.Text = Path.Combine(fi.DirectoryName, Path.GetFileNameWithoutExtension(filePath));
            folderBrowserDialog1.SelectedPath = textBox2.Text;
            IsValidFile = true;
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
    }
}
