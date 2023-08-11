using Staj.Models;
using System.Collections.Generic;

namespace Staj.Controllers
{
    public interface DoorInterface
    {
        Response Add(door _door);
        List<door> GetAll();
        Response Update(door _door);
        Response Delete(int id);
    }
}
