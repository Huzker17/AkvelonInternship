using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class ThreadManager
    {

        private static ManualResetEvent ManualReset = new ManualResetEvent(false);
        private static AutoResetEvent event_2 = new AutoResetEvent(true);
        private static AutoResetEvent event_3 = new AutoResetEvent(false);

        public void Start()
        {
            Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");
            for(int i = 1; i < 3; i++)
            {
                Thread thread = new Thread(ThreadProc);
                thread.Start();
            }
            for (int i = 1; i < 3; i++)
            {
                if (i == 0)
                {
                    Thread thread1 = new Thread(ThreadProc);
                    thread1.Name = "Thread 1";
                    thread1.Start();
                    ManualReset.Set();
                    ManualReset.WaitOne();
                    Thread thread4 = new Thread(ThreadProc);
                    thread4.Name = "Thread 4";
                    thread4.Start();
                }
                if (i == 1)
                {
                    Thread thread2 = new Thread(ThreadProc);
                    thread2.Name = "Thread 2";
                    thread2.Start();
                    event_2.Set();
                    Thread thread5 = new Thread(ThreadProcForEvent);
                    thread5.Name = "Thread 5";
                    thread5.Start();
                    Thread.Sleep(1000);

                }
                if (i == 2)
                {
                    Thread thread3 = new Thread(ThreadProc);
                    thread3.Name = "Thread 3";
                    thread3.Start();
                    event_3.Set();
                    Thread thread6 = new Thread(ThreadProcForEvent);
                    thread6.Name = "Thread 6";
                    thread6.Start();
                }
            }
        }
        private void ThreadProcForEvent()
        {
                string name = Thread.CurrentThread.Name;

                Console.WriteLine("{0} waits on AutoResetEvent #2.", name);
                event_2.WaitOne();
                Console.WriteLine("{0} is released from AutoResetEvent #2.", name);

                Console.WriteLine("{0} waits on AutoResetEvent #3.", name);
                event_3.WaitOne();
                Console.WriteLine("{0} is released from AutoResetEvent #3.", name);

                Console.WriteLine("{0} ends.", name);
        }

        public void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " starts and calls ManualReset.WaitOne()");

            ManualReset.WaitOne();

            Console.WriteLine(name + " ends.");
            ManualReset.Reset();
        }
    }
}
