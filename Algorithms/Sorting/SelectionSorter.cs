using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class SelectionSorter<T> : AbstractSorter<T> where T: IComparable
    {
        public override void SortInPlace(ref IEnumerable<T> collection)
        {
            for(var i = 0; i < collection.Count() - 1; i++)
            {
                for(var j = i+1; j < collection.Count(); j++)
                {
                    if(collection.ElementAt(j).CompareTo(collection.ElementAt(i)) < 0)
                    {
                        collection = collection.SwapValues(i, j);
                    }
                }
            }
        }
    }
}
