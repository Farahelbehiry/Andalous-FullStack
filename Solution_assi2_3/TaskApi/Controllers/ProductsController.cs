using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;


namespace TaskApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")] //https://localhost:7109/api/Products
    public class ProductsController : ControllerBase
    {
        private static readonly List<Products> _products = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _products.FirstOrDefault(t => t.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Products product)
        {
            _products.Add(product);
            return CreatedAtAction(nameof(GetById),new {id=product.Id },product);
        }

        [HttpPut("{id}")]
        public IActionResult Update (int id,Products updatedproduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }

            product.Name = updatedproduct.Name;
            product.Price = updatedproduct.Price;

            return Ok(product);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
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

            var products = _products.FirstOrDefault(p => p.Id == id);
            if (products == null)
            {
                return NotFound();
            }
            products.Name = product.Name;
            return Ok(products);
        }


    }
}
