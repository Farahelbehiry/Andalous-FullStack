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
            _products.Add(product);
           return CreatedAtAction(nameof(GetById),new {id=product.Id },product);
        }

        [HttpPut("{id}")]
        public IActionResult Update (int id,Products updatedproduct)
        {
            Products product = null;
            foreach (var p in _products)
            {
                if (p.Id == id)
                {
                    product = p;
                    break;
                }
            }
            if (product == null)
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
            Products product = null;
            foreach (var p in _products)
            {
                if (p.Id == id)
                {
                    product = p;
                    break;
                }
            }
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

            Products products = null;
            foreach (var p in _products)
            {
                if (p.Id == id)
                {
                    products = p;
                    break;
                }
            }
            if (products == null)
            {
                return NotFound();
            }
            products.Name = product.Name;
            return Ok(products);
        }
    }
}