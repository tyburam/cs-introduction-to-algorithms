using System.Collections.Generic;
using System.Linq;
using Algorithms.Randomisation;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.Randomisation
{
    public class PermutationTests
    {
        [Fact]
        public void PermuteBySorting_Returns_TheSameNumberOfElements()
        {
            //arrange
            var elements = new List<int> {1, 2, 3, 4};
            //act
            var result = Permutation<int>.PermuteBySorting(elements);
            //assert
            result.Count().Should().Be(elements.Count);
        }

        [Fact]
        public void PermuteBySorting_Returns_DifferentlyOrderedCollection_InTwoConsecutiveCalls()
        {
            //arrange
            var elements = new List<int> {1, 2, 3, 4};
            //act
            var result1 = Permutation<int>.PermuteBySorting(elements);
            var result2 = Permutation<int>.PermuteBySorting(elements);
            //assert
            result1.Should().NotEqual(result2);
        }

        [Fact]
        public void PermuteByRandomSwaps_Returns_TheSameNumberOfElements()
        {
            //arrange
            var elements = new List<int> {1, 2, 3, 4};
            //act
            var result = Permutation<int>.PermuteByRandomSwaps(elements);
            //assert
            result.Count().Should().Be(elements.Count);
        }

        [Fact]
        public void PermuteByRandomSwaps_Returns_DifferentlyOrderedCollection_InTwoConsecutiveCalls()
        {
            //arrange
            var elements = new List<int> {1, 2, 3, 4};
            //act
            var result1 = Permutation<int>.PermuteByRandomSwaps(elements);
            var result2 = Permutation<int>.PermuteByRandomSwaps(elements);
            //assert
            result1.Should().NotEqual(result2);
        }

        [Fact]
        public void PermuteByCyclic_Returns_TheSameNumberOfElements()
        {
            //arrange
            var elements = new List<int> {1, 2, 3, 4};
            //act
            var result = Permutation<int>.PermuteByCyclic(elements);
            //assert
            result.Count().Should().Be(elements.Count);
        }

        [Fact]
        public void PermuteByCyclic_Returns_DifferentlyOrderedCollection_InTwoConsecutiveCalls()
        {
            //arrange
            var elements = new List<int> {1, 2, 3, 4};
            //act
            var result1 = Permutation<int>.PermuteByCyclic(elements);
            var result2 = Permutation<int>.PermuteByCyclic(elements);
            //assert
            result1.Should().NotEqual(result2);
        }
    }
}
