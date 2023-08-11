using Microsoft.AspNetCore.Mvc;
using Staj.Interfaces;
using Staj.Models;
using Staj.Repository;
using System.Collections.Generic;

namespace Staj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URController : ControllerBase, DoorInterface
    {
        private readonly IUnitOfWork _unitOfWork;

        public URController(DoorContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        [HttpPost]
        public Response Add(door _door)
        {
            if (_unitOfWork.DoorRepository.GetAll().Any(d => d.id == _door.id))
            {
                return new Response { Message = "Aynı id değerine sahip bir kapı zaten mevcut. Başka bir id değeri girin." };
            }

            _unitOfWork.DoorRepository.Add(_door);
            _unitOfWork.Save();

            return new Response { Message = "İşlem başarılı" };
        }

        [HttpGet]
        public List<door> GetAll()
        {
            return _unitOfWork.DoorRepository.GetAll().ToList();
        }

        [HttpPut]
        public Response Update(door _door)
        {
            _unitOfWork.DoorRepository.Update(_door);
            _unitOfWork.Save();

            return new Response { Message = "Güncelleme işlemi başarılı" };
        }

        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            _unitOfWork.DoorRepository.Delete(id);
            _unitOfWork.Save();

            return new Response { Message = "Silme işlemi başarılı" };
        }
    }
}
