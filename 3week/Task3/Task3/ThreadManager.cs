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
        private static AutoResetEvent event_1 = new AutoResetEvent(false);
        private static AutoResetEvent event_2 = new AutoResetEvent(false);

        public void Start()
        {
            Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");

            Thread thread1 = new Thread(() => { ThreadProc(4); });
            thread1.Name = "Thread 1";
            thread1.Start();
            ManualReset.Set();
            ManualReset.WaitOne();
            event_2.Set();

            Thread thread2 = new Thread(() => { ThreadProc(5); });
            thread2.Name = "Thread 2";
            thread2.Start();
            ManualReset.Set();
            ManualReset.WaitOne();
            event_1.Set();

            var threads = WaitHandle.SignalAndWait(event_1, event_2);
            if (threads)
            {
                Thread thread3 = new Thread(() => { ThreadProcForManual(1); });
                thread3.Name = "Thread 3";
                thread3.Start();
                Thread thread4 = new Thread(() => { ThreadProcForManual(1); });
                thread4.Name = "Thread 4";
                thread4.Start();
                Thread thread5 = new Thread(() => { ThreadProcForEvent(2); });
                thread5.Name = "Thread 5";
                thread5.Start();

                Thread thread6 = new Thread(() => { ThreadProcForEvent(2); });
                thread6.Name = "Thread 6";
                thread6.Start();
            }


            Console.ReadKey();
        }
        private void ThreadProcForEvent(int i)
        {
                Console.WriteLine("Just For A Fun " + i);
        }

        public void ThreadProc(int i)
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " started");
            ManualReset.WaitOne();
            ManualReset.Reset();
            //Console.WriteLine(
        }
        public void ThreadProcForManual (int i)
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " is waiting for a manual singal from #Thread " + i );
            ManualReset.WaitOne();
            ManualReset.Reset();
        }
    }
}
