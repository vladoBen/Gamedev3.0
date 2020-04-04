using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.effects
{
    //TODO: if effects are more complex then redefine each effect
    public class Effect
    {
        public string desciption { get; set; }
        public bool isActive { get; set; }
        public double dnaPrice { get; set; }

        public Effect(string desciption, double dnaPrice)
        {
            this.desciption = desciption;
            this.isActive = false;
            this.dnaPrice = dnaPrice;
        } 
    }

}
