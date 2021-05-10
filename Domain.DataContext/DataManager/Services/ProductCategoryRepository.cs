using Domain.DataContext.DataManager.Models;
using Domain.DataContext.DataManager.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DataContext.DataManager.Services
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(DataContext dataContext) : base(dataContext) { }
        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync() {
            return await FindAll()
                        .Include(x => x.Product)
                        .Include(x => x.Category)
                        .ToListAsync();
        }
        public async Task<ProductCategory> GetProductCategoriesAsync(Guid productId, Guid categoryId) {
            return await FindByCondition(m => m.ProductId.Equals(productId) && m.CategoryId.Equals(categoryId))
                        .FirstOrDefaultAsync();
        }
        public void CreateProductCategory(ProductCategory productCategory) 
        {
            Create(productCategory);
        }
        public void UpdateProductCategory(ProductCategory productCategory) 
        {
            Update(productCategory);
        }
        public void DeleteProductCategory(ProductCategory productCategory) 
        {
            Delete(productCategory);
        }
    }
}
