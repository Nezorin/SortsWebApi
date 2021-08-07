using Microsoft.AspNetCore.Mvc;
using Sorts;
using Sorts.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortController : ControllerBase
    {
        private readonly BubbleSort bubbleSort;
        private readonly SelectionSort selectionSort;
        private readonly InsertionSort insertionSort;

        public SortController()
        {
            bubbleSort = new BubbleSort();
            selectionSort = new SelectionSort();
            insertionSort = new InsertionSort();
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
        [HttpGet]
        [Route("/sort/BubbleSort")]
        public SortingResult BubbleSort([FromQuery] int[] array)
        {
            return bubbleSort.Sort(array);
        }
        [HttpGet]
        [Route("/sort/InsertionSort")]
        public SortingResult InsertionSort([FromQuery] int[] array)
        {
            return insertionSort.Sort(array);
        }
        [HttpGet]
        [Route("/sort/SelectionSort")]
        public SortingResult SelectionSort([FromQuery] int[] array)
        {
            return selectionSort.Sort(array);
        }
    }
}
