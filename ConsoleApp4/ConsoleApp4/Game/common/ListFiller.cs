using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4.Game.common
{
    public class ListFiller<T>
    {
        public virtual IList<T> fillList(T typeOfObject, int size)
        {
            IList<T> listToFill = new List<T>();

            for (int i = 0; i < size; i++)
            {
                listToFill.Add(typeOfObject);
            }

            return listToFill;
        }
    }


}
