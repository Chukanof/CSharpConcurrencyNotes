using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Base
{
    interface ISyncAsyncExample : IExample
    {
        Task StartAsync();
        Task StartSync();
    }
}
