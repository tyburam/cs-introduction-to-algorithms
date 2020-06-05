using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            var result = collection.ToList();
            for(var i = 0; i < result.Count - 1; i++)
            {
                for(var j = i+1; j < result.Count; j++)
                {
                    if(result[j].CompareTo(result[i]) < 0)
                    {
                        var tmp = result[i];
                        result[i] = result[j];
                        result[j] = tmp;
                    }
                }
            }
            return result;
        }
    }
}
