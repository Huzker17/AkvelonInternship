// See https://aka.ms/new-console-template for more information
using TextEditor.Models;
using TextEditor.Services;

TextService textService = new TextService();
Text textClass = new Text();
textClass._service.CreationOfText("Dear Clients, Employees, and Colleagues,We can not find words strong enough to describe our feelings about the massacre that is happening in Ukraine at this moment.This is not the time to issue long statements, but we want to make our position crystal clear.We, the global Akvelon team across all our offices in the US, Mexico, Asia, and Europe, are with Ukraine, thinking of you, praying for you.We have made the decision to close all of our offices in Russia starting March 11, 2022.We will support everyone willing to relocate immediately and continue working with us from other countries. Our clients are actively supporting this very difficult decision.");
Console.WriteLine("Hello, World!");
