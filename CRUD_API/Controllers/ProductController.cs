using CRUD_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Controllers
{
    [Route("product")]
    public class ProductController : ControllerBase
    {
        AppDbContext _dbContext = new AppDbContext();
        [HttpGet("Get-all-product")]
        public ActionResult GetAll()
        {
            return Ok(_dbContext.Products.ToList());
        }
        [HttpGet("Get-by-id")]
        public ActionResult GetAll(int id)
        {
            return Ok(_dbContext.Products.Find(id));
        }
        [HttpPost("create-product")]
        public ActionResult CreateProduct(Product product)
        {
            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-product")]
        public ActionResult UpdateProduct(Product product)
        {
            try
            {
                var updateItem = _dbContext.Products.Find(product.Id);
                updateItem.Name = product.Name;
                updateItem.Description = product.Description;
                _dbContext.Products.Update(updateItem);
                _dbContext.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
