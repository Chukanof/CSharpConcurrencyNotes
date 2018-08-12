using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConcurrencyNotes.Base;

namespace ConcurrencyNotes
{
    class SemaphoreOverviewExample : ISingleThreadExample
    {
        readonly SemaphoreSlim semaphore = new SemaphoreSlim(3);

        public  void Execute()
        {
            for (int i = 1; i <=5; i++)
            {
                new Thread(ThreadAction).Start(i);
            }
        }

        private void ThreadAction(object id)
        {
            Console.WriteLine(id+" preparing");
            // Thread.Sleep(200); // ожидаем пока все стартуемые потоки будут запущены

            semaphore.Wait(); // start critical section

            Console.WriteLine(id + " ......... executing");
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine(id+" EXECUTED!");
            
            semaphore.Release(); // end critical section
        }
    }
}
