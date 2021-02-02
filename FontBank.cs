using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharEdit
{
    public class FontBank : SortedList<int, FontCell>
    {
        static public int Max = 256;
        public FontBank(int Count)
        {
            for(int i=0; i<Count; i++)
            {
                this.Add(i, new FontCell());
            }
        }

        private int m_selectedIndex = 0;
        public int SelectedIndex
        {
            get
            {
                return m_selectedIndex;
            }
            set
            {
                if (value >= 0 && value < this.Count)
                {
                    m_selectedIndex = value;
                    CurrentCell = this[value];
                }
            }
        }

        public FontCell CurrentCell;
    }
}
