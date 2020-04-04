using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.specs
{
    using ConsoleApp4.Game.common;

    public class Vitals
    {
        public Health health { get; set; }
        public Energy energy { get; set; }
        public  Money money { get; set; }

        public Vitals()
        {
            health = new Health(Constants.STARTING_HEALTH);
            money = new Money(Constants.STARTING_MONEY);
            energy = new Energy(Constants.STARTING_ENERGY);
        }

    }

}
