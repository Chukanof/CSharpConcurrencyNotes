using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConcurrencyNotes.Base;

namespace ConcurrencyNotes.Examples
{
    class ReaderWriterLockOverviewExample : ISingleExample
    {
        readonly ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
        readonly List<int> _items = new List<int>();
        readonly Random _rnd = new Random();

        public void Execute()
        {
            new Thread(Read).Start();
            new Thread(Read).Start();
            new Thread(Read).Start();
            new Thread(Write).Start("A");
            new Thread(Write).Start("B");
        }

        private void Read()
        {
            while (true)
            {
                _rw.EnterReadLock();

                _items.ForEach(x => Thread.Sleep(10));

                _rw.ExitReadLock();
            }
        }

        private void Write(object threadId)
        {
            while (true)
            {
                int newNumber = GetRandomNum(100);

                _rw.EnterWriteLock();
                _items.Add(newNumber);
                _rw.ExitWriteLock();
                Console.WriteLine("Thread " + threadId + " added " + newNumber);
                Thread.Sleep(100);
            }
        }

        private int GetRandomNum(int max)
        {
            lock (_rnd)
            {
                return _rnd.Next(max);
            }
        }
    }
}
