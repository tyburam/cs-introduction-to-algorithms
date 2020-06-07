using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class InsertionSorter<T> : ISorter<T> where T: IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            if (collection.Count() <= 1)
            {
                return collection;
            }
            
            IEnumerable<T> result = collection.ToList();
            // for(var i = 1; i < result.Count; i++)
            // {
            //     var current = result[i];
            //     var j = i - 1;
            //     while(j >= 0 && result[j].CompareTo(current) > 0)
            //     {
            //         result[j+1] = result[j];
            //         j--;
            //     }
            //     result[j+1] = current;
            // }
            SortInPlace(ref result);
            return result;
        }

        public void SortInPlace(ref IEnumerable<T> collection)
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
