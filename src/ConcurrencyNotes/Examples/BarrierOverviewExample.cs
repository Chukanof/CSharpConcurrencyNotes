﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConcurrencyNotes.Base;

namespace ConcurrencyNotes.Examples
{
    class BarrierOverviewExample : ISingleThreadExample
    {
        readonly Barrier _barrier = new Barrier(3, brr => Console.WriteLine());

        public void Execute()
        {
            new Thread(Speaker).Start();
            new Thread(Speaker).Start();
            new Thread(Speaker).Start();
        }

        private void Speaker()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i+ " ");
                _barrier.SignalAndWait();
            }
        }
    }
}