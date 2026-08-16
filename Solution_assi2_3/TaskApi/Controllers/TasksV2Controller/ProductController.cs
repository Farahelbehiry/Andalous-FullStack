using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskApi.Models;
using TaskApi.Services.Interfaces;

namespace TaskApi.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("/api/v{version:apiversion}/[Controller]")] //https://localhost:7109/api/Products
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var product = _productService.GetAll().Select(p => new
            {
                id = p.Id,
                name = p.Name,
                priceAmount = p.Price,
                currency = "USD",
                createdAt = DateTime.UtcNow
            });

            return Ok(product);
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return null;
            return Ok(new { Id = id, Name = product.Name, Price = product.Price, PType = "EGP", CreatedAt = DateTime.UtcNow });

        }




    }
}
