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

namespace PK_02_Notatnik
{
    public partial class Form1 : Form
    {
        private const String MyFilter = "Plik tekstowy|*.txt|Skrypty|*.bat|Wszystkie pliki|*.*";

        private String myFileName = "";
        private Boolean textEdited = false;
        public String MyFileName
        {
            get
            {
                return myFileName;
            }
            set
            {
                myFileName = value;
                SetInfo();
            }
        }

        public bool TextEdited
        { 
            get
            {
                return textEdited;
            }
            set
            {
                textEdited = value;
                SetInfo();
            }
        }

        void SetInfo()
        {
            if (MyFileName == "")
            {
                this.Text = "Nowy plik";
            }
            else
            {
                this.Text = MyFileName;
            }
            if(TextEdited)
            {
                this.Text += " *";
            }
        }
        public Form1()
        {
            InitializeComponent();
            SetInfo();
        }
        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxEditor.Text = "";
            MyFileName = "";
            TextEdited = false;
        }
        private void owórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFDialog = new OpenFileDialog();
            OFDialog.Filter = MyFilter;
            if (OFDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxEditor.Text = File.ReadAllText(OFDialog.FileName);
                MyFileName = OFDialog.FileName;
                TextEdited = false;
            }
        }
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MyFileName == "")
            {
                zapiszJakoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(MyFileName, richTextBoxEditor.Text);
                TextEdited = false;
            } 
        }
        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFDialog = new SaveFileDialog();
            SFDialog.Filter = MyFilter;
            if (SFDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SFDialog.FileName, richTextBoxEditor.Text);
                MyFileName = SFDialog.FileName;
                TextEdited = false;
            }
        }

        private void richTextBoxEditor_TextChanged(object sender, EventArgs e)
        {
            TextEdited = true;
        }
    }
}
