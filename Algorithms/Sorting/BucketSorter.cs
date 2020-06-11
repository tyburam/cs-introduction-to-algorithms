using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class BucketSorter : ISorter<int>
    {
        public IEnumerable<int> Sort(IEnumerable<int> collection)
        {
            int maximum = collection.Max(), numOfBuckets = maximum / 10;
            if(numOfBuckets <= 0) {
                numOfBuckets = 1;
            }
            var buckets = new List<int>[numOfBuckets];
            for (var i = 0; i < numOfBuckets; i++) 
            {
                buckets[i] = new List<int>();
            }
            
            for (var i = 0; i < collection.Count(); i++)
            {
                buckets[(collection.ElementAt(i) / 10)].Add(collection.ElementAt(i));
            }

            var result = new List<int>();
            var internalSorter = new InsertionSorter<int>();
            for (var i = 0; i < numOfBuckets; i++) 
            {
                buckets[i] = internalSorter.Sort(buckets[i]).ToList();
                result.AddRange(buckets[i]);
            }

            return result;

        }

        public void SortInPlace(ref IEnumerable<int> collection)
        {
            throw new NotImplementedException();
        }
    }
}
