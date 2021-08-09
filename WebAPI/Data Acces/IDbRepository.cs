using Sorts.Models;
using System.Linq;

namespace WebAPI.Data_Acces
{
    public interface IDbRepository
    {
        IQueryable<SortingResult> GetAll();
        public SortingResult Add(SortingResult result);
        int SaveChanges();
    }
}
