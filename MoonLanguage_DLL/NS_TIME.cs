using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nightscript
{
    class NS_TIME
    {
        public static void TIME_WAIT<T>(T Amount)
               => Thread.Sleep(Convert.ToInt32(Amount));
    }
}
