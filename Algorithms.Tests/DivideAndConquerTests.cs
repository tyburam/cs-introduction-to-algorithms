using FluentAssertions;
using Xunit;

namespace Algorithms.Tests
{
    public class DivideAndConquerTests
    {
        [Fact]
        void FindMaximumSubArray_Works_ForNotEmptyArray()
        {
            //arrange
            var array = new int[] {13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7};
            //act
            var result = array.FindMaximumSubArray(0, array.Length - 1);
            //assert
            result.Item1.Should().Be(7);
            result.Item2.Should().Be(10);
            result.Item3.Should().Be(43);
        }
    }
}
