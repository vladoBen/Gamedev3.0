using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.effects
{
    using Constants = ConsoleApp4.Game.common.Constants;


    public class PositiveEffects
    {
        private static List<Effect> effectList = new List((new Effect("Washing hands", Constants.PRICE_FOR_WASHING_HANDS)), (new Effect("Wearing protection", Constants.PRICE_FOR_WEARING_PROTECTION)), (new Effect("Social Distancing", Constants.PRICE_FOR_SOCIAL_DISTANCING)), (new Effect("Healthy regime", Constants.PRICE_FOR_HEALTHY_REGIMEN)), (new Effect("Learning", Constants.PRICE_FOR_LEARNING)));

        public static List<Effect> EffectList
        {
            get
            {
                return effectList;
            }
        }

        public static int Bonus
        {
            get
            {
                int bonus = 0;
                foreach (Effect e in effectList)
                {
                    if (e.isActive)
                    {
                        bonus++;
                    }
                }
                return bonus;
            }
        }

        public static bool buyEffect(Effect effect)
        {
            if (!effectList.Contains(effect))
            {
                return false;
            }

            effect.isActive = true;
            return effect.isActive;
        }
    }
}

