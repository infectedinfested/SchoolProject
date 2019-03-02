using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;

namespace SchoolProject.Data
{
    public class StudentRepository :IStudentRepository
    {
        private readonly DataContext _context;

        public StudentRepository(DataContext context)
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

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(S => S.Id == id);
        }
    }
}
