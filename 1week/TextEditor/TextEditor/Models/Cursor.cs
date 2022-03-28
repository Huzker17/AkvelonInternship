using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    public class Cursor
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public Cursor(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
