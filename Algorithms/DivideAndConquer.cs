using System;

namespace Algorithms
{
    public static class DivideAndConquer
    {
        public static Tuple<int, int, int> FindMaximumSubArray(this int[] array, int low, int high)
        {
            if(high == low)
            {
                return new Tuple<int, int, int>(low, high, array[low]);
            }

            var mid = (low + high) / 2;
            var left = array.FindMaximumSubArray(low, mid);
            var right = array.FindMaximumSubArray(mid+1, high);
            var cross = array.FindMaximumCrossingSubArray(low, mid, high);

            if(left.Item3 >= right.Item3 && left.Item3 >= cross.Item3)
            {
                return new Tuple<int, int, int>(left.Item1, left.Item2, left.Item3);
            }

            if(left.Item3 >= right.Item3 && left.Item3 >= cross.Item3)
            {
                return new Tuple<int, int, int>(left.Item1, left.Item2, left.Item3);
            }

            if(right.Item3 >= left.Item3 && right.Item3 >= cross.Item3)
            {
                return new Tuple<int, int, int>(right.Item1, right.Item2, right.Item3);
            }

            return new Tuple<int, int, int>(cross.Item1, cross.Item2, cross.Item3);
        }

        public static Tuple<int, int, int> FindMaximumCrossingSubArray(this int[] array, int low, int middle, int high)
        {
            int leftSum = int.MinValue, righSum = int.MinValue, sum = 0, maxLeft = 0, maxRight = 0;
            
            for(var i = middle; i > low; i--)
            {
                sum += array[i];
                if(sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            sum = 0;
            for(var i = middle + 1; i < high; i++)
            {
                sum += array[i];
                if(sum > righSum)
                {
                    righSum = sum;
                    maxRight = i;
                }
            }

            return new Tuple<int, int, int>(maxLeft, maxRight, leftSum + righSum);
        }
    }
}
