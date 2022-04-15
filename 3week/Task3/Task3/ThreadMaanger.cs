using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class ThreadMaanger
    {
        private readonly static ManualResetEvent _manualReset = new ManualResetEvent(false);
        private readonly static AutoResetEvent _autoReset = new AutoResetEvent(false);

        private Thread _thread1 = new Thread(FirstThread);
        private Thread _thread2 = new Thread(SecondThread);


        private Thread _thread3 = new Thread(() =>
        {
            Console.WriteLine($"Thread 3 is wating for a manual signal from Thread 1");
            if (_manualReset.WaitOne() && _autoReset.WaitOne())
            {
                _manualReset.Reset();
                Console.WriteLine($"Thread 3 received a signal from Thread 1, continue working");
                _autoReset.Set();
            }
        });
        private Thread _thread4 = new Thread(() =>
        {
            Console.WriteLine($"Thread 4 is wating for a manual signal from Thread 1");
            if (_manualReset.WaitOne() && _autoReset.WaitOne())
            {
                _manualReset.Reset();
                Console.WriteLine($"Thread 4 received a signal from Thread 1, continue working");
                _autoReset.Set();
                _autoReset.Set();
                _manualReset.Reset();
            }
        });

        private Thread _thread5 = new(() =>
        {
            Console.WriteLine($"Thread 5 is waiting for an auto signal from Thread 2");
            if (_autoReset.WaitOne())
            {
                Console.WriteLine($"Thread 5 received an auto signal, continue working");
                _autoReset.Set();
                _manualReset.Set();
            }
        });
        private Thread _thread6 = new(() =>
        {
            Console.WriteLine($"Thread 6 is waiting for an auto signal from Thread 2");
            _autoReset.Set();
            if (_autoReset.WaitOne())
                _manualReset.Set();
            if (_autoReset.WaitOne() && _manualReset.WaitOne())
                if(_autoReset.WaitOne() && _manualReset.WaitOne())
                    Console.WriteLine($"Thread 6 received an auto signal, continue working");
        });



        public void Enter()
        {
            Console.WriteLine("Thread 1 started");
            _thread1.Start();
            Console.WriteLine("Thread 2 started");
            _thread2.Start();
            _thread3.Start();
            _thread4.Start();
            _thread5.Start();
            _thread6.Start();
        }


        private static void FirstThread()
        {
            if (_manualReset.WaitOne())
            {
                _manualReset.Reset();
                Console.WriteLine($"Thread 1 set signal");
                _manualReset.Set();
                _autoReset.Set();
                _autoReset.Set();
            }
            if (_manualReset.WaitOne() && _autoReset.WaitOne())
            {
                _manualReset.Reset();
                Console.WriteLine("Thread 1 reset a signal");
                _autoReset.Set();
                _manualReset.Set();
            }
        }

        private static void SecondThread()
        {
            if (_autoReset.WaitOne())
            {
                _autoReset.Set();
                Console.WriteLine($"Thread 2 set signal");
            }
            if (_autoReset.WaitOne() && _manualReset.WaitOne())
            {
                if (_autoReset.WaitOne())
                {
                    Console.WriteLine($"Thread 2 set signal");
                    _autoReset.Set();
                    _manualReset.Set();
                }
            }
        }
    }
}