using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public abstract class AbstractSorter<T> : ISorter<T> where T: IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            if (collection.Count() <= 1)
            {
                return collection;
            }
            
            IEnumerable<T> result = collection.ToList();
            SortInPlace(ref result);
            return result;
        }

        public abstract void SortInPlace(ref IEnumerable<T> collection);
    }
}
