using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class QuickSorter<T> : ISorter<T> where T : IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            IEnumerable<T> result = collection.ToList();
            SortInPlace(ref result);
            return result;
        }

        public void SortInPlace(ref IEnumerable<T> collection)
        {
            QuickSort(ref collection, 0, collection.Count() - 1);
        }

        private void QuickSort(ref IEnumerable<T> collection, int left, int right)
        {
            if(left < right)
            {
                var pivot = Partition(ref collection, left, right);
                QuickSort(ref collection, left, pivot - 1);
                QuickSort(ref collection, pivot + 1, right);
            }
        }

        private int Partition(ref IEnumerable<T> collection, int left, int right)
        {
            var splitValue = collection.ElementAt(right);
            var pivot = left - 1;
            for(var i = left; i < right; i++)
            {
                if(collection.ElementAt(i).CompareTo(splitValue) <= 0)
                {
                    pivot++;
                    collection = collection.SwapValues(pivot, i);
                }
            }
            collection = collection.SwapValues(pivot+1, right);
            return pivot+1;
        }
    }
}
