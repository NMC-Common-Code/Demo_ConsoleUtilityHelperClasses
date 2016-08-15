using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ConsoleUtilityHelperClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleView myConsoleView = new ConsoleView();

            myConsoleView.DisplayWelcomeScreen();
        }
    }
}
