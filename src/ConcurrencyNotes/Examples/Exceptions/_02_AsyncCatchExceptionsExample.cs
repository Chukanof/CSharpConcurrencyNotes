using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Examples.Exceptions
{
    class _02_AsyncCatchExceptionsExample : ISingleExample
    {
        public void Execute()
        {
            var awaiter = Task.Run(() => throw new NotImplementedException()).GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                try
                {
                    awaiter.GetResult();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }
    }
}
