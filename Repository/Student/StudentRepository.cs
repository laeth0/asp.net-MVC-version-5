using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = _context.Students.Select(S => S).ToList();
                return students;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new List<Student>();
            }


        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();// to save the changes in the database
        }

        public void Delete(int Id)
        {
            Student student = _context.Students.Where(S => S.Id == Id).FirstOrDefault();
            _context.Students.Remove(student);
            _context.SaveChanges();
        }


        public void Register(int studentId, int courseId)
        {
            //this is one way to do it
            //StudentCourse studentCourse = new StudentCourse();
            //studentCourse.StudentId = studentId;    
            //studentCourse.CourseId = courseId;
            //_context.StudentCourses.Add(studentCourse);

            _context.StudentCourses.Add(new StudentCourse { StudentId = studentId, CourseId = courseId });
            _context.SaveChanges();
        }
    }
}
