using E_Commerce.Data;
using E_Commerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public ActionResult CreateUser([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            User s = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Location = user.Location,
                Image = user.Image,
            };
            _db.Add(s);
            _db.SaveChanges();
            return NoContent();

        }
        

        

    }
}
