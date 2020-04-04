using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.ui
{
    using ConsoleApp4.Game;
    using ConsoleApp4.Game.entities.effects;
    using ConsoleApp4.Utilities;

    public class Konzola
    {
        private GamePlay gamePlay;
        private ConsoleStatus status = ConsoleStatus.CONNECTED;
        private Commands commands;

        public Konzola()
        {
            this.gamePlay = new GamePlay("default");
            int choice = init();

            if (choice == 1)
            {
                play();
            }
            else
            {
                quit();
            }

        }

        private string askForName()
        {
            return Reader.readLine("Please provide your name first");
        }

        private int askForChoice()
        {
            return Reader.readInt("1 \t PLAY \n" + "2 \t QUIT");
        }

        private void printUI()
        {
            // TODO: Consider creating Thread only for this instead...
            System.Console.WriteLine("+============================ USER: " + gamePlay.user.name + " = " + gamePlay.user.score + " ============================+");
            System.Console.WriteLine("| DAY:    : \t\t\t" + gamePlay.GetCurrentDay() + " - " + gamePlay.Lungs.DayTime);
            System.Console.WriteLine("| HEALTH: : \t\t\t" + gamePlay.Lungs.Vitals.health.CurrentHealth);
            System.Console.WriteLine("| ENERGY: : \t\t\t" + gamePlay.Lungs.Vitals.energy);
            System.Console.WriteLine("| DNA     : \t\t\t" + gamePlay.Lungs.Vitals.money);

            System.Console.WriteLine("+-----------------------------------------------------------------------------------+");

            System.Console.WriteLine("| " + gamePlay.Lungs.Desctiption + "\t" + gamePlay.Lungs.LungsState + " |");
            System.Console.WriteLine("| CELL    : \t\t\t" + gamePlay.Lungs.Cells.Count);
            System.Console.WriteLine("| VIRUS   : \t\t\t" + gamePlay.Lungs.Viruses.Count);
            System.Console.WriteLine("| IMMUNITY: \t\t\t" + gamePlay.Lungs.Imunities.Count);

            System.Console.WriteLine("+===================================================================================+");
        }

        private void passCommand()
        {
            string command = Reader.readLine("Please execute your command: ? to see commands");

            if (command.Equals("1", StringComparison.OrdinalIgnoreCase))
            {
                commands = Commands.NEWDAY;
                gamePlay.newDay();
            }
            else if (command.Equals("2", StringComparison.OrdinalIgnoreCase))
            {
                commands = Commands.BUY;
                showShop();
                gamePlay.buy(Reader.readInt("Press what would you like to buy 0-4 press 9 to leave shop"));
            }
            else if (command.Equals("3", StringComparison.OrdinalIgnoreCase))
            {
                commands = Commands.ATTACK;
                gamePlay.attack();
            }
            else if (command.Equals("4", StringComparison.OrdinalIgnoreCase))
            {
                commands = Commands.BUYIMMUNITY;
                gamePlay.buySomeImmunity(Reader.readInt("What amount of immunity would you like to buy? One immunity cost 1DNA"));
            }
            else if (command.Equals("?", StringComparison.OrdinalIgnoreCase))
            {
                commands = Commands.HELP;
                help();
            }
            else if (command.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                commands = Commands.QUIT;
                quit();
            }
        }

        public virtual void showShop()
        {
            System.Console.WriteLine("| WELCOME TO EFFECTS SHOP");

            int it = 0;
            foreach (Effect effect in PositiveEffects.EffectList)
            {
                System.Console.WriteLine("| " + it++ + " =\t=" + effect.desciption + " =\t= " + effect.isActive + " =\t= " + effect.dnaPrice + "DNA");
            }
        }

        public virtual void help()
        {
            System.Console.WriteLine("BLBABLABLA:" + "\nTo skip turn and go to the next day press 1 - When you skip your day your immunities will give you DNA points used for buying stuff" + "\nTo buy something from shop press 2 and choose what would you like to buy - Every bought bonus gives you better chance to fight the virus and decreasing it's spreading " + "\nTo attack press 3 be carefull not to give virus great chance to spread because once there is no chance to take cells it will fight you " + "\nTo buy immunity press 4 " + "\nTo quit press Q ");
        }

        public virtual void loop()
        {
            while (gamePlay.gameState == GameState.PLAYING && status == ConsoleStatus.WORKING)
            {
                printUI();
                passCommand();
            }
            printUI();
        }

        private int init()
        {
            if (Reader.readLine("Press y  to jump right into game").equalsIgnoreCase("y"))
            {
                return 1;
            }

            this.gamePlay = new GamePlay(askForName());
            return askForChoice();
        }

        private void play()
        {
            status = ConsoleStatus.WORKING;
            loop();
        }

        private void quit()
        {
            status = ConsoleStatus.STOPPED;
        }

        public virtual ConsoleStatus Status
        {
            get
            {
                return status;
            }
        }
    }

}
