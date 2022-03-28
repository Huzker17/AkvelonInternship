using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    public class TextClass
    {
        public List<List<char>> Text { get; set; } = new List<List<char>>();
        public int Row { get; set; }=0;
        public int Column { get; set; } = 0;
        public void MoveCursorTo(int Row,int Column)
        {
            this.Row = Row;
            this.Column = Column;
        }
        public void CreateNewRow()
        {
            this.Text.Add(new List<char>());
        }
        public List<List<char>> InsertChar(char c)
        {
            if(Text.Count == 0)
            {
                List<char> row = new List<char>();
                row.Add(c);
                Text.Add(row);
            }
            else
            {
                if(Column == 0)
                    Text[Row].Add(c);
                else
                    Text[Row].Insert(Column, c);
            }
            Column++;
            return this.Text;
        }
        public void Delete()
        {
            Column--;
            Text[Row].Remove(Text[Row][Column]);
        }
    }
}
