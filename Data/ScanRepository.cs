using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Data
{
    public class ScanRepository : IScanRepository
    {
        private readonly DataContext _context;

        public ScanRepository(DataContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Scan>> GetScans()
        {
            return await _context.Scans.ToListAsync();
        }

        public async Task<Scan> GetScan(int id)
        {
            return await _context.Scans.FirstOrDefaultAsync(S => S.Id == id);
        }
    }
}
