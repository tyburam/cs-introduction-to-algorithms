using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            return MergeSort(collection.ToList());
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            IList<T> left = new List<T>(), right = new List<T>();
            int middle = collection.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }
            for (int i = middle; i < collection.Count(); i++)
            {
                right.Add(collection[i]);
            }
            
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> result = new List<T>();
            while(left.Count > 0 && right.Count > 0)
            {
                if (left.First().CompareTo(right.First()) <= 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            while(left.Count > 0)
            {
                result.Add(left.First());
                left.Remove(left.First());
            }
            while(right.Count > 0)
            {
                result.Add(right.First());
                right.Remove(right.First());
            }
            return result;
        }
    }
}
