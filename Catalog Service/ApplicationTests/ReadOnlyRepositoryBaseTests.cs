using OnlineShopping.CatalogService.Application.Common.Models;
using OnlineShopping.CatalogService.Domain.Enteties;

namespace ApplicationTests
{
    public class ReadOnlyRepositoryBaseTests
    {
        [Test]
        public async Task TryGetAsyncTest()
        {
            var categoryName = "New Category";
            var categoryId = 54;

            var q = new List<Category>() { new Category { Id = categoryId, Name = categoryName } }.AsQueryable();

            var repository = new ReadOnlyRepositoryBase<Category>(q);

            var category = await repository.TryGetAsync(categoryId);

            Assert.That(category, Is.Not.Null);
            Assert.That(categoryId, Is.EqualTo(category.Id));
            Assert.That(categoryName, Is.EqualTo(category.Name));
        }
    }
}