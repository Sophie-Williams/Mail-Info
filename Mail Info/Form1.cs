using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mail_Info.scripts;
using System.IO;

namespace Mail_Info
{
    public partial class MainForm : Form
    {
        OpenFileDialog openFile;

        public MainForm()
        {
            InitializeComponent();

            openFile = new OpenFileDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(openFile.FileName))
            {
                MessageBox.Show("Path not valid: " + openFile.FileName);
                return;
            }

            richTextBox1.Text = string.Empty;

            List<int> fileIndexes = Parser.ParseFile(textBox1.Text);

            for (int i = 0; i < fileIndexes.Count; i++)
            {
                richTextBox1.Text += fileIndexes[i];
                richTextBox1.Text += Environment.NewLine;
            }
        }

        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save Text File";
            saveFileDialog1.Filter = "Text File|*.txt";  
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }
    }
}
