using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.specs
{
    public class Money
    {
        private double currentMoney { get; set; }

        public Money(double currentMoney)
        {
            this.currentMoney = currentMoney;
        }

        public bool butStuff(int price)
        {
            if (currentMoney - price < 0)
            {
                return false;
            }
            currentMoney -= price;
            return true;
        }

        public bool butStuff(double price)
        {
            return butStuff((int)price);
        }


        public void earnMoney(int earned)
        {
            currentMoney += earned;
        }
    }

}
