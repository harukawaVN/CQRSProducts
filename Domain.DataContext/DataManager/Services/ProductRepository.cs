using Domain.DataContext.DataManager.Models;
using Domain.DataContext.DataManager.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DataContext.DataManager.Services
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(DataContext dataContext) : base(dataContext) { }
        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await FindAll()
                        .OrderBy(p => p.Name)
                        .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await FindByCondition(product => product.Id.Equals(productId))
                        .FirstOrDefaultAsync();
        }

        /*public async Task<PagedList<Product>> GetProductsAsync(ProductParameters productParameters)
        {
            var products = FindAll();

            SearchByName(ref products, productParameters.Name);

            var sorderProducts = _productSortHelper.ApplySort(products, productParameters.OrderBy);

            return await PagedList<Product>.ToPagedList(sorderProducts, productParameters.PageNumber, productParameters.PageSize);
        }*/

        private void SearchByName(ref IQueryable<Product> products, string productName)
        {
            if (!products.Any() || string.IsNullOrWhiteSpace(productName))
                return;

            products = products.Where(o => o.Name.ToLower().Contains(productName.Trim().ToLower()));
        }

        public async Task<Product> GetProductWithDetailsAsync(Guid productId)
        {
            return await FindByCondition(product => product.Id.Equals(productId))
                        .Include(ac => ac.ProductCategories)
                        .ThenInclude(x => x.Category)
                        .FirstOrDefaultAsync();
        }
    }
}
