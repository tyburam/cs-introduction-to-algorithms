using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            IEnumerable<T> result = collection.ToList();
            SortInPlace(ref result);
            return result;
        }

        public void SortInPlace(ref IEnumerable<T> collection)
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
