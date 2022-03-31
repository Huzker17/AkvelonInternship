using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;

namespace TextEditor.Models
{
    public class TextClass
    {
        private List<List<char>> Text { get; set; } = new List<List<char>>();

        private char DeletedChar;

        public int Row { get; private set; } = 0;
        public int Column { get; private set; } = 0;

        public void MoveCursorTo(int Row,int Column)
        {
            if(Row < 0 || Column < 0 || Row >= Text.Count)
                throw new ArgumentOutOfRangeException(nameof(Row), nameof(Column));
            this.Row = Row;
            this.Column = Column;
        }
        public void CreateNewRow()
        {
            this.Row = this.Text.Count;
            this.Column = 0;
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
        public char Delete()
        {
            if (this.Column > 0)
            {
                Column--;
                DeletedChar = Text[Row][Column];
                Text[Row].Remove(Text[Row][Column]);
                return DeletedChar;
            }
            else
            {
                if(this.Row > 0)
                {
                    Row--;
                    this.Column = Text[Row].Count;
                    this.Column--;
                    DeletedChar = this.Text[Row][Column];
                    this.Text[Row].Remove(Text[Row][Column]);
                    this.Text.RemoveAt((Row + 1));
                    return DeletedChar;
                }
                else
                {
                    this.Row = 0;
                    this.Column = 0;
                    return DeletedChar;
                }
            }
        }

    }
}
