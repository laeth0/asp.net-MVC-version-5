using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();


        public void Create(Teacher teacher);
        public void Delete(int id);







    }
}
