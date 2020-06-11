using System.Collections.Generic;
using System.Linq;
using Algorithms.Sorting;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.Sorting
{
    public class BucketSorterTests
    {
        [Fact]
        public void Sort_DoesNotChange_OriginalInput()
        {
            //arrange
            const int firstElement = 5, lastElement = 3;
            var original = new List<int> {firstElement, 2, 4, 6, 1, lastElement};
            var sorter = new BucketSorter();
            //act
            var sorted = sorter.Sort(original);
            //assert
            original[0].Should().Be(firstElement);
            original[5].Should().Be(lastElement);
        }

        [Fact]
        public void Sort_Returns_AscOrderedCollection()
        {
            //arrange
            var original = new List<int> {5, 2, 4, 6, 1, 3};
            var sorter = new BucketSorter();
            //act
            var sorted = sorter.Sort(original).ToList();
            //assert
            var prev = sorted[0];
            for(var i = 1; i < sorted.Count; i++)
            {
                prev.Should().BeLessOrEqualTo(sorted[i]);
                prev = sorted[i];
            }
        }
    }
}
