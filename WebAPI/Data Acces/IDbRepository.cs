using Sorts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Data_Acces
{
    public interface IDbRepository
    {
        Task<IEnumerable<SortingResult>> GetAllAsync();
        Task AddAsync(SortingResult result);
        Task SaveChangesAsync();
    }
}
