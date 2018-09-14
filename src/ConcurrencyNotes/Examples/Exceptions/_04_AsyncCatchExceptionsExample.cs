using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Examples.Exceptions
{
    class _04_AsyncCatchExceptionsExample : ISingleExample
    {
        public void Execute()
        {
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            Task.Run(() => throw new NotImplementedException()).GetAwaiter().GetResult();
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
        }
    }
}
