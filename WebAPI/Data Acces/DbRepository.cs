using Sorts.Models;
using System;
using System.Linq;

namespace WebAPI.Data_Acces
{
    public class DbRepository : IDbRepository
    {
        private readonly DataContext _context;
        public DbRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }
        public SortingResult Add(SortingResult result)
        {
            return _context.Results.Add(result).Entity;
        }
        public IQueryable<SortingResult> GetAll() //TODO ienumarable OR iqueryable
        {
            return _context.Results.AsQueryable();
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
