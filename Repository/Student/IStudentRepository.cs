using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();
        public void Create(Student student);
        public void Delete(int Id);
        public void Register(int studentId, int courseId);

    }
}
