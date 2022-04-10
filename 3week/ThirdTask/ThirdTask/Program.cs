// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Hello, World!");
PriorProcess();

static void PriorProcess() { 

  bool mutexCreated = false;
Mutex mutex = new Mutex(true, @"Local\slimCODE.slimKEYS.exe", out mutexCreated);

if (!mutexCreated)
{
    if (GetProcess() != null)
    {
        mutex.Close();
        return;
    }
}

// The usual stuff with Application.Run()

mutex.Close();
}
static Process GetProcess()
{
   Process curr = Process.GetCurrentProcess();
   Process[] procs = Process.GetProcessesByName(curr.ProcessName);
   foreach (Process p in procs)
   {
       if ((p.Id != curr.Id) &&
           (p.MainModule.FileName == curr.MainModule.FileName))
           return p;
   }
   return null;
}