// See https://aka.ms/new-console-template for more information
using TextEditor;
using TextEditor.Models;
using TextEditor.Operations;

Console.WriteLine("Hello, World!");
TextClass text = new TextClass();
UndoRedoStack stack = new UndoRedoStack();
App invoker = new App(text,stack);
invoker.InsertChar('T');
invoker.InsertChar('E');
invoker.InsertChar('L');
invoker.InsertChar('E');
invoker.InsertChar('G');
invoker.InsertChar('R');
invoker.InsertChar('A');
invoker.Undo();
invoker.Delete();
invoker.Undo();
invoker.Redo();

invoker.InsertChar('M');
invoker.InsertChar('M');
invoker.InsertChar('M');
invoker.Delete();
invoker.InsertChar('M');


