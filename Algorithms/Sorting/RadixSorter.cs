using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class RadixSorter : ISorter<int>
    {
        public IEnumerable<int> Sort(IEnumerable<int> collection)
        {
            List<int> result = new List<int>(collection);
            var maximum = collection.Max();

            for(var exp = 1; maximum / exp > 0; exp *= 10)
            {
                var counter = new int[10];
                for(var i = 0; i < counter.Length; i++)
                {
                    counter[i] = 0;
                }

                foreach(var value in result)
                {
                    counter[ (value/exp)%10 ]++;
                }

                for (var i = 1; i < 10; i++)
                {
                    counter[i] += counter[i - 1];
                }

                foreach(var value in collection)
                {
                    result[counter[ (value/exp)%10 ] - 1] = value;
                    counter[ (value/exp)%10 ]++;
                }
            }
            return result;
        }

        public void SortInPlace(ref IEnumerable<int> collection)
        {
            throw new NotImplementedException();
        }
    }
}
