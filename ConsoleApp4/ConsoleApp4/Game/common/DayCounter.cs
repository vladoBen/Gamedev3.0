using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.common
{
    public class DayCounter
    {
        public static int dayCount { get; set; }

        public static int increaseDay()
        {
            return dayCount++;
        }
    }
}
