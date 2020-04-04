using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.specs
{
    using ConsoleApp4.Game.common;

    public class Health
    {
        private double currentHealth = Constants.MAX_HEALTH;

        public Health(double currentHealth)
        {
            this.currentHealth = currentHealth;
        }

        public Health()
        {

        }

        public void applyChanges(double value)
        {
            if (value == 0)
            {
                return;
            }
            currentHealth += value / Constants.HEALTH_DIVIDE_CONSTANT;
            if (currentHealth >= Constants.MAX_HEALTH)
            {
                currentHealth = Constants.MAX_HEALTH;
            }
        }

        public double CurrentHealth { get; }
    }

}
