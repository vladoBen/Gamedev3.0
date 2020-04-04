using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.paceable
{
    public class Harmness
    {
        public enum Harmony
        {
            NEGATIVE = 0,
            POSITIVE = 1,
            NEUTRAL = -1
        }
     public Harmony harmony { get; set; }          
    }

}
