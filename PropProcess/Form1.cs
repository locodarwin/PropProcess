using System;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace PropProcess
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            int counter = 0;
            string line;
            var lineCount = 0;

            // What you should do is read each line from each file and process as you go
            // Later, do things like, keep a tab of unique citnums and how many objects they created
            // Get number of unique objects and how many of each is used

            // Remember that the first line in a propdump file is a version string.
            // This is useful for determining if the file is indeed a propdump.

            // when done, save, dummy.

            // Get all files from the specified dir
            string sDir = texDir.Text;
            string[] sFiles = Directory.GetFiles(sDir);

            // Read the citnum from the citnum textbox
            string sCitnum = texCitnum.Text;

            // Open the output file for writing
            System.IO.StreamWriter outfile = new System.IO.StreamWriter(sDir + "\\output.txt", true);

            // Begin processing all files
            foreach (string sFile in sFiles)
            {
                // Get the number of lines in the file
                lineCount = File.ReadAllLines(sFile).Length;
                Status("Reading file: " + sFile);
                Status("There are " + lineCount + " lines in the file you chose.");
                                
                // Iteration
                System.IO.StreamReader file = new System.IO.StreamReader(sFile);
             
                while ((line = file.ReadLine()) != null)
                {

                    // Get the citnum of the line
                    //Status(ReturnCitnum(line));

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


        public static class Globals
        {
            public static string sTest = "This is a string";
        }

        private void Status(string sStatusText)
        {
            lisStatus.Items.Add(sStatusText);
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

    class Builders
    {
        public int iCitnum;
        public int iNumobj;
    }
}
