using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightscript
{
    class NS_PROCESS
    {
        /// <summary>
        /// Ends the process "proc"
        /// </summary>
        /// <param name="proc"></param>
        public static void PROCESS_KILL(string proc)
        {
            foreach (var woobie in Process.GetProcessesByName(proc))
            {
                woobie.Kill();
            }
        }
        public static void START_PROC(string path)
            => Process.Start(path);
        /// <summary>
        /// Returns the boolean true if the process "procname" exists
        /// </summary>
        /// <param name="procname"></param>
        /// <returns></returns>
        public static bool RETURN_PROC_EXISTS(string procname)
        {
            if (Process.GetProcessesByName(procname).Length > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
