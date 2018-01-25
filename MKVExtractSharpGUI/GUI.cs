using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MKVExtractSharpGUI
{
    public partial class MkvExtractSharpGUI : Form
    {
        private Process mkvextract;
        private Process mkvmerge;
        static String _ = " ";

        /// <summary>
        /// if showIO is set to true,
        /// show a MessageBox every time before/after
        /// executing a mkvtoolnix program.
        /// </summary>
        private bool showIO;

        public MkvExtractSharpGUI()
        {
            InitializeComponent();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            if (!(File.Exists("mkvextract.exe") && File.Exists("mkvmerge.exe")))
            {
                MessageBox.Show("Please put this application in the MKVToolNix working directory","Error");
                this.Close();
            }

            showIO = false;
            ShowOutputsCheckBox.Checked = false;

            mkvextract = new Process();
            mkvextract.StartInfo.FileName = "mkvextract.exe";
            mkvextract.StartInfo.RedirectStandardInput = true;
            mkvextract.StartInfo.RedirectStandardOutput = true;
            mkvextract.StartInfo.CreateNoWindow = true;
            mkvextract.StartInfo.UseShellExecute = false;

            mkvmerge = new Process();
            mkvmerge.StartInfo.FileName = "mkvmerge.exe";
            mkvmerge.StartInfo.RedirectStandardInput = true;
            mkvmerge.StartInfo.RedirectStandardOutput = true;
            mkvmerge.StartInfo.CreateNoWindow = true;
            mkvmerge.StartInfo.UseShellExecute = false;
        }

        /// <summary>
        /// Allow users to select a file with a OpenFileDialog.
        /// </summary>
        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Matroska file|*.mkv;*.mka;*.mk3d;*.mks|WebM file|*.webm;*.weba";
            open.Multiselect = false;
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileAddressInput.Text = open.FileName;
            }
        }

        /// <summary>
        /// Allow users to drag & drop a file into the application.
        /// </summary>
        private void MkvExtractSharpGUI_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Handling the dropped file,
        /// write the path of the first file into the input textbox.
        /// </summary>
        private void MkvExtractSharpGUI_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                this.FileAddressInput.Text = files[0];
            }
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            ExtractButton.Enabled = false;
            ExtractOperation();
        }

        private void ShowOutputsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            /// <summary>
            /// if showIO is set to true,
            /// show a MessageBox every time before/after
            /// executing a mkvtoolnix program.
            /// </summary>
            showIO = ShowOutputsCheckBox.Checked;
        }

        private void ExtractOperation()
        {
            String MkvFile = FileAddressInput.Text;
            MkvFile.Replace(@"\", "/");

            if (!File.Exists(MkvFile))
            {
                MessageBox.Show("File does not exist", "Error");
                ExtractButton.Enabled = true;
                return;
            }
            
            String FileNoExtension = MkvFile.Remove(MkvFile.LastIndexOf("."));

            StartExtract(_ + "\"" + MkvFile + "\"" + _ + "tracks" + _ + TrackList(MkvFile, FileNoExtension));
            ExtractButton.Enabled = true;
        }

        /// <summary>
        /// Using mkvmerge to determine all the tracks of the specified file,
        /// and set output paths for each track.
        /// </summary>
        /// <param name="File">the file path</param>
        /// <param name="FileNoExtension">the file path without extension name</param>
        /// <returns></returns>
        private string TrackList(string File, string FileNoExtension)
        {
            string arguments = _ + "\"" + File + "\"" + " -i --ui-language english";
            if (showIO)
                MessageBox.Show(arguments, "Executing mkvmerge with following arguments");
            mkvmerge.StartInfo.Arguments = arguments;
            mkvmerge.Start();
            // Read the output in UTF-8 encoding.
            // proved having problems decoding Chinese
            // (or other languages') characters while not using UTF-8.
            StreamReader reader = new StreamReader(mkvmerge.StandardOutput.BaseStream, Encoding.UTF8);
            string output = reader.ReadToEnd();
            reader.Close();
            mkvmerge.StandardInput.Close();
            mkvmerge.WaitForExit();
            if (showIO)
                MessageBox.Show(output, "mkvmerge output");
            string[] array = output.Split('\n');

            List<string> list = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].StartsWith("Track ID "))
                {
                    string num = array[i].Remove(0, 9);
                    int number = int.Parse(num.Remove(num.IndexOf(":")));
                    string extension = "";
                    if (array[i].Contains("h.264"))
                        extension = ".h264";
                    else if (array[i].Contains("h.265"))
                        extension = ".h265";
                    else if (array[i].Contains("AAC"))
                        extension = ".aac";
                    else if (array[i].Contains("AC3"))
                        extension = ".ac3";
                    else if (array[i].Contains("FLAC"))
                        extension = ".flac";
                    else if (array[i].Contains("Opus"))
                        extension = ".opus";
                    else if (array[i].Contains("MPEG Audio")
                        extension = ".mp3"
                    else if (array[i].Contains("PCM")
                        extension = ".wav"
                    else if (array[i].Contains("VP8"))
                        extension = ".vp8";
                    else if (array[i].Contains("VP9"))
                        extension = ".vp9";
                    else if (array[i].Contains("UTF-8"))
                        extension = ".srt";
                    list.Add(number + ":" + "\"" + FileNoExtension + "_track" + number + extension + "\"");
                }
            }
            string tracks = "";
            for (int i = 0; i < list.Count; i++)
            {
                tracks += _ + list[i] + _;
            }
            return tracks;
        }

        /// <summary>
        /// Using mkvextract to extract the tracks
        /// </summary>
        /// <param name="arguments">arguments that will be given to mkvextract</param>
        private void StartExtract(String arguments)
        {
            if (showIO)
                MessageBox.Show(arguments, "Executing mkvextract with following arguments");
            mkvextract.StartInfo.Arguments = arguments;
            mkvextract.Start();
            if (showIO)
            {
                StreamReader reader = new StreamReader(mkvextract.StandardOutput.BaseStream, Encoding.UTF8);
                string output = reader.ReadToEnd();
                reader.Close();
                MessageBox.Show(output, "mkvextract output");
            }
            mkvextract.StandardInput.Close();
            mkvextract.WaitForExit();
        }
    }
}
