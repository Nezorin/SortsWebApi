﻿using Microsoft.AspNetCore.Mvc;
using Sorts;
using Sorts.Models;
using System.Linq;
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
        public ActionResult<IQueryable<SortingResult>> GetAll()
        {
            return Ok(_dbRepository.GetAll());
        }
        [HttpGet]
        [Route("/Sort/{sortName}")]
        public ActionResult<SortingResult> Sort([FromRoute] string sortName, [FromQuery] int[] array)
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
            _dbRepository.Add(sortedArray);
            _dbRepository.SaveChanges();
            return Ok(sortedArray);
        }
    }
}
