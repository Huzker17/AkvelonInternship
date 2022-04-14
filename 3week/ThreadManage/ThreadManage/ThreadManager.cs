using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadManage
{
    public class ThreadManager
    {
        // Define an array with two AutoResetEvent WaitHandles.
        static WaitHandle[] waitHandles = new WaitHandle[]
        {
        new ManualResetEvent(false),
        new AutoResetEvent(false)
        };
        public void EnterPoint()
        {
            Thread thread = new Thread(EnterPoint);
        }
        public void FirstAndSecond()
        {

        }
    }
}
