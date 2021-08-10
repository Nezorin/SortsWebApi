using Microsoft.EntityFrameworkCore;
using Sorts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Data_Acces
{
    public class DbRepository : IDbRepository
    {
        private readonly DataContext _context;
        public DbRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }
        public async Task AddAsync(SortingResult result)
        {
            await _context.Results.AddAsync(result);
        }
        public async Task<IEnumerable<SortingResult>> GetAllAsync()
        {
            return await _context.Results.ToListAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
