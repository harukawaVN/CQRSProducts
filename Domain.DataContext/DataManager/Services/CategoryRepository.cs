using Domain.DataContext.DataManager.Models;
using Domain.DataContext.DataManager.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DataContext.DataManager.Services
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext dataContext) : base(dataContext) { }
        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }

        public void UpdateCategory(Category category)
        {
            Update(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await FindAll().OrderBy(p => p.Name)
                        .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            return await this.DataContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        /*public async Task<PagedList<Tag>> GetTagsAsync(TagParameters tagsParameters)
        {
            var tags = FindAll();

            SearchByName(ref tags, tagsParameters.Name);

            var sortedTags = _sortHelper.ApplySort(tags, tagsParameters.OrderBy);

            return await PagedList<Tag>.ToPagedList(sortedTags, tagsParameters.PageNumber, tagsParameters.PageSize);
        }*/

        private void SearchByName(ref IQueryable<Category> categories, string categoryName)
        {
            if (!categories.Any() || string.IsNullOrWhiteSpace(categoryName))
                return;

            categories = categories.Where(o => o.Name.ToLower().Contains(categoryName.Trim().ToLower()));
        }

        public async Task<Category> GetTagWithDetailsAsync(Guid categoryId)
        {
            return await FindByCondition(Cat => Cat.Id == categoryId)
                        .Include(ac => ac.ProductCategories)
                        .ThenInclude(ac => ac.Product)
                        .FirstOrDefaultAsync();
        }
    }
}
