using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class CourseRepository: ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourse()
        {
            try
            {
                return _context.Courses.Select(T => T).ToList();
            }
            catch (System.Exception ex)
            {
                string message = ex.Message;
                return new List<Course>();
            }
        }

        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Courses.Remove(_context.Courses.Where(T => T.CourseId == id).FirstOrDefault());
            _context.SaveChanges();
        }

    }
}
