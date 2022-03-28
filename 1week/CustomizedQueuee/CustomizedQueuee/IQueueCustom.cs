using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizedQueuee
{
    public interface IQueueCustom<T>
    {
        public T Dequeue();
        public void Enqueue(T item);
        object Peak();

    }
}
