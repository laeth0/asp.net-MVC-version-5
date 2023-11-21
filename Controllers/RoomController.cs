using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }


        //list all rooms
        [HttpGet]
        public ActionResult Index()
        {
            List<Room> room = _roomRepository.GetAllRoom();
            return View();
        }

        //create a room
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            _roomRepository.Create(room);
            return View();
        }


        //delete a room
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _roomRepository.Delete(id);
            }
            return View();
        }
    }
}
