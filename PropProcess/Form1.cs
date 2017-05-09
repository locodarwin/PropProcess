using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.ComponentModel;

namespace PropProcess
{

    public partial class Form1 : Form
    {

        private readonly BackgroundWorker worker;

        public Form1()
        {
            InitializeComponent();


            // Create the background worker object, enable it to report progress,
            // And then assign the mrhods that are called to do the work, handle the progress updates,
            // And provide tasks that run when the background worker completes.
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Process;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Status("Opening the folder dialog.");
            FolderBrowserDialog openDir = new FolderBrowserDialog();
            openDir.RootFolder = Environment.SpecialFolder.Desktop;
            
            if (openDir.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Place the dir into the text box
                    texDir.Text = openDir.SelectedPath;
                    Status("Directory: '" + texDir.Text + "' was selected.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read directory from disk. Original error: " + ex.Message);
                }
            }
        }

        private void butProcess_Click(object sender, EventArgs e)
        {

            worker.RunWorkerAsync();
            butProcess.Enabled = false;

        }

        private void Process(object sender, DoWorkEventArgs e)
        {

            // Assign
            BackgroundWorker bgWorker = (BackgroundWorker)sender;

            string line;

            // Get all files from the specified dir
            string sDir = texDir.Text;
            string[] sFiles = Directory.GetFiles(sDir);

            // Read the citnum from the citnum textbox
            string sCitnum = texCitnum.Text;

            // Open the output file for writing
            System.IO.StreamWriter outfile = new System.IO.StreamWriter(sDir + "\\output.txt", true);

            bgWorker.ReportProgress(0, "Processing...");

            // Begin processing all files
            foreach (string sFile in sFiles)
            {

                bgWorker.ReportProgress(0, "Reading file: " + sFile);

                // Iteration
                System.IO.StreamReader file = new System.IO.StreamReader(sFile);

                while ((line = file.ReadLine()) != null)
                {

                    // Get the citnum of the line

                    if (ReturnCitnum(line) == sCitnum)
                    {
                        outfile.WriteLine(line);
                    }

                }
                file.Close();

            }
            outfile.Close();

        }

        private string ReturnCitnum(string sLine)
        {
            string[] sWords = Regex.Split(sLine, " ");
            return sWords[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Status("Ready to begin.");
        }


        //public static class Globals
        //{
        //    public static string sTest = "This is a string";
        //}

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            butProcess.Enabled = true;
        }

        private void Status(string sStatusText)
        {
            lisStatus.Items.Add(sStatusText);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            lisStatus.Items.Add(e.UserState.ToString());
        }

        // Convert Unix timestamp to Windows DateTime
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        /* Understanding different versions of propdump files
         * 
         * Propdump v5: http://wiki.activeworlds.com/index.php?title=Propdump
         * 
         * Propdump v3: http://www.aw-europe.com/help/aw36/admin_propdump.html
         * 
         * Was there a propdump v4? According to propdump tool by Andras, there was.
         


        */


    }


}
