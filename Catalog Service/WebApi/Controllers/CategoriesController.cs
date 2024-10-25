using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.CatalogService.Domain.Enteties;
using OnlineShopping.CatalogService.Infrastructure.Data;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController(ApplicationDbContext applicationDbContext,
        ILogger<CategoriesController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await applicationDbContext.Categories.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category = await applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                return Ok(category);
            }

            return NotFound();
        }


        [HttpPut]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            await applicationDbContext.Categories.AddAsync(new Category { Name = categoryDto.Name, Image = categoryDto.Image, ParentCategoryId = categoryDto.ParentCategoryId });
            applicationDbContext.SaveChanges();

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            var category = await applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == categoryDto.Id);
            if (category != null)
            {
                applicationDbContext.SaveChanges();
            }

            return NotFound();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category != null)
            {
                applicationDbContext.Categories.Remove(category);
                applicationDbContext.SaveChanges();

                return Ok();
            }

            return NotFound();
        }
    }

    public class CategoryDto
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public string? Image { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
