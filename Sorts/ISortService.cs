using Sorts.Models;

namespace Sorts
{
    public interface ISortService
    {
        public SortingResult Sort(int[] array, string sortName);
    }
}
