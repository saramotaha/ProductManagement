using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Products.Commands;
using ProductManagement.Application.Products.Queries;
using ProductManagement.Domain.Entities;
using System.Threading.Tasks;

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMediator mediatR;

        public ProductController(IProductRepository productRepository , IMediator mediatR)
        {
            this.productRepository = productRepository;
            this.mediatR = mediatR;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            //List<Product> products = await  productRepository.GetAllAsync();

            var products = await mediatR.Send(new GetAllProductsQuery());

            return Ok(products);    
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await mediatR.Send(new GetProductByIdQuery() {Id=id });

            return Ok(product);
        }




        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand command)
        {

           var x = await  mediatR.Send(command);
            //Product x = await productRepository.AddAsync(product);
            return Ok(x);
        }




        [HttpPut]
        public async Task<IActionResult> EditProduct(UpdateProductCommand product)
        {
            var x = await mediatR.Send(product);
            //Product product1 = await productRepository.UpdateAsync(product);
            return Ok(x);
        }



        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand deleteProduct)
        {

            //Product product1 = await productRepository.DeleteAsync(id);
            var product1 = await mediatR.Send(deleteProduct);

            return Ok(product1);


        }










    }
}
