﻿using System.Collections.Generic;

namespace Algorithms.SortAlgorithms
{
    /// <summary>
    /// Place items in the backet
    /// Best:               Omega(n + k)
    /// Average:            Theta(n + k)
    /// Worst:              O(n^2)
    /// Additional memory:  n + k
    /// where 0 < a[i] < k
    /// </summary>
    public class BucketSorter : ISorter<int>
    {
        public void sort(int[] array)
        {
            if (array.Length < 2)
            {
                return;
            }

            var maxValue = array[0];
            var minValue = array[0];

            for (var i = 1; i < array.Length; i++)              // find min and max to understand how much backets we need
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }

                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            IList<int>[] buckets = new List<int>[maxValue - minValue + 1];  // creating buckets
            for (var i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            for (var i = 0; i < array.Length; i++)                          // put items to the buckets
            {
                buckets[array[i] - minValue].Add(array[i]);
            }

            int position = 0;
            for (var i = 0; i < buckets.Length; i++)                        // place items back to array
            {
                if (buckets[i].Count > 0)
                {
                    for (var j = 0; j < buckets[i].Count; j++)
                    {
                        array[position] = buckets[i][j];
                        position++;
                    }
                }
            }
        }
    }
}
