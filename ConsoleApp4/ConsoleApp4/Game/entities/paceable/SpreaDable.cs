using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.entities.paceable
{
    public interface Spreadable<T>
    {
        IList<T> getRandomKids(int max);
        double getHarmnessLevel();

    }

}
