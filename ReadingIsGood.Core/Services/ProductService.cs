using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Core.Data;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.DBEntities.Authentication;
using ReadingIsGood.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Services
{
    public class ProductService : IProductService
    {
        private IRepository<ProductCategory> _repositoryProductCategory;
        private IRepository<Product> _repositoryProduct;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductService(IRepository<Product> repositoryProduct,
            IRepository<ProductCategory> repositoryProductCategory,
            UserManager<ApplicationUser> userManager)
        {
            _repositoryProduct = repositoryProduct;
            _repositoryProductCategory = repositoryProductCategory;
            _userManager = userManager;
        }

        public Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            return _repositoryProduct.AddAsync(product, cancellationToken);
        }

        public Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            return _repositoryProduct.UpdateAsync(product, cancellationToken);
        }

        public Task DeleteAsync(Product product, CancellationToken cancellationToken = default)
        {
            return _repositoryProduct.DeleteAsync(product, cancellationToken);
        }

        public Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _repositoryProduct.GetByIdAsync(id, cancellationToken);
        }

        public Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _repositoryProduct.ListAsync(cancellationToken);
        }

        public Task<List<ProductCategory>> GetCategoryAllAsync(CancellationToken cancellationToken = default)
        {
            return _repositoryProductCategory.ListAsync(cancellationToken);
        }

        public Task<ProductCategory> AddCategoryAsync(ProductCategory productCategory, CancellationToken cancellationToken = default)
        {
            return _repositoryProductCategory.AddAsync(productCategory, cancellationToken);
        }

        public Task<List<Product>> GetByIdAsync(int[] id, CancellationToken cancellationToken = default)
        {
            return _repositoryProduct.Table.Where(m => id.Contains(m.Id)).ToListAsync();
        }

        //public bool CheckProductQuantity(List<Product> products, CancellationToken cancellationToken = default)
        //{

        //    bool isNotAvailable = _repositoryProduct
        //        .Table
        //        .Where(m => products.Any(local => local.Id == m.Id 
        //               && local.Quantity <= 0)).Any();

        //    return isNotAvailable;
        //}
    }
}
