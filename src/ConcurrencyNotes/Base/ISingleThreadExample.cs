using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyNotes.Base
{
    interface ISingleThreadExample : IThreadExample
    {
        void Execute();
    }
}
