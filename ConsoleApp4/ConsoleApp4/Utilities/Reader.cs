using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Utilities
{
    public class Reader
    {

        public static string readLine(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static int readInt(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            int number;
            Int32.TryParse(input, out number);
            return number;
        }

        public static ScannedInteger advancedIntScanner(string message)
        {
            return new ScannedInteger(readLine(message));
        }

        public class ScannedInteger
        {
            internal ScannedStatus status;
            internal int value;

            public ScannedInteger(string value)
            {
                try
                {
                    this.value = int.Parse(value);
                    this.status = ScannedStatus.SUCCESS;
                }
                catch (System.FormatException)
                {
                    this.value = 0;
                    this.status = ScannedStatus.ERROR;
                }
            }

            public ScannedStatus Status { get; }

            public int Value { get; }
        }

        public enum ScannedStatus
        {
            SUCCESS,
            ERROR
        }
    }

}
