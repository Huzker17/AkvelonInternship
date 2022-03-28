using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;
using TextEditor.Services;

namespace TextEditor.Models
{
    public class Text
    {
        public int Id { get; set; }
        public List<List<string>> TextField { get; set; }

        public Text(string UserText)
        {
            ITextService service = new TextService();
            this.TextField = service.CreationOfText(UserText);
        }
    }
}
