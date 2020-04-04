using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Utilities
{
    public class Clocks
    {
        private long start;
        private long end;

        public Clocks()
        {
            start = DateTimeHelper.CurrentUnixTimeMillis();
        }

        public virtual long CurrentGameLength
        {
            get
            {
                return DateTimeHelper.CurrentUnixTimeMillis() - start;
            }
        }

        public virtual long finished()
        {
            end = DateTimeHelper.CurrentUnixTimeMillis();
            return end - start;
        }

    }

}

internal static class DateTimeHelper
{
    private static readonly System.DateTime Jan1st1970 = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
    public static long CurrentUnixTimeMillis()
    {
        return (long)(System.DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
    }

}
