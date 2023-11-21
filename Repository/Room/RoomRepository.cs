using System.Collections.Generic;
using System.Linq;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Repository
{
    public class RoomRepository: IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Room> GetAllRoom()
        {
            try
            {
                return _context.Rooms.Select(T => T).ToList();
            }
            catch (System.Exception ex)
            {
                string message = ex.Message;
                return new List<Room>();
            }
        }

        public void Create(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Rooms.Remove(_context.Rooms.Where(T => T.RoomId == id).FirstOrDefault());
            _context.SaveChanges();
        }

   

  
    }
}
