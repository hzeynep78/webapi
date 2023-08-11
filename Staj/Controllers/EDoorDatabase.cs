//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Staj.Models;
//using System.Collections.Generic;
//using System.Linq;

//namespace Staj.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EDoorDatabase : DoorInterface
//    {
//        private readonly DoorContext _context;

//        public EDoorDatabase(DoorContext context)
//        {
//            _context = context;
//        }

//        [HttpPost]
//        public Response Add(door _door)
//        {
//            if (_context.door.Any(d => d.id == _door.id))
//            {
//                return new Response { Message = "Aynı id değerine sahip bir kapı zaten mevcut. Başka bir id değeri girin." };
//            }

//            _context.door.Add(_door);
//            _context.SaveChanges();

//            return new Response { Message = "İşlem başarılı" };
//        }

//        [HttpGet]
//        public List<door> GetAll()
//        {
//            return _context.door.ToList();
//        }

//        [HttpPut]
//        public Response Update(door _door)
//        {
//            _context.Entry(_door).State = EntityState.Modified;
//            _context.SaveChanges();

//            return new Response { Message = "Güncelleme işlemi başarılı" };
//        }

//        [HttpDelete("{id}")]
//        public Response Delete(int id)
//        {
//            var door = _context.door.Find(id);

//            if (door == null)
//            {
//                return new Response { Message = "Böyle bir id bulunamadı" };
//            }

//            _context.door.Remove(door);
//            _context.SaveChanges();

//            return new Response { Message = "Silme işlemi başarılı" };
//        }
//    }
//}
