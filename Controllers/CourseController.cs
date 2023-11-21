using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        //list all rooms
        [HttpGet]
        public ActionResult Index()
        {
            List<Course> course = _courseRepository.GetAllCourse();
            return View();
        }

        //create a course
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Course room)
        {
            _courseRepository.Create(room);
            return View();
        }


        //delete a course
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _courseRepository.Delete(id);
            }
            return View();
        }
    }
}
