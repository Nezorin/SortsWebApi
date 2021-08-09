using Sorts.Models;
using System.Diagnostics;

namespace Sorts
{
    public abstract class SortingAlgorithm
    {
        protected Stopwatch stopwatch { get; set; }
        public SortingAlgorithm()
        {
            stopwatch = new Stopwatch();
        }
        public abstract SortingResult Sort(int[] array);
        /// <summary>
        /// Swap with third variable
        /// </summary>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static SortingResult CreateSortingResult(int[] array, string sortName)
        {
            return new SortingResult()
            {
                StartArray = (int[])array.Clone(),
                SortedArray = array,
                SortName = sortName,
                RequestTime = System.DateTime.Now
            };
        }
    }
}
