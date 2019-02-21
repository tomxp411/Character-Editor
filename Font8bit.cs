using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharEdit
{
    public class Font8bit
    {
        public SortedList<int, FontCell> Data = new SortedList<int, FontCell>();
        public int Count = 256;
        public int BytesPerCharacter = 16;

        public Font8bit()
        {
            for (int i = 0; i < Count; i++)
            {
                FontCell c = new FontCell();
                Data.Add(i, c);
            }
        }

        public FontCell this[int i]
        {
            get
            {
                if (i < 0 || i >= Count)
                    throw new ArgumentException("index out of bounds. Allowed values are 0-" + (Count - 1).ToString());
                if (!Data.ContainsKey(i))
                    Data.Add(i, new FontCell());
                return Data[i];
            }

            set
            {
                if (Data.ContainsKey(i))
                    Data[i] = value;
                else
                    Data.Add(i, value);
            }
        }
    }
}
