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

        private StringReader _reader;
        public Customer()
        {
            _reader = new StringReader("s");
        }

        ~Customer() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _reader.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
