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
            
            var result = collection.ToList();
            for(var i = 1; i < result.Count; i++)
            {
                var current = result[i];
                var j = i - 1;
                while(j >= 0 && result[j].CompareTo(current) > 0)
                {
                    result[j+1] = result[j];
                    j--;
                }
                result[j+1] = current;
            }
            return result;
        }
    }
}
