using Sorts.Data;
using Sorts.Models;
using System.Diagnostics;

namespace Sorts
{
    public abstract class SortingAlgorithm
    {
        protected ApplicationContext db { get; set; }
        protected Stopwatch stopwatch { get; set; }
        public SortingAlgorithm() : this(new ApplicationContext())
        {

        }
        public SortingAlgorithm(ApplicationContext dbContext)
        {
            db = dbContext;
            stopwatch = new Stopwatch();
        }
        public abstract SortingResult Sort(int[] array);
        /// <summary>
        /// Swap without third variable
        /// </summary>
        public static void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
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
