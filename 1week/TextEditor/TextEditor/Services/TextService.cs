using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.Interfaces;

namespace TextEditor.Services
{
    public class TextService : ITextService
    {
        public List<List<string>> CreationOfText(string UserText)
        {
            List<List<string>> textList = new List<List<string>>();
            if(string.IsNullOrEmpty(UserText))
                throw new ArgumentNullException(nameof(UserText));
            var text = UserText.Split(" ");
            int CountOfLists = text.Length / 15;
            for(int i = 0; i < CountOfLists; i++)
            {
                List<string> newList = new List<string>();
                for(int j = i *15 ; j < (i+1) * 15; j++)
                {
                    newList.Add(text[j]);
                }
                textList.Add(newList);
            }
            return textList;
        }
    }
}
