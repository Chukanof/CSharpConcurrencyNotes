using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Base
{
    interface ISyncNonSyncThreadExample : IThreadExample
    {
        Task StartNonSynced();
        Task StartSynced();
    }
}
