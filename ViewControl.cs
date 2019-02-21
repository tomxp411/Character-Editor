using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharEdit
{
    public partial class CharViewer : UserControl
    {
        int CHARSET_COUNT = 256;

        Brush textBrush = null;  //new SolidBrush(SystemColors.WindowText);
        Brush selectedBrush = null;
        Pen pen = null;
        int StartIndex = 0;
        public int BitsPerRow = 8;
        private int _bytesPerCharacter = 8;

        int Columns = 16;
        int Rows = 16;
        int Col1X = 28;
        int Row1Y = 28;
        int CharacterWidth = 12;
        int CharacterHeight = 12;

        int MouseAt = -1;

        public int SelectedIndex;
        public int SelectionLength = 1;

        public delegate void CharacterSelectedEvent(object sender, EventArgs e);
        public event CharacterSelectedEvent CharacterSelected;

        public CharViewer()
        {
            InitializeComponent();
        }

        public Font8bit FontData = new Font8bit();

        public MouseButtons MouseButton { get; private set; }

        int CHARSET_SIZE
        {
            get
            {
                return CHARSET_COUNT * BitsPerRow;
            }
        }

        public int BytesPerCharacter
        {
            get
            {
                return this._bytesPerCharacter;
            }

            set
            {
                this._bytesPerCharacter = value;
                Refresh();
            }
        }

        public Font8bit LoadBin(string Filename)
        {
            if (!System.IO.File.Exists(Filename))
                return null;

            byte[] data = new byte[CHARSET_SIZE];
            data = System.IO.File.ReadAllBytes(Filename);

            Font8bit font = new Font8bit();
            font.BytesPerCharacter = BytesPerCharacter;

            int i = 0;
            for (int c = 0; c < font.Count; c++)
            {
                FontCell cell = font[c];
                for (int row = 0; row < BytesPerCharacter; row++)
                {
                    cell.Data[row] = data[i];
                    i++;
                }
                if (i >= data.Length)
                    break;
            }

            return font;
        }

        public void SaveBin(string Filename, Font8bit font)
        {
            byte[] data = new byte[font.Count * font.BytesPerCharacter];
            int i = 0;
            for (int c = 0; c < font.Count; c++)
            {
                for (int row = 0; row < font.BytesPerCharacter; row++)
                {
                    data[i] = font[c].Data[row];
                    i++;
                }
            }
            System.IO.File.WriteAllBytes(Filename, data);
        }

        public byte[] LoadPNG(string Filename)
        {
            throw new NotImplementedException();

            if (!System.IO.File.Exists(Filename))
                return new byte[CHARSET_SIZE];

            byte[] data = new byte[CHARSET_SIZE];
            Bitmap img = Image.FromFile(Filename) as Bitmap;
            if (img == null)
                throw new Exception("Not a bitmap file");

            int pos = 0;
            int x = 0;
            int y = 32;
            int bit = 128;
            int row = 0;

            for (y = 0; y < img.Height; y += BytesPerCharacter)
            {
                for (x = 0; x < img.Width; x += 8)
                {
                    for (int cy = y; cy < y + BytesPerCharacter; cy++)
                    {
                        row = 0;
                        bit = 128;
                        for (int cx = x; cx < x + 8; cx++)
                        {

                            var pixel = img.GetPixel(cx, cy);
                            if (pixel.R > 0)
                                row = row | bit;
                            bit = (byte)(bit >> 1);
                        }
                        data[pos++] = (byte)row;
                    }
                }
            }

            return data;
        }

        // Copy all of the characters from the input to the output 
        // useful for converting BIN to PNG or PNG to BIN
        public void CopyAll()
        {
            CopyBlock(FontData, 0, 0, CHARSET_COUNT);
            Refresh();
        }

        // removed, since each font cell is now a unique entity
        ///// <summary>
        ///// converts a character set to the new height. Extra rows are added to or truncated
        ///// from the bottom. 
        ///// </summary>
        ///// <param name="OldHeight"></param>
        ///// <param name="NewHeight"></param>
        //internal void ConvertHeight(int OldHeight, int NewHeight)
        //{
        //    byte[] newData = new byte[NewHeight * CHARSET_COUNT];
        //    for (int c = 0; c < CHARSET_COUNT; c++)
        //    {
        //        for (int row = 0; row < OldHeight && row < NewHeight; row++)
        //        {
        //            int nr = c * NewHeight + row;
        //            int or = c * OldHeight + row;

        //            newData[nr] = FontData[or];
        //        }
        //    }

        //    FontData = newData;
        //    BytesPerCharacter = NewHeight;
        //}

        public void CopyNonPET()
        {
            // control characters (0-31)
            CopyBlock(FontData, 0x0, 0x0, 32);
            // 32 (space) to 63 (?)
            //CopyBlock(InputData, 32, 32, 32);
            // upper case letters
            //CopyBlock(InputData, 0, 64, 32);

            // grave (`)
            CopyBlock(FontData, 0x140, 0x60, 1);
            // lower case letters
            //CopyBlock(InputData, 0x101, 0x61, 26);
            // {|}~ and 127
            CopyBlock(FontData, 0x15b, 0x7b, 5);
            //solid block
            CopyBlock(FontData, 0xe0, 0xa0, 1);
            // C= PET symbols
            //CopyBlock(InputData, 0x61, 0xa1, 31);
            // Shifted PET symbols
            //CopyBlock(InputData, 0x40, 0xc0, 32);
            // new custom glyphs (last two rows)
            CopyBlock(FontData, 0xe0, 0xe0, 32);
            Refresh();

        }

        private void CharViewer_Load(object sender, EventArgs e)
        {
        }

        private void CharViewer_Paint(object sender, PaintEventArgs e)
        {
            DrawCharSet(FontData, e.Graphics, 0, 0);
        }

        internal void Clear()
        {
            FontData = new Font8bit(); // new byte[CHARSET_SIZE];
            Refresh();
        }

        private void DrawCharSet(Font8bit font, Graphics g, int StartX, int StartY)
        {
            if (font == null)
                return;

            if (textBrush == null)
            {
                textBrush = new SolidBrush(this.ForeColor);
                selectedBrush = new SolidBrush(Color.Gray);
                pen = new Pen(Color.Gray);
            }

            int characters = font.Count;
            int x0 = StartX;
            int x = x0;
            int y0 = StartY;
            int y = y0;
            int bitWidth = 2;
            int bitHeight = 2;
            CharacterWidth = bitWidth * 8 + 4;
            CharacterHeight = bitHeight * BytesPerCharacter + 4;
            int col = 0;

            Col1X = StartX + 28;
            int lastCol = Col1X + CharacterWidth * Columns;
            Row1Y = StartY + 28;
            int lastRow = Row1Y + CharacterHeight * Rows;
            //int[] cols = { StartX, StartX + 32, StartX + 28 };
            //int[] rows = { StartY, StartY + 24, StartY + 28 };

            g.DrawString(MouseAt.ToString(), this.Font, textBrush, 0, 0);

            x = Col1X;
            y = StartY;
            for (int i = 0; i < Columns; i++)
            {
                g.DrawLine(pen, x - 2, Row1Y - 4, x - 2, lastRow);
                g.DrawString(" " + i.ToString("X"), this.Font, textBrush, x, y);
                x += CharacterWidth;
            }
            g.DrawLine(pen, x - 2, Row1Y - 4, x - 2, lastRow);

            x = StartX;
            y = Row1Y;
            for (int i = 0; i < Rows; i++)
            {
                g.DrawLine(pen, Col1X - 4, y - 2, lastCol, y - 2);
                g.DrawString(i.ToString("X") + "0", this.Font, textBrush, x, y);
                y += CharacterHeight;
            }
            g.DrawLine(pen, Col1X - 4, y - 2, lastCol, y - 2);

            x = Col1X;
            y = Row1Y;
            for (int i = 0; i < characters; i++)
            {
                x0 = x;
                y0 = y;
                if (i >= SelectedIndex && i < SelectedIndex + SelectionLength)
                    g.FillRectangle(selectedBrush, x - 2, y - 2, CharacterWidth, CharacterHeight);

                for (int charRow = 0; charRow < BytesPerCharacter; charRow++)
                {
                    byte b = font[i].Data[charRow];
                    for (int bit = 128; bit > 0; bit = bit >> 1)
                    {
                        if ((b & bit) > 0)
                            g.FillRectangle(textBrush, x, y, bitWidth, bitHeight);
                        x += bitWidth;
                        //bit = bit >> 1;
                    }
                    x = x0;
                    y = y + bitHeight;
                }
                x = Col1X + ((i + 1) % Columns * CharacterWidth);
                y = Row1Y + ((int)(i + 1) / Rows) * CharacterHeight;

            }
        }

        /// <summary>
        /// Re-orders the loaded character set, placing the characters in ASCII order. 
        /// <para>Upper case letters start at 64</para>
        /// <para>Lower case letters start at 97</para>
        /// <para>Shifted symbols start at 192 (letter + 128)
        /// <para>C= PET symbols start at 160</para>
        /// <para>New symbols start at 224</para>
        /// <para>0-31 and 128-159 are control characters and not used</para>
        /// </summary>
        public void ConvertPETtoASCII()
        {
            //CopyBlock(CustomData, 0x0, 0x0, 32);
            // 32 (space) to 63 (?)
            CopyBlock(FontData, 32, 32, 32);
            // upper case letters
            CopyBlock(FontData, 0, 64, 32);

            // grave (`)
            // CopyBlock(InputData, 0x140, 0x60, 1);
            // lower case letters
            CopyBlock(FontData, 0x101, 0x61, 26);
            // {|}~ and 127
            //CopyBlock(InputData, 0x15b, 0x7b, 5);
            //solid block
            CopyBlock(FontData, 0xe0, 0xa0, 1);
            // C= PET symbols
            CopyBlock(FontData, 0x61, 0xa1, 31);
            // Shifted PET symbols
            CopyBlock(FontData, 0x40, 0xc0, 32);
            // new custom glyphs (last two rows)
            //CopyBlock(CustomData, 0xe0, 0xe0, 32);
            Refresh();

            //SaveBin("FOENIX-CHARACTER-ASCII.bin", OutputData);
        }

        private void CopyBlock(Font8bit source, int sourceIndex, int destIndex, int count)
        {
            for (int i = 0; i < count; i++)
            {
                CopyCharacter(sourceIndex + i, destIndex + i);
            }
        }

        private void CopyCharacter(int sourceIndex, int destIndex)
        {
            int sp = sourceIndex;
            int dp = destIndex;

            for (int i = 0; i < BytesPerCharacter; i++)
            {
                Array.Copy(FontData[sourceIndex].Data, FontData[destIndex].Data, FontData.BytesPerCharacter);
            }
        }

        private void CharViewer_SizeChanged(object sender, EventArgs e)
        {
        }

        private void CharViewer_Resize(object sender, EventArgs e)
        {
        }

        private void CharViewer_Click(object sender, EventArgs e)
        {
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
        }

        private void CharViewer_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Button == MouseButtons.Left)
            {
                CharViewer_MouseMove(sender, e);
                SelectionLength = MouseAt - SelectedIndex + 1;
                Refresh();
                OnCharacterSelected();
            }
            this.MouseButton = 0;
        }

        private void CharViewer_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = new Point();

            p.X = (e.X - Col1X) / CharacterWidth;
            p.Y = (e.Y - Row1Y) / CharacterHeight;

            if (p.X < 0 || p.X >= Columns)
                MouseAt = -1;
            else if (p.Y < 0 || p.Y >= Rows)
                MouseAt = -1;
            else
                MouseAt = p.Y * Columns + p.X;
        }

        private void CharViewer_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.MouseButton = e.Button;
                CharViewer_MouseMove(sender, e);
                SelectedIndex = MouseAt;
                SelectionLength = 1;
                Refresh();
            }
        }

        protected void OnCharacterSelected()
        {
            if (this.CharacterSelected == null)
                return;

            EventArgs e = new EventArgs();
            this.CharacterSelected(this, e);
        }
    }
}
