using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.paceable
{
    using Constants = ConsoleApp4.Game.common.Constants;
    using Randomizer = ConsoleApp4.Game.common.Randomizer;


    public class Imunity : Organism, Spreadable<Imunity>
    {

        public Imunity() : base(Constants.HARMNESS_FOR_IMUNITY, Harmness.Harmony.POSITIVE)
        {
        }

        public override IList<Imunity> getRandomKids(int max)
        {
            IList<Imunity> kids = new List<Imunity>();
            if (max > Constants.MAXIMUM_SPREADING_KIDS)
            {
                max = Constants.MAXIMUM_SPREADING_KIDS;
            }
            if (max <= Constants.STARTING_SPREADING_IMMUNITY)
            {
                max = Constants.STARTING_SPREADING_IMMUNITY;
            }

            int randomNumber = Randomizer.getRandomNumberMax(max);
            for (int i = 0; i < randomNumber; i++)
            {
                kids.Add(new Imunity());
            }

            return kids;
        }

        public double getHarmnessLevel()
        {
            return base.harmness.harmnes * Constant;
        }
    }

}
