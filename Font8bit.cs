using System;
using System.Collections.Generic;

namespace CharEdit
{
    public class Font8bit
    {
        public List<FontBank> Banks = new List<FontBank>();
        public int BytesPerCharacter = 16;

        public Font8bit(int BankCount, int CellsPerBank)
        {
            if (BankCount < 1)
                throw new Exception("BankCount must be > 0");
            for (int b = 0; b < BankCount; b++)
            {
                this.Banks.Add(new FontBank(CellsPerBank));
            }
            this.SelectedCharacter = 0;
        }

        private int m_selectedBank = 0;
        public int SelectedBank
        {
            get
            {
                return this.m_selectedBank;
            }
            set
            {
                if (value >= 0 && value < this.Banks.Count)
                {
                    this.m_selectedBank = value;
                }
            }
        }

        private int m_selectedIndex = 0;
        public int SelectedCharacter
        {
            get
            {
                return this.m_selectedIndex;
            }
            set
            {
                if (value >= 0 && value < this.CurrentFont.Count)
                {
                    this.m_selectedIndex = value;
                }
            }
        }

        public FontBank CurrentBank
        {
            get
            {
                return this.Banks[this.SelectedBank];
            }
        }

        public FontCell CurrentCell
        {
            get
            {
                return this.CurrentBank.CurrentCell;
            }
        }

        public FontCell this[int b, int c]
        {
            get
            {
                if (b < 0 || b >= this.Banks.Count)
                    throw new ArgumentException("b out of bounds. Allowed values are 0-" + (this.Banks.Count - 1).ToString());
                if (c < 0 || c >= this.Banks[b].Count)
                    throw new ArgumentException("index out of bounds. Allowed values are 0-" + (this.Banks[b].Count - 1).ToString());
                return this.Banks[b][c];
            }
        }

        public FontCell this[int i]
        {
            get
            {
                if (i < 0 || i >= this.CurrentFont.Count)
                    throw new ArgumentException("index out of bounds. Allowed values are 0-" + (this.CurrentFont.Count - 1).ToString());
                if (!this.CurrentFont.ContainsKey(i))
                    this.CurrentFont.Add(i, new FontCell());
                return this.CurrentFont[i];
            }

            set
            {
                if (this.CurrentFont.ContainsKey(i))
                    this.CurrentFont[i] = value;
                else
                    this.CurrentFont.Add(i, value);
            }
        }

        public FontBank CurrentFont
        {
            get
            {
                return this.Banks[this.SelectedBank];
            }
        }

        public int CharacterCount
        {
            get
            {
                return this.Banks.Count * this.CurrentFont.Count;
            }
        }

        public int TotalBytes
        {
            get
            {
                return this.Banks.Count * this.CurrentFont.Count * this.BytesPerCharacter;
            }
        }
    }
}
