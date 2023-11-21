using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                List<Teacher> teachers = _context.Teachers.Select(T => T).ToList();
                return teachers;
            }
            catch (System.Exception ex)
            {
                string message = ex.Message;
                return new List<Teacher>();
            }   
        }

        public void Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Teachers.Remove(_context.Teachers.Where(T=>T.TeacherId==id).FirstOrDefault());
            _context.SaveChanges();
        }

    }
}
