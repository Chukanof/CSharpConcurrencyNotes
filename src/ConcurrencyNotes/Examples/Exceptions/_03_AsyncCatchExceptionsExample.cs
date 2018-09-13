using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Examples.Exceptions
{
    class _03_AsyncCatchExceptionsExample : ISingleExample
    {
        public void Execute()
        {
            try
            {
                Task.Run(() => throw new NotImplementedException()).GetAwaiter().GetResult();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
