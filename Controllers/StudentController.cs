using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        //list of students
        [HttpGet]
        public ActionResult Index()
        {

            List<Student> students = _studentRepository.GetAllStudents();
            return View(students);// this statement is required becouse we use ActionResult as return type
        }



        // render the creation view
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }



        // add a new student
        [HttpPost]
        public ActionResult Create(Student student)
        {
            _studentRepository.Create(student);


            List<Student> students = _studentRepository.GetAllStudents();
            return View("Index", students);//this statement return me to index page
        }



        //deete a student
        [HttpDelete]
        public ViewResult Delete(int id)
        {
            if(id > 0)
            {
                _studentRepository.Delete(id);
            }
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(int studentId, int courseId)
        {
            _studentRepository.Register(studentId, courseId);
            return View();
        }





    }
}
