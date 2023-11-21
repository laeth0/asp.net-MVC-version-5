using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        //list all teachers
        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();   
            return View();
        }

        //create a teacher
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            _teacherRepository.Create(teacher);
            return View();
        }


        //delete a teacher
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _teacherRepository.Delete(id);
            }
            return View();
        }




    }
}
