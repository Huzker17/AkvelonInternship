using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispose.Models
{
    public class Customer : IDisposable
    {
        private bool _disposedValue;
        public string Name = "";
        public bool Disposed
        {
            get
            {
                if (!this._disposedValue)
                    return this._disposedValue;
                throw new ObjectDisposedException("CanBeDisposed");
            }
        }

        private StringReader _reader;
        public Customer()
        {
            _reader = new StringReader("s");
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposedValue)
            {
                if (disposing)
                {
                    //// Dispose of managed resources.
                }
                //// Dispose of unmanaged resources.
                this._disposedValue = true;
            }
        }

        // Destructor to clean up unmanaged resources
        // but not managed resources.
        ~Customer()
        {
            FreeResources(false);
        }

        // Keep track if whether resources are already freed.
        private bool ResourcesAreFreed = false;

        // Free resources.
        private void FreeResources(bool freeManagedResources)
        {
            Console.WriteLine(Name + ": FreeResources");
            if (!ResourcesAreFreed)
            {
                // Dispose of managed resources if appropriate.
                if (freeManagedResources)
                {
                    // Dispose of managed resources here.
                    Console.WriteLine(Name + ": Dispose of managed resources");
                }

                // Dispose of unmanaged resources here.
                Console.WriteLine(Name + ": Dispose of unmanaged resources");

                // Remember that we have disposed of resources.
                ResourcesAreFreed = true;
            }
        }
    }
}
