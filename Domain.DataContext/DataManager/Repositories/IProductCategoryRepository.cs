using Domain.DataContext.DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DataContext.DataManager.Repositories
{
    public interface IProductCategoryRepository : IRepositoryBase<ProductCategory>
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync();
        Task<ProductCategory> GetProductCategoriesAsync(Guid productId, Guid categoryId);
        void CreateProductCategory(ProductCategory productCategory);
        void UpdateProductCategory(ProductCategory productCategory);
        void DeleteProductCategory(ProductCategory productCategory);
    }
}
