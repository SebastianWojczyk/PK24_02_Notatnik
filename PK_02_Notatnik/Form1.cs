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

        private String MyFileName = "";

        public Form1()
        {
            InitializeComponent();
        }
        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBoxEditor.Text = "";
            MyFileName = "";
        }
        private void owórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFDialog = new OpenFileDialog();
            OFDialog.Filter = MyFilter;
            if (OFDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBoxEditor.Text = File.ReadAllText(OFDialog.FileName);
                MyFileName = OFDialog.FileName;
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
            }
        }
    }
}
