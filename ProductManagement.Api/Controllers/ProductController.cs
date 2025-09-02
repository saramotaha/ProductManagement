using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Products.Commands;
using ProductManagement.Application.Products.Queries;
using Microsoft.AspNetCore.Http;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using System.Threading.Tasks;

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _mediator.Send(new GetAllProductsQuery());
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
                if (product == null)
                    return NotFound(new { Message = $"Product with Id {id} not found." });

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var createdProduct = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // PUT: api/Product
        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] UpdateProductCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedProduct = await _mediator.Send(command);
                if (updatedProduct == null)
                    return NotFound(new { Message = $"Product with Id {command.Id} not found." });

                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                Product? result = await _mediator.Send(new DeleteProductCommand { Id = id });
                if (result == null)
                {
                    return NotFound(new { Message = $"Product with Id {id} not found." });
                }

                return NoContent(); // HTTP 204
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
            }
        }
    }

}

