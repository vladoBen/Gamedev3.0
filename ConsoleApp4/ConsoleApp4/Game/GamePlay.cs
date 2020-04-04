using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game
{
    using ConsoleApp4.Entities;
	using ConsoleApp4.Game.common;
    using ConsoleApp4.Game.entities.alive.organs;
    using ConsoleApp4.Game.entities.effects;

    public class GamePlay
    {
        public User user { get; private set; }
        public GameState gameState { get; private set; }
        public Lungs Lungs { get; }
        private Event @event;

        public GamePlay(string userName)
        {
            user = new User(userName);
            gameState = GameState.PLAYING;
            Lungs = new Lungs(Constants.LUNGS_CELL_CAPACITY, "Lungs");
            @event = new Event(Lungs);
        }

        private int nextDay()
        {
            return DayCounter.increaseDay();
        }

        public virtual void newDay()
        {
            user.score = user.score + 1;
            nextDay();

            @event.addVirus();
            Lungs.endDay();

            if (Lungs.LungsState == LungsState.CURED)
            {
                gameState = GameState.WON;
            }

            if (Lungs.LungsState == LungsState.DESTROYED)
            {
                gameState = GameState.FAILED;
            }

            if (DayCounter.dayCount >= Constants.GAME_LENGTH)
            {
                gameState = GameState.NOTIME;
            }
        }

        public virtual bool buy(int choice)
        {
            if (choice >= PositiveEffects.EffectList.Capacity)
            {
                return false;
            }
            return Lungs.buyEffect(PositiveEffects.EffectList.get(choice));
        }

        public virtual bool buySomeImmunity(int count)
        {
            return @event.buyImmunity(count);
        }

        public virtual bool attack()
        {
            return Lungs.fight();
        }


        public int GetCurrentDay()
        {
            return DayCounter.dayCount;
        }
    }

}


