using System;

namespace ConsoleApp4
{
    using ConsoleApp4.ui;
    using ConsoleApp4.Utilities;

    public class main
    {
        public static void Main(string[] args)
        {
            FormattedTime clocks = new FormattedTime();

            Konzola console = new Konzola();

            Console.WriteLine(clocks.finished());


        }
    }

}
