using Dispose.Models;
using System;
using System.Diagnostics;
using Xunit;

namespace Dispose.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void DisposeShouldReleaseComObject()
        {
            Customer cbd;

            using (cbd = new Customer())
            {
                Debug.Assert(!cbd.Disposed); // Best not be disposed yet.
            }

            try
            {
                Debug.Assert(cbd.Disposed); // Expecting an exception.
            }
            catch (Exception ex)
            {
                Debug.Assert(ex is ObjectDisposedException); // Better be the right one.
            }
        }
    }
}