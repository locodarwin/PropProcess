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
            Status("Opening the file dialog.");
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Place the filename into the text box
                    texFileIn.Text = openFileDialog1.FileName;
                    Status("Filepath: '" + texFileIn.Text + "' was selected.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void butProcess_Click(object sender, EventArgs e)
        {
            // Check to see if the file textbox contains a usable file, abort if not
            string sFile = texFileIn.Text;
            if (!File.Exists(sFile))
            {
                Status("The file doesn't exist.");
                return;
            }

            // Begin processing

            // What you should do is read each line from the file and process as you go
            // Do things like, keep a tab of unique citnums and how many objects they created
            // Get number of unique objects and how many of each is used

            // Remember that the first line in a propdump file is a version string.
            // This is useful for determining if the file is indeed a propdump.

            // Read the citnum from the citnum textbox
            string sCitnum = texCitnum.Text;


            // Get the number of lines in the file
            var lineCount = File.ReadAllLines(sFile).Length;
            Status("There are " + lineCount + " lines in the file you chose.");

            // variables for the iteration
            int counter = 0;
            string line;

            // Iteration
            System.IO.StreamReader file = new System.IO.StreamReader(sFile);

            while((line = file.ReadLine()) != null)
            {

                // Get the citnum of the line
                //Status(ReturnCitnum(line));

                if (ReturnCitnum(line) == sCitnum)
                {
                    using (System.IO.StreamWriter outfile = new System.IO.StreamWriter(@"C:\Users\Shawn\Desktop\citnumlog.txt", true))
                    {
                        outfile.WriteLine(line);
                    }
                }


                counter++;
            }
            file.Close();

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
