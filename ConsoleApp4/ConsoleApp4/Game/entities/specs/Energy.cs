using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.specs
{
    using ConsoleApp4.Game.common;

    public class Energy
    {
        private double currentEnergy = Constants.MAX_HEALTH;

        public Energy()
        {
        }

        public Energy(double currentEnergy)
        {
            this.currentEnergy = currentEnergy;
        }

        public double getEnergy()
        {
            return currentEnergy;
        }

        public bool decreaseEnergy(double value)
        {
            if (currentEnergy - value < 0)
            {
                currentEnergy = 0;
                return false;
            }
            currentEnergy -= value;
            return true;
        }

        public bool increaseEnergy(double value)
        {
            if (value + currentEnergy > Constants.MAX_HEALTH)
            {
                currentEnergy = Constants.MAX_HEALTH;
                return false;
            }
            currentEnergy += value;
            return true;
        }
    }

}
