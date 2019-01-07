// file:	Program.cs
//
// summary:	Implements the program class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingForm
{
    /// <summary>   A program. </summary>
    static class Program
    {
        /// <summary>   The main entry point for the application. </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DrawingForm());
        }
    }
}
