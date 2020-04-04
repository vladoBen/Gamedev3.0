using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.paceable
{
    using ConsoleApp4.Game.common;

    public class Virus : Organism, Spreadable<Virus>
    {

        public Virus() : base(Constants.HARMNESS_FOR_VIRUS, Harmness.Harmony.NEGATIVE)
        {
        }

        public override IList<Virus> getRandomKids(int max)
        {
            max = Constants.MAXIMUM_SPREADING_KIDS - max;

            IList<Virus> kids = new List<Virus>();
            if (max > Constants.STARTING_SPREADING_VIRUS)
            {
                max = Constants.STARTING_SPREADING_VIRUS;
            }
            if (max < 0)
            {
                max = 0;
            }

            int randomNumber = Randomizer.getRandomNumberMax(max);
            for (int i = 0; i < randomNumber; i++)
            {
                kids.Add(new Virus());
            }

            return kids;
        }

        public double getHarmnessLevel()
        {
            return base.harmness * Constant;
        }
    }

}
