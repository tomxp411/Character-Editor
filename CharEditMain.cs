using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharEdit
{
    public partial class CharEditMain : Form
    {
        int m_BytesPerCharacter = 8;

        public int BytesPerCharacter
        {
            get
            {
                return this.m_BytesPerCharacter;
            }

            set
            {
                this.m_BytesPerCharacter = value;
                charViewer1.BytesPerCharacter = value;
                editControl1.BytesPerCharacter = value;
            }
        }

        public CharEditMain()
        {
            InitializeComponent();
        }

        private void clearrToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "ROM file|*.bin|PNG Image|*.png|BMP Image|*.bmp|All Files|*.*";
            if (f.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(f.FileName).ToLower();
                switch (ext)
                {
                    case ".bin":
                        charViewer1.SaveBin(f.FileName, charViewer1.FontData);
                        break;
                    case ".png":
                    case ".bmp":
                        //charViewer1.InputData = charViewer1.LoadPNG(f.FileName);
                        break;
                }
                charViewer1.Refresh();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            //For now, only load BIN files.
            //f.Filter = "ROM BIN file|*.bin|PNG Image|*.png|BMP Image|*.bmp|All Files|*.*";
            f.Filter = "ROM BIN file|*.bin|All Files|*.*";

            if (f.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(f.FileName).ToLower();
                switch (ext)
                {
                    case ".bin":
                        charViewer1.FontData = charViewer1.LoadBin(f.FileName, BytesPerCharacter);
                        break;
                    case ".png":
                    case ".bmp":
                    default:
                        MessageBox.Show("File type not supported.");
                        break;
                }
                charViewer1.Refresh();
                editControl1.Enabled = true;
                RefreshBankSelect();
            }
        }

        private void RefreshBankSelect()
        {
            bankSelect.Items.Clear();
            for(int i=0; i<charViewer1.FontData.Banks.Count; i++)
            {
                bankSelect.Items.Add(i.ToString());
            }
        }

        private void CharEdWindow_Load(object sender, EventArgs e)
        {
            charViewer1.CharacterSelected += CharViewer1_CharacterSelected;
            editControl1.CharacterSaved += EditControl1_CharacterSaved;
        }

        private void EditControl1_CharacterSaved(object sender, EventArgs e)
        {
            charViewer1.Refresh();
        }

        private void CharViewer1_CharacterSelected(object sender, EventArgs e)
        {
            editControl1.LoadCharacter(charViewer1.FontData, charViewer1.SelectedIndex, charViewer1.BytesPerCharacter);
        }

        private void CharHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            int h;
            if(int.TryParse(CharHeight.Text, out h))
            {
                this.BytesPerCharacter = h;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            int from;
            int to;

            if (!int.TryParse(CharHeight.Text, out from))
                return;
            if (!int.TryParse(ConvertCharHeight.Text, out to))
                return;

            //charViewer1.ConvertHeight(from, to);

            CharHeight.Text = ConvertCharHeight.Text;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bankSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            int b = charViewer1.FontData.SelectedBank;
            int.TryParse(bankSelect.Text, out b);
            charViewer1.FontData.SelectedBank = b;
            charViewer1.Refresh();
        }
    }
}
