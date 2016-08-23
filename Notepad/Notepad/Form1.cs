using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Text;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        TextBox rtb;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private TextBox GetRichTextBox()
        {
            rtb = null; //making it initially null
            TabPage tp = tabControl1.SelectedTab; // saves the tab selection status in a tabpage type variable
            if(tp!=null)
            {
                rtb = tp.Controls[0] as TextBox; //sets the selected rich text box index as primary
            }
            return rtb;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document"); //creates a new tab page
            rtb = new TextBox(); //creates a new richtext box object
            rtb.Multiline = true;
            rtb.Font = new Font("Khmer OS System", 12);
            rtb.MaxLength = 0;
            rtb.Dock = DockStyle.Fill; //docks rich text box 
            tp.Controls.Add(rtb); // adds rich text box to the tab page
            tabControl1.TabPages.Add(tp); //adds the tab pages to tab control 
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if(openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                if((myStream=openFileDialog1.OpenFile())!=null)
                {
                    string filename = openFileDialog1.FileName;//copies the path of the file into a variable
                    string readfiletext = File.ReadAllText(filename);//reads all the text from the opened file
                    TabPage tp = new TabPage("New Document"); //creates a new tab page
                    rtb = new TextBox(); //creates a new richtext box object
                    rtb.Font= new Font("Khmer OS System",12);
                    rtb.Multiline = true;
                    rtb.MaxLength = 0;
                    rtb.Dock = DockStyle.Fill; //docks rich text box 
                    tp.Controls.Add(rtb); // adds rich text box to the tab page
                    tabControl1.TabPages.Add(tp); //adds the tab pages to tab control
                    rtb.Text = readfiletext;
                }
                
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile=new SaveFileDialog();
            savefile.Filter = "*.txt(textfile)|*.txt";
            if(savefile.ShowDialog()==DialogResult.OK)
            {
              //rtb.SaveFile(savefile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage("New Document"); //creates a new tab page
            rtb = new TextBox(); //creates a new richtext box object
            rtb.Multiline = true;
            rtb.Font = new Font("Khmer OS System", 12);
            rtb.MaxLength = 0;
            rtb.Dock = DockStyle.Fill; //docks rich text box 
            tp.Controls.Add(rtb); // adds rich text box to the tab page
            tabControl1.TabPages.Add(tp); //adds the tab pages to tab control 
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var tmp = GetRichTextBox();
            tmp.Text = tmp.Text.Replace("​", string.Empty);
        }
    }
}
