using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class InsertionSorter<T> : AbstractSorter<T> where T: IComparable
    {
        public override void SortInPlace(ref IEnumerable<T> collection)
        {
            for(var i = 1; i < collection.Count(); i++)
            {
                var current = collection.ElementAt(i);
                var j = i - 1;
                while(j >= 0 && collection.ElementAt(j).CompareTo(current) > 0)
                {
                    collection = collection.Replace(j+1, collection.ElementAt(j));
                    j--;
                }
                collection = collection.Replace(j+1, current);
            }
        }
    }
}
