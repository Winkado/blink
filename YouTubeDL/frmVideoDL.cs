using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;
using MediaToolkit;

namespace YouTubeDL
{
    public partial class frmVideoDL : Form
    {
        public frmVideoDL()
        {
            InitializeComponent();
        }

        Boolean format = true;
        //T--> MP3 F-->MP4

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Please select Download Directory" })
            {
                if(fbd.ShowDialog()==DialogResult.OK)
                {
                    MessageBox.Show("Download Started! Please be patient.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var yt = YouTube.Default;
                    var video = await yt.GetVideoAsync(url.Text);
                    File.WriteAllBytes(fbd.SelectedPath + @"\" + video.FullName, await video.GetBytesAsync());

                    var inputfile = new MediaToolkit.Model.MediaFile { Filename = fbd.SelectedPath + @"\" + video.FullName};
                    var outputfile = new MediaToolkit.Model.MediaFile { Filename = $"{fbd.SelectedPath + @"\" + video.FullName}.mp3"};

                    using (var engine = new Engine())
                    {
                        engine.GetMetadata(inputfile);
                        engine.Convert(inputfile, outputfile);
                    }

                    if (format == true)
                    {
                        File.Delete(fbd.SelectedPath + @"\" + video.FullName);
                    }

                    else
                    {
                        File.Delete($"{fbd.SelectedPath + @"\" + video.FullName}.mp3");
                    }

                    progressBar1.Value = 100;

                    MessageBox.Show("Download Complete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No Directory Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void mp3_TextChanged(object sender, EventArgs e)
        {
            format = true;
        }

        private void mp4_TextChanged(object sender, EventArgs e)
        {
            format = false;
        }
    }
}
