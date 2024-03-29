﻿using Food.API.DTO.Products;
using Food.API.Models.Products;
using Food.API.Service.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<PaginatedReturn> GetProducts(
            [FromQuery] string? barCode,
            [FromQuery] string? name,
            [FromQuery] int? page)
        {
            var products = _productService.GetAll(barCode, name, page ?? 0);

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Product?> GetProduct(int id) {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return BadRequest("Product not found");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<int>> NewProduct([FromBody] AddProductDTO dto)
        {
            try
            {
                await _productService.Create(dto);

                return NoContent();

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] EditProductDTO product)
        {
            try
            {
                await _productService.Update(id, product);

                return NoContent();

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Product?> DeleteProduct(int id)
        {
            try
            {
                _productService.Delete(id);

                return NoContent();

            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
