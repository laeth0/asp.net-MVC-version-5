using System.Collections.Generic;
using WebApplication2.Models;


namespace WebApplication2.Repository
{
    public interface IRoomRepository
    {
        public List<Room> GetAllRoom();


        public void Create(Room room);
        public void Delete(int id);



    }
}
