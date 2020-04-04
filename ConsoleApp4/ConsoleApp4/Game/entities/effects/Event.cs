using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.effects
{
    using ConsoleApp4.Game.common;
    using Lungs = ConsoleApp4.Game.entities.alive.organs.Lungs;
    using Imunity = ConsoleApp4.Game.entities.paceable.Imunity;

    public class Event
    {
        private Lungs lungs;

        public Event(Lungs lungs)
        {
            this.lungs = lungs;
        }

        public void addVirus()
        {
            int numberOfViruses = Randomizer.getRandomNumberMax(PositiveEffects.EffectList.Count - PositiveEffects.Bonus);

            for (int i = 0; i < numberOfViruses; i++)
            {
                lungs.addVirus();
            }

        }

        public bool buyImmunity(int count)
        {
            IList<Imunity> imunitiesToBuy = (new ListFiller<Imunity>()).fillList(new Imunity(), count);
            return lungs.addImmunities(imunitiesToBuy);
        }
    }

}
