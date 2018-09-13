using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Examples
{
    class AutoResetEventOverviewExample : ISingleExample
    {
        readonly AutoResetEvent auto = new AutoResetEvent(false);

        public void Execute()
        {
            new Thread(Waiter).Start();

            Thread.Sleep(TimeSpan.FromSeconds(5));

            auto.Set(); // послать уведомление
        }

        private void Waiter()
        {
            Console.WriteLine("waiting...");

            auto.WaitOne(); // ожидание уведомления

            Console.WriteLine("Notified");
        }
    }
}
