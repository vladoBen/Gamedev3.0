using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Utilities
{
    public class FormattedTime
    {
        private static Clocks clocks = new Clocks();

        public static string GameLength
        {
            get
            {
                return (new SimpleDateFormat("mm:ss.mmm")).format(new DateTime(clocks.CurrentGameLength));
            }
        }

        public virtual string finished()
        {
            return (new SimpleDateFormat("HH:mm:ss.mmm")).format(new DateTime(clocks.finished()));
        }
    }

}
