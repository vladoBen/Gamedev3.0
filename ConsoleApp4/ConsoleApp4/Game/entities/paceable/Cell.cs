using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.paceable
{
    using Constants = ConsoleApp4.Game.common.Constants;

    public class Cell : Organism
    {

        public Cell() : base(Constants.HARMNESS_FOR_CELL, Harmness.Harmony.NEUTRAL)
        {
        }
    }

}
