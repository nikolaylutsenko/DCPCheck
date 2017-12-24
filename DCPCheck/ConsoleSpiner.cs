using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DCPCheck
{
    public class ConsoleSpiner
    {
        int counter;
        public ConsoleSpiner()
        {
            counter = 0;
        }
        public void Turn()
        {
            counter++;
            switch (counter % 5)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("-"); break;
                case 4: Console.Write("|"); break;

            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            //Thread.Sleep(250);
        }
    }
}
