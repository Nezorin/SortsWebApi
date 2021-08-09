using Sorts.Models;
using System;

namespace Sorts
{
    public class BogoSort : SortingAlgorithm
    {
        public override SortingResult Sort(int[] array)
        {
            SortingResult sortingResult = CreateSortingResult(array, "BogoSort");

            stopwatch.Start();

            while (!IsSorted(array))
            {
                Shuffle(array);
            }

            stopwatch.Stop();

            sortingResult.SortingTime = stopwatch.Elapsed;
            return sortingResult;
        }

        private static void Shuffle(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                Swap(ref array[i], ref array[random.Next(0, array.Length)]);
            }
        }

        private static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i + 1] < array[i])
                    return false;
            }
            return true;
        }
    }
}
