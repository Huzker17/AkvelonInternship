// See https://aka.ms/new-console-template for more information
using TextEditor;

Console.WriteLine("Hello, World!");
TextClass text = new TextClass();
Console.WriteLine(text.InsertChar('B').ToString());
Console.WriteLine(text.InsertChar('I').ToString());
Console.WriteLine(text.InsertChar('S').ToString());
Console.WriteLine(text.InsertChar('H').ToString());
Console.WriteLine(text.InsertChar('K').ToString());
Console.WriteLine(text.InsertChar('E').ToString());
Console.WriteLine(text.InsertChar('K').ToString());
text.MoveCursorTo(0,3);
Console.WriteLine(text.InsertChar('W').ToString());
text.MoveCursorTo(0,6);
text.Delete();
text.CreateNewRow();
text.MoveCursorTo(1, 0);
text.InsertChar('L');
text.InsertChar('O');
text.InsertChar('n');
text.InsertChar('d');
text.InsertChar('o');
text.InsertChar('n');
text.MoveCursorTo(1, 6);
text.Delete();
text.Delete();
text.Delete();
foreach (var item in text.Text)
{
    foreach (var letter in item)
    {
        Console.WriteLine(letter.ToString());
    }
}
