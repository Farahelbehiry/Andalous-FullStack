using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.Services.Interfaces;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")] //https://localhost:7109/api/Products
    public class ProductsController : ControllerBase
    {
        private IProductService _productservice;
        public ProductsController(IProductService productuctservice)
        {
            _productservice = productuctservice;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetAll()
        {
            return Ok(_productservice.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           
            var products = _productservice.GetById(id);
            if(products == null)
            {  return NotFound(); }

            return Ok(products);
        }
        [HttpPost]
        public IActionResult Create(Products product)
        {
            var created = _productservice.Create(product);
            return CreatedAtAction(nameof(GetById),new {id=product.Id },product);
        }
        [HttpPut("{id}")]
        public IActionResult Update (int id,Products updatedproduct)
        {
           var updated = _productservice.Update(id,updatedproduct);
            if (updated == null)
                return NotFound();
            
            return Ok(updated);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var gonnadelete = _productservice.Delete(id);
            if (gonnadelete == false)
                return NotFound();
            return NoContent();

        }

        //bonus
        [HttpPatch("{id}")]
        public IActionResult UpdateNameField(int id,Products product)
        {
            if(product.Name== null || product.Name == "" || product.Name == " ")
            {
                return BadRequest();
            }

            var gonnaupdate = _productservice.UpdateNameField(id,product);
            if (gonnaupdate == null)
                return NotFound();
            
            return Ok(gonnaupdate);
        }            
    }
}
