using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Common
{
    public static class ListExtensions
    {
        public static T Pop<T>(this List<T> newCollection, int index)
        {
            T itemAtIndex = newCollection[index];
            newCollection.RemoveAt(index);
            return itemAtIndex;
        }

        public static bool TryPop<T>(this List<T> newCollection, out T itemAtIndex, int index = -1)
        {
            int listSize = newCollection.Count - 1;
            if (index == -1)
            {
                index = listSize;
            }

            if (index >= 0 && index <= listSize)
            {
                itemAtIndex = newCollection[index];
                newCollection.RemoveAt(index);
                return true;
            }
            itemAtIndex = default;
            return false;
        }
    }
}
