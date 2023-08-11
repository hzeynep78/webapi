//using Microsoft.AspNetCore.Mvc;
//using Staj.Models;
//using System.Collections.Generic;
//using System.Linq;

//namespace Staj.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DoorController : DoorInterface
//    {
//        private static List<Door> _doorList = new List<Door>();

//        [HttpPost]
//        [HttpPost]
//        public Response Add(Door door)
//        {
//            var random = new Random();
//            int newId;

//            do
//            {
//                newId = random.Next(0, 101);
//            } while (_doorList.Any(d => d.Id == newId));//id kontrolü

//            var newDoor = new Door()
//            {
//                Id = newId,
//                X = door.X,
//                Y = door.Y
//            };

//            _doorList.Add(newDoor);
//            return new Response { Message = "İşlemi başarılı" };
//        }



//        [HttpGet]
//        public List<Door> GetAll()
//        {
//            return _doorList;
//        }
//        [HttpPut]
//        public Response Update(Door door)
//        {
//            var existingDoor = _doorList.FirstOrDefault(d => d.Id == door.Id);

//            if (existingDoor == null)
//            {
//                return new Response { Message = "Böyle bir id bulunamadı" };
//            }

//            existingDoor.X = door.X;
//            existingDoor.Y = door.Y;

//            return new Response { Message = "Güncelleme işlemi başarılı" };
//        }

//        [HttpDelete]
//        public Response Delete(int id)
//        {
//            var doorToRemove = _doorList.FirstOrDefault(d => d.Id == id);

//            if (doorToRemove == null)
//            {
//                return new Response { Message = "Böyle bir id bulunamadı" };
//            }

//            _doorList.Remove(doorToRemove);

//            return new Response { Message = "Silme işlemi başarılı" };
//        }
//    }
//}
