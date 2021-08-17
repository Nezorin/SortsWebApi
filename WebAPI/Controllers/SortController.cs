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
        private readonly ISortService _sortService;

        public SortController(IDbRepository dbRepository, ISortService sortService)
        {
            _dbRepository = dbRepository;
            _sortService = sortService;
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
            SortingResult sortedArray = _sortService.Sort(array, sortName);
            if (sortedArray == null)
            {
                return BadRequest();
            }
            await _dbRepository.AddAsync(sortedArray);
            await _dbRepository.SaveChangesAsync();
            return Ok(sortedArray);
        }
    }
}
