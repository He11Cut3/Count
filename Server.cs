using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_Count
{
    public static class Server
    {
        private static int _count = 0;
        private static readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            try
            {
                _lock.EnterReadLock();
                return _count;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            try
            {
                _lock.EnterWriteLock();
                _count += value;
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
