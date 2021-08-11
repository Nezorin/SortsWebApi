using Microsoft.AspNetCore.Mvc;
using Sorts;
using Sorts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data_Acces;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SortController : ControllerBase
    {
        private readonly IDbRepository _dbRepository;
        private readonly BubbleSort bubbleSort;
        private readonly SelectionSort selectionSort;
        private readonly InsertionSort insertionSort;
        private readonly BogoSort bogoSort;
        private readonly MergeSort mergeSort;

        public SortController(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
            bubbleSort = new BubbleSort();
            selectionSort = new SelectionSort();
            insertionSort = new InsertionSort();
            bogoSort = new BogoSort();
            mergeSort = new MergeSort();
        }
        [HttpGet]
        [Route("/Sort/GetAll")]
        public async Task<ActionResult<IEnumerable<SortingResult>>> GetAllAsync()
        {
            return Ok(await _dbRepository.GetAllAsync());
        }
        [HttpGet]
        [Route("/Sort/{sortName}")]
        public async Task<ActionResult<SortingResult>> SortAsync([FromRoute] string sortName, [FromQuery] int[] array)
        {
            SortingResult sortedArray;
            switch (sortName)
            {
                case "BubbleSort":
                    sortedArray = bubbleSort.Sort(array);
                    break;
                case "InsertionSort":
                    sortedArray = insertionSort.Sort(array);
                    break;
                case "SelectionSort":
                    sortedArray = selectionSort.Sort(array);
                    break;
                case "MergeSort":
                    sortedArray = mergeSort.Sort(array);
                    break;
                case "BogoSort":
                    sortedArray = bogoSort.Sort(array);
                    break;
                default:
                    return BadRequest();
            }
            await _dbRepository.AddAsync(sortedArray);
            await _dbRepository.SaveChangesAsync();
            return Ok(sortedArray);
        }
    }
}
