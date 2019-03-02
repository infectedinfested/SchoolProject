using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Data
{
    public interface ITeacherRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();
        Task<IEnumerable<Teacher>> GetTeachers();
        Task<Teacher> GetTeacher(int id);
    }
}
