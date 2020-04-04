using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.common
{
    public class Randomizer
    {
        public static int getRandomNumber(int min, int max)
        {
            return (new Random()).Next((max - min) + 1) + min;
        }

        public static int getRandomNumberMax(int max)
        {
            return getRandomNumber(0, max);
        }
    }

}
