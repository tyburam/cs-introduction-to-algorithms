using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    public class HeapSorter<T> : ISorter<T> where T : IComparable
    {
        public IEnumerable<T> Sort(IEnumerable<T> collection)
        {
            if(collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            int length, heapSize;
            length = heapSize = collection.Count();
            if(length <= 0)
            {
                throw new ArgumentException(nameof(collection));
            }

            var maxHeap = BuildMaxHeap(collection, length, heapSize);
            for(var i = length - 1; i >= 1; i--)
            {
                SwapNodes(ref maxHeap, 0, i);
                heapSize--;
                Heapify(ref maxHeap, 0, heapSize);
            }

            return maxHeap;
        }

        private T[] BuildMaxHeap(IEnumerable<T> collection, int length, int heapSize)
        {
            var heap = (T[])Array.CreateInstance(typeof(T), length);
            for(var i = length / 2; i > 0; i--)
            {
                Heapify(ref heap, i, heapSize);
            }
            return heap;
        }

        private void Heapify(ref T[] heap, int nodeIndex, int heapSize)
        {
            int left = 2 * nodeIndex + 1, right = 2 * nodeIndex + 2;
            var largest = (left < heapSize && heap[left].CompareTo(heap[nodeIndex]) > 0) ? left : nodeIndex;
            if(right < heapSize && heap[right].CompareTo(heap[largest]) > 0)
            {
                largest = right;
            }
            if(largest != nodeIndex)
            {
                SwapNodes(ref heap, nodeIndex, largest);
                Heapify(ref heap, largest, heapSize);
            }
        }

        private void SwapNodes(ref T[] heap, int firstNode, int secondNode)
        {
            var tmp = heap[firstNode];
            heap[firstNode] = heap[secondNode];
            heap[secondNode] = tmp;
        }
    }
}
