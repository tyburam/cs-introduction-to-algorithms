using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class CountingSorter : ISorter<int>
    {
        public IEnumerable<int> Sort(IEnumerable<int> collection)
        {
            List<int> result = new List<int>(collection);
            var counter = new int[collection.Max() + 1];
            for(var i = 0; i < counter.Length; i++)
            {
                counter[i] = 0;
            }

            foreach(var value in collection)
            {
                counter[value]++;
            }

            var numItemsBefore = 0;
            for(var i = 0; i < counter.Length; i++)
            {
                var tmp = counter[i];
                counter[i] = numItemsBefore;
                numItemsBefore += tmp;
            }

            foreach(var value in collection)
            {
                result[counter[value]] = value;
                counter[value]++;
            }

            return result;
        }

        public void SortInPlace(ref IEnumerable<int> collection)
        {
            throw new NotImplementedException();
        }
    }
}
