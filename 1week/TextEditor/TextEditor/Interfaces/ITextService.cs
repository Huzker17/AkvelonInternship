using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Interfaces
{
    public interface ITextService
    {
        public List<List<string>> CreationOfText(string UserText);
    }
}
