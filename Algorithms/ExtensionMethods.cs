using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> enumerable, int index, T value)
        {
            return enumerable.Select((x, i) => index == i ? value : x);
        }

        public static IEnumerable<T> SwapValues<T>(this IEnumerable<T> enumerable, int firstIndex, int secondIndex)
        {
            var tmp = enumerable.ElementAt(firstIndex);
            enumerable = enumerable.Replace(firstIndex, enumerable.ElementAt(secondIndex));
            return enumerable.Replace(secondIndex, tmp);
        }
    }
}
