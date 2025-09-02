using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Categories.Commands;
using ProductManagement.Application.Categories.Queries;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Data;
using System.Threading.Tasks;

namespace ProductManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMediator mediatR;

        public CategoryController(ICategoryRepository categoryRepository , IMediator mediatR)
        {
            this.categoryRepository = categoryRepository;
            this.mediatR = mediatR;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            //List<Category> categories= await  categoryRepository.GetAllAsync();
          var categories=  await mediatR.Send(new GetAllCategoriesQuery());
          return Ok(categories);

        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryById(int id)
        {
          Category category = await mediatR.Send(new DeleteCategoryCommand() { Id = id });

           //Category category=  await categoryRepository.DeleteAsync(id);
           return Ok(category);

        }



    }
}
