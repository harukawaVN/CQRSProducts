using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DataContext.DataManager.Repositories
{
    interface IRepositoryWrapper
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IProductCategoryRepository ProductCategories { get; }
        Task SaveAsync();
    }
}
