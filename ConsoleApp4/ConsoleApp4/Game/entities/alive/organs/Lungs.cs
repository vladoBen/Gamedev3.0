using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.alive.organs
{
    using Constants = ConsoleApp4.Game.common.Constants;
    using ConsoleApp4.Game.common;
    using Effect = ConsoleApp4.Game.entities.effects.Effect;
    using GameEffects = ConsoleApp4.Game.entities.effects.PositiveEffects;
    using ConsoleApp4.Game.entities.effects;
    using ConsoleApp4.Game.entities.paceable;
    using ConsoleApp4.Game.entities.specs;


    public class Lungs
    {
        private Vitals vitals;
        private string desctiption;
        private LungsState lungsState = LungsState.WORKING;
        private int dayTime = 0;

        private IList<Virus> viruses;
        private IList<Imunity> imunities;
        private IList<Cell> cells;
        private IList<Effect> boughtEffects;

        public Lungs(int availableCells, string desctiption)
        {
            this.desctiption = desctiption;
            vitals = new Vitals();

            viruses = (new ListFiller<Virus>()).fillList(new Virus(), 0);
            imunities = (new ListFiller<Imunity>()).fillList(new Imunity(), 0);
            cells = (new ListFiller<Cell>()).fillList(new Cell(), availableCells);
            boughtEffects = new List<Effect>();
        }

        private void hardLaborForImmunity()
        {
            vitals.money.earnMoney((int)(imunities.Count * Constants.REWARD_FOR_BUYING_IMMUNITY));
        }

        private void reproduction()
        {
            IList<Virus> virs = new List<Virus>();
            foreach (Virus v in viruses)
            {
                ((List<Virus>)virs).AddRange(v.getRandomKids(boughtEffects.Count));
            }

            if (Viruses.Count + virs.Count > Cells.Count)
            {
                virs = (new ListFiller<Virus>()).fillList(virs[0], cells.Count);
                lungsState = LungsState.DESTROYED;
            }

            ((List<Virus>)Viruses).AddRange(virs);

            IList<Imunity> imms = new List<Imunity>();
            foreach (Imunity v in imunities)
            {
                ((List<Imunity>)imms).AddRange(v.getRandomKids(boughtEffects.Count));
            }

            if (Imunities.Count + imms.Count > Cells.Count)
            {
                imms = (new ListFiller<Imunity>()).fillList(imms[0], cells.Count);
                lungsState = LungsState.CURED;
            }

            ((List<Imunity>)Imunities).AddRange(imms);

            // earn some small amount of money by reproduction
            vitals.money.earnMoney((int)((virs.Count + imms.Count) * Constants.REWARD_FOR_ANY_CELL_REPRODUCTION));
        }

        public bool fight()
        {
            if (dayTime == 3)
            {
                return false;
            }

            int viruses = Viruses.Count;
            int imunities = Imunities.Count;

            if (viruses > imunities)
            {
                viruses = viruses - imunities;
                imunities = 0;
                if (viruses < 0)
                {
                    viruses = 0;
                }
            }
            else
            {
                imunities = imunities - viruses;
                viruses = 0;
                if (imunities < 0)
                {
                    imunities = 0;
                }
            }

            int virusesSize = Viruses.Count;
            for (int i = virusesSize - viruses - 1; i >= 0; i--)
            {
                Viruses.RemoveAt(i);
            }

            int immunitiesSize = Imunities.Count;
            for (int i = immunitiesSize - imunities - 1; i >= 0; i--)
            {
                Imunities.RemoveAt(i);
            }

            Vitals.money.earnMoney((int)(immunitiesSize - Imunities.Count * Constants.REWARD_FOR_FIGHT));

            dayTime++;
            return true;
        }

        private double healthCheck()
        {
            double value = 0;
            foreach (Spreadable v in Spreadable)
            {
                value += v.HarmnessLevel;
            }

            if (Viruses.Count == 0 && lungsState == LungsState.INFECTED)
            {
                lungsState = LungsState.CURED;
            }
            vitals.health.applyChanges(value);
            return value;
        }

        private IList<Spreadable> getSpecificAmmount(IList<Spreadable> spreadables, int ammount)
        {
            if (spreadables.Count >= ammount)
            {
                ammount = spreadables.Count;
            }
            return spreadables.subList(0, ammount);
        }

        public bool buyEffect(Effect effect)
        {
            if (!vitals.money.butStuff(effect.dnaPrice))
            {
                return false;
            }
            if (effect.isActive)
            {
                return false;
            }
            if (boughtEffects.Contains(effect))
            {
                return false;
            }

            boughtEffects.Add(effect);
            effect.isActive = true;

            return true;
        }

        public bool addVirus()
        {
            if (lungsState == LungsState.INFECTED)
            {
                return false;
            }
            viruses.Add(new Virus());

            lungsState = LungsState.INFECTED;
            return true;
        }

        public virtual bool addImmunities(IList<Imunity> imunities)
        {
            if (Imunities.Count + imunities.Count > Cells.Count)
            {
                return false;
            }
            if (!vitals.money.butStuff(imunities.Count))
            {
                return false;
            }

             ((List<Imunity>)Imunities).AddRange(imunities);
            return true;
        }

        public virtual void endDay()
        {
            dayTime = 0;
            hardLaborForImmunity();
            healthCheck();
            reproduction();
        }

        public virtual Vitals Vitals { get; }

        public virtual string Desctiption { get; }

        public virtual LungsState LungsState { get; }

        public IList<Spreadable> Spreadable
        {
            get
            {
                List<Spreadable> spreadables = new List<Spreadable>(Viruses);
                ((List<Spreadable>)spreadables).AddRange(Imunities);
                return spreadables;
            }
        }

        public IList<Virus> Viruses { get; }

        public virtual IList<Imunity> Imunities { get; }

        public virtual IList<Cell> Cells { get; }

        public virtual IList<Effect> BoughtEffects { get; }

        public string DayTime
        {
            get
            {
                if (dayTime == 0)
                {
                    return "Morning";
                }
                else if (dayTime == 1)
                {
                    return "Noon";
                }
                else if (dayTime == 2)
                {
                    return "Night";
                }
                else
                {
                    return "Sleeping";
                }
            }
        }
    }

}

