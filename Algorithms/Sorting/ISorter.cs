using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public interface ISorter<T> where T: IComparable
    {
        IEnumerable<T> Sort(IEnumerable<T> collection);
    }
}