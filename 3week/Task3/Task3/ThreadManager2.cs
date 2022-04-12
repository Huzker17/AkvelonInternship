using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class ThreadManager2
    {
        // Define an array with two AutoResetEvent WaitHandles.
        static WaitHandle[] waitHandles = new WaitHandle[]
        {
        new ManualResetEvent(false),
        new AutoResetEvent(false)
        };

        // Define a random number generator for testing.
        static Random r = new Random();

        public void EnterPoint()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadCreationForManualReset), waitHandles[0]);

            WaitHandle.WaitAny(waitHandles);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadCreationForAutoReset), waitHandles[1]);

            WaitHandle.WaitAll(waitHandles,10,true);
            
            ThreadPool.QueueUserWorkItem(new WaitCallback(WaitForAutoReset), new object[] { 3, waitHandles[0] });
            WaitHandle.WaitAll(waitHandles,10,true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(WaitForAutoReset), new object[] { 4, waitHandles[0] });
            WaitHandle.WaitAll(waitHandles,10,true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(WaitForAutoReset), new object[] { 5, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles,10,true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(WaitForAutoReset), new object[] { 6, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles,10,true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveSignal), new object[] { 5, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles,10,true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(SetSignal), new object[] { 2, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles,10,true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(SetSignal), new object[] { 1, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles, 10, true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveSignal), new object[] { 3, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles, 10, true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveSignal), new object[] { 4, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles, 10, true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ResetSignal), new object[] { 1, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles, 10, true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(SetSignal), new object[] { 2, waitHandles[1] });
            WaitHandle.WaitAll(waitHandles, 10, true);

            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveSignal), new object[] { 6, waitHandles[1] });
        }
        private void ResetSignal(Object state)
        {
            object[] array = state as object[];
            ManualResetEvent mre = (ManualResetEvent)waitHandles[0];
            Console.WriteLine("Thread {0} reset signal", array[0]);
            mre.Reset();

        }
        private void ReceiveSignal(Object state)
        {
            object[] array = state as object[];
            if (array[1].GetType() == typeof(AutoResetEvent))
            {
                AutoResetEvent mre = (AutoResetEvent)waitHandles[1];
                Console.WriteLine("Thread {0} received an auto signal, continue working", array[0]);
                mre.WaitOne();
            }
            if (array[1].GetType() == typeof(ManualResetEvent))
            {
                ManualResetEvent mre = (ManualResetEvent)waitHandles[0];
                Console.WriteLine("Thread {0} received an auto signal, continue working", array[0]);
                mre.WaitOne();
            }
        }
        private void WaitForAutoReset(Object state)
        {
             object[] array = state as object[];
            if (array[1].GetType() == typeof(AutoResetEvent))
            {
                AutoResetEvent mre = (AutoResetEvent)waitHandles[1];
                Console.WriteLine("Thread {0} is waiting for an auto signal from Thread 2.", array[0]);
                mre.WaitOne();
            }
            if(array[1].GetType() == typeof(ManualResetEvent))
            {
                ManualResetEvent mre = (ManualResetEvent)waitHandles[0];
                Console.WriteLine("Thread {0} is waiting for a manual signal from Thread 1.", array[0]);
                mre.WaitOne();
            }
        }
        private static void SetSignal(Object state)
        {
            object[] array = state as object[];
            if (array[1].GetType() == typeof(AutoResetEvent))
            {
                AutoResetEvent are = (AutoResetEvent)waitHandles[1];
                are.Set();
                Console.WriteLine("Thread {0} set signal." ,array[0]);
            }
            if (array[1].GetType() == typeof(ManualResetEvent))
            {
                ManualResetEvent mre = (ManualResetEvent)waitHandles[0];
                mre.Set();
                Console.WriteLine("Thread {0} set signal", array[0]);
            }

        }
        static void ThreadCreationForManualReset(Object state)
        {
            ManualResetEvent mre = (ManualResetEvent) waitHandles[0];
            Console.WriteLine("Thread 1 started");
            mre.Set();
        }
        static void ThreadCreationForAutoReset(Object state)
        {

            AutoResetEvent are = (AutoResetEvent) waitHandles[1];
            Console.WriteLine("Thread 2 started");
        }

    }
}
