using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;

namespace TextEditor
{
    public class TextClass
    {
        private List<List<char>> Text { get; set; } = new List<List<char>>();

        //I know that this shouldn't be like this. But  I don't have any another ideas 
        public Stack<char> History { get; set; } = new Stack<char>();
        private int Row { get; set; } = 0;
        private int Column { get; set; } = 0;

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
            History.Push(c);
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
            if (this.Column > 0)
            {
                Column--;
                Text[Row].Remove(Text[Row][Column]);
            }
            else
            {
                if(this.Row > 0)
                {
                    Row--;
                    this.Text[Row].Remove(Text[Row][Text[Row].Count]);
                    this.Column--;
                }
                else
                {
                    this.Row = 0;
                    this.Column = 0;
                }
            }
        }
    }
}
