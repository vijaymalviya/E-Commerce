using E_Commerce.Data;
using E_Commerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            Product p = new Product()
            {
                ProductCategory = product.ProductCategory,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductPrice = product.ProductPrice,
                ProductImage = product.ProductImage,

            };
            _db.Add(p);
            _db.SaveChanges();

            return NoContent();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            return Ok(_db.product.ToList());
        }

        [HttpGet("{Id:int}")]
        public ActionResult<Product> GetProductById(int Id)
        {
             if(Id == 0)
        {
            return BadRequest();
        }
            var product = _db.product.Where(x => x.ProductId == Id);
            return Ok(product);
        }
        [HttpDelete]
        public ActionResult DeleteProductById(int Id)
        {
            if(Id == 0)
            {
                return BadRequest();
            }
            var p = _db.product.Where(x => x.ProductId == Id);

            _db.Remove(p);
            _db.SaveChanges();
            return NoContent();
        }
        
    }
}
