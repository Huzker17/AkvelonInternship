using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizedQueuee
{
    public class CustomQueue<T> : IQueueCustom<T>
    {
        public LinkedList<T> Queue { get; set; } = new LinkedList<T>();


        public T Dequeue()
        {
            if (Queue == null)
                throw new InvalidOperationException();
            if(Queue.Count == 0)
                throw new InvalidOperationException();
            if(Queue.First == null)
                throw new NullReferenceException();
            var firstItem = Queue.First;
            Queue.RemoveFirst();
            return firstItem.Value;
        }


        public void Enqueue(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            foreach (var item2 in Queue)
            {
                if (item2.GetType() != item.GetType())
                    throw new ArgumentException("Adding item should be same Type as Queue");
            }
            Queue.AddLast(item);

        }

        public object Peak()
        {
            if(this.Queue == null)
                throw new InvalidOperationException();
            if(this.Queue.First == null)
                throw new NullReferenceException();
            var firstItem = this.Queue.First;
            return firstItem.Value;
        }
    }
}
