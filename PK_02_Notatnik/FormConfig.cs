using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PK_02_Notatnik
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        public Color EditorBackColor
        {
            get
            {
                return labelTest.BackColor;
            }
            set
            {
                labelTest.BackColor = value;
            }
        }
        public Color EditorForeColor
        {
            get
            {
                return labelTest.ForeColor;
            }
            set
            {
                labelTest.ForeColor = value;
            }
        }
        public Font EditorFont
        {
            get
            {
                return labelTest.Font;
            }
            set
            {
                labelTest.Font = value;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.Color = EditorBackColor;
            if (CDialog.ShowDialog() == DialogResult.OK)
            {
                EditorBackColor = CDialog.Color;
            }
        }

        private void buttonForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog CDialog = new ColorDialog();
            CDialog.Color = EditorForeColor;
            if (CDialog.ShowDialog() == DialogResult.OK)
            {
                EditorForeColor = CDialog.Color;
            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            FontDialog FDialog = new FontDialog();
            FDialog.Font = EditorFont;
            if (FDialog.ShowDialog() == DialogResult.OK)
            {
                EditorFont = FDialog.Font;
            }
        }
    }
}
