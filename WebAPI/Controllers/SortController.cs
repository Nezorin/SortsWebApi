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
        private readonly BogoSort bogoSort;
        private readonly MergeSort mergeSort;

        public SortController()
        {
            bubbleSort = new BubbleSort();
            selectionSort = new SelectionSort();
            insertionSort = new InsertionSort();
            bogoSort = new BogoSort();
            mergeSort = new MergeSort();
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
        [HttpGet]
        [Route("/sort/BubbleSort")]
        public ActionResult<SortingResult> BubbleSort([FromQuery] int[] array)
        {
            return Ok(bubbleSort.Sort(array));
        }
        [HttpGet]
        [Route("/sort/InsertionSort")]
        public ActionResult<SortingResult> InsertionSort([FromQuery] int[] array)
        {
            return Ok(insertionSort.Sort(array));
        }
        [HttpGet]
        [Route("/sort/SelectionSort")]
        public ActionResult<SortingResult> SelectionSort([FromQuery] int[] array)
        {
            return Ok(selectionSort.Sort(array));
        }
        [HttpGet]
        [Route("/sort/BogoSort")]
        public ActionResult<SortingResult> BogoSort([FromQuery] int[] array)
        {
            return Ok(bogoSort.Sort(array));
        }
        [HttpGet]
        [Route("/sort/MergeSort")]
        public ActionResult<SortingResult> MergeSort([FromQuery] int[] array)
        {
            return Ok(mergeSort.Sort(array));
        }
    }
}
