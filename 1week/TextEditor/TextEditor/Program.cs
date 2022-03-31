// See https://aka.ms/new-console-template for more information
using TextEditor;
using TextEditor.Models;
using TextEditor.Operations;

Console.WriteLine("Hello, World!");
TextClass text = new TextClass();
UndoRedoStack stack = new UndoRedoStack();
App invoker = new App(text,stack);
invoker.InsertChar('O');
invoker.InsertChar('P');
invoker.InsertChar('L');
invoker.InsertChar('D');
invoker.InsertChar('G');
invoker.Delete();
invoker.Delete();
invoker.Undo();
invoker.Undo();
invoker.InsertChar('R');
invoker.InsertChar('A');
invoker.CreateANewRow();
invoker.Delete();
int a = text.Column;

invoker.InsertChar('M');
invoker.InsertChar('M');
invoker.Undo();
invoker.Redo();
invoker.InsertChar('M');
invoker.Delete();
invoker.InsertChar('M');


