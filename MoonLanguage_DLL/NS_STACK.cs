using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightscript
{
    class NS_STACK
    {   /// <summary>
        ///  Clears Console
        /// </summary>
        public static void NS_CLEAR_OPT()
            => Console.Clear();
        /// <summary>
        /// 
        /// Prints the text to line
        /// 
        /// </summary>
        /// <param name="Text"></param>
        public static void CHAR_COUT_NL(string Text)
            => Console.WriteLine(Text);
        /// <summary>
        /// Reads the line of the console, can be returned
        /// <example>
        /// string helloworld = Output.ReadLine();
        /// </example>
        /// </summary>
        public static void CIN()
            => Console.ReadLine();
        /// <summary>
        /// Writes to the debug in visual studio
        /// </summary>
        /// <param name="Text"></param>
        public static void DBG_COUT(string Text)
            => Debug.WriteLine($"[NS] {Text}");
        /// <summary>
        /// Prints without going to the next line
        /// </summary>
        /// <param name="Text"></param>
        public static void COUT(string Text)
            => Console.Write(Text);
        /// <summary>
        /// Sets foreground to "color"
        /// </summary>
        /// <param name="color"></param>
        public static void FOREGROUND_SET(ConsoleColor color)
            => Console.ForegroundColor = color;
    }
}
