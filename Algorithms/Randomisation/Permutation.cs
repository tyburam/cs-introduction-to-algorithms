using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Randomisation
{
    public static class Permutation<T>
    {
        public static IEnumerable<T> PermuteBySorting(IEnumerable<T> collection)
        {
            var result = new List<T>(collection);
            var priorities = new List<int>();
            var rand = new Random();

            for(var i = 0; i < collection.Count(); i++)
            {
                priorities.Add(rand.Next());
            }

            for(var i = 0; i < result.Count; i++)
            {
                var maxPrInd = priorities.IndexOf(priorities.Max());
                var tmp = result[i];
                result[i] = result[maxPrInd];
                result[maxPrInd] = tmp;

                priorities[maxPrInd] = int.MinValue;
            }

            return result;
        }

        public static IEnumerable<T> PermuteByRandomSwaps(IEnumerable<T> collection, bool withoutIdentity = false)
        {
            var result = new List<T>(collection);
            var rand = new Random();
            var count = withoutIdentity ? collection.Count() - 1 : collection.Count();

            for(var i = 0; i < count; i++)
            {
                var randInd = rand.Next(withoutIdentity ? i+1 : 0, result.Count);
                var tmp = result[i];
                result[i] = result[randInd];
                result[randInd] = tmp;
            }
            return result;
        }

        public static IEnumerable<T> PermuteByCyclic(IEnumerable<T> collection)
        {
            var result = new List<T>(collection);
            var count = collection.Count();
            var offset = new Random().Next(count);

            for(var i = 0; i < count; i++)
            {
                var dest = i + offset;
                if(dest >= count) 
                {
                    dest -= count;
                }
                result[dest] = collection.ElementAt(i);
            }
            return result;
        }
    }
}
