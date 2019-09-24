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
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sSelectedPath = openFileDialog1.FileName;
                textBox1.Text = sSelectedPath;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var filePath = textBox1.Text;
            var fi = new FileInfo(filePath);
            var folderPath = fi.DirectoryName;
            CaptureFrames(filePath, Path.Combine(folderPath, Path.GetFileNameWithoutExtension(filePath)));
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
                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(startIndex) };
                    var outputFile = new MediaFile { Filename = Path.Combine(destinationPath, $"{fileName}-{i}.jpg") };
                    engine.GetThumbnail(mp4, outputFile, options);
                }
            }
        }
    }
}
