// See https://aka.ms/new-console-template for more information
using Task3;

Mutex mutexObj = new Mutex()
mutexObj.WaitOne();
Console.WriteLine("Hello, World!");
ThreadMaanger ThreadManager = new ThreadMaanger();
ThreadManager.Enter();
mutexObj.ReleaseMutex();
