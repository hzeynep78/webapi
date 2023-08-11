//using Microsoft.AspNetCore.Mvc;
//using Npgsql;
//using Staj.Models;
//using System.Collections.Generic;

//namespace Staj.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DoorDatabase : DoorInterface
//    {
//        private string connectionString = "Server=localhost;Port=5432;Database=staj;User Id=postgres;Password=HZFMRC19674;";

//        [HttpPost]
//        public Response Add(Door door)
//        {
//            using (var connection = new NpgsqlConnection(connectionString))
//            {
//                connection.Open();

//                var insertCommand = new NpgsqlCommand("INSERT INTO door (x, y) VALUES (@x, @y) RETURNING id", connection);
//                insertCommand.Parameters.AddWithValue("x", door.X);
//                insertCommand.Parameters.AddWithValue("y", door.Y);

//                var insertedId = insertCommand.ExecuteScalar();

//                if (insertedId == null || insertedId == DBNull.Value)
//                {
//                    return new Response { Message = "Kapı eklenirken hata oluştu." };
//                }

//                door.Id = Convert.ToInt32(insertedId);

//                return new Response { Message = "İşlem başarılı" };
//            }
//        }





//        [HttpGet]
//        public List<Door> GetAll()
//        {
//            var doorList = new List<Door>();

//            using (var connection = new NpgsqlConnection(connectionString))
//            {
//                connection.Open();

//                var command = new NpgsqlCommand("SELECT * FROM door", connection);
//                var reader = command.ExecuteReader();

//                while (reader.Read())
//                {
//                    var door = new Door
//                    {
//                        Id = reader.GetInt32(0),
//                        X = reader.GetInt32(1),
//                        Y = reader.GetInt32(2)
//                    };

//                    doorList.Add(door);
//                }
//            }

//            return doorList;
//        }
//        [HttpPut]
//        public Response Update(Door door)
//        {
//            using (var connection = new NpgsqlConnection(connectionString))
//            {
//                connection.Open();

//                var command = new NpgsqlCommand("UPDATE door SET x = @x, y = @y WHERE id = @id", connection);
//                command.Parameters.AddWithValue("x", door.X);
//                command.Parameters.AddWithValue("y", door.Y);
//                command.Parameters.AddWithValue("id", door.Id);

//                var rowsAffected = command.ExecuteNonQuery();

//                if (rowsAffected == 0)
//                {
//                    return new Response { Message = "Güncelleme işlemi başarısız" };
//                }
//            }

//            return new Response { Message = "Güncelleme işlemi başarılı" };
//        }
//        [HttpDelete]
//        public Response Delete(int id)
//        {
//            using (var connection = new NpgsqlConnection(connectionString))
//            {
//                connection.Open();

//                var command = new NpgsqlCommand("DELETE FROM door WHERE id = @id", connection);
//                command.Parameters.AddWithValue("id", id);

//                var rowsAffected = command.ExecuteNonQuery();

//                if (rowsAffected == 0)
//                {
//                    return new Response { Message = "Böyle bir id bulunamadı" };
//                }
//            }

//            return new Response { Message = "Silme işlemi başarılı" };
//        }
//    }
//}
