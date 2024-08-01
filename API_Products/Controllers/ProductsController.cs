using API_Products.Data;
using API_Products.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        #region Session1
        //List<Product> Products = new List<Product>
        //{
        //    new Product {Id=1, Name="Laptop", Description="This is Laptop"},
        //    new Product {Id=2, Name="Desktop", Description="This is Desktop"},
        //    new Product {Id=3, Name="Printer", Description="This is Printer"},
        //    new Product {Id=4, Name="HeadPhone", Description="This is HeadPhone"},
        //};


        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var product = Products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //        return NotFound();

        //    return Ok(product);
        //}


        //[HttpPost]
        //public IActionResult Add(Product request)
        //{
        //    if (request == null)
        //        return BadRequest();

        //    var product = new Product
        //    {
        //        Id = request.Id,
        //        Name = request.Name,
        //        Description = request.Description,
        //    };

        //    Products.Add(product);
        //    return Ok(Products);
        //}


        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Product request)
        //{
        //    var product = Products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //        return BadRequest();

        //    product.Name = request.Name;
        //    product.Description = request.Description;

        //    return Ok(product);
        //}


        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var product = Products.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //        return NotFound();

        //    Products.Remove(product);
        //    return Ok(Products);
        //}
        #endregion



        public ProductsController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = dbContext.Products;
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var product = dbContext.Products.Find(id);
            //Find
            //FirstOrDefault
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product model)
        {
            dbContext.Products.Add(model);// Add Locally
            dbContext.SaveChanges();// Add Remotly(Add To DataBase)

            return CreatedAtAction(nameof(GetById), new { id = model.Id }, model);
        }


        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product model)
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
                return NotFound();

            product.Name = model.Name;
            product.Description = model.Description;

            dbContext.SaveChanges();
            return Ok();

        }


        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = dbContext.Products.Find(id);
            if (product == null)
                return NotFound();

            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}
