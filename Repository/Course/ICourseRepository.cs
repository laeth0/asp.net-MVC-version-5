using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourse();


        public void Create(Course course);
        public void Delete(int id);


    }
}
