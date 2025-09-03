using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);

            return  entity;
        }

        
        public async Task<List<Product>> GetAllAsync()
        {
          List<Product> products = await dbContext.Products.ToListAsync();
          return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
           Product product =  await dbContext.Products.SingleOrDefaultAsync(p=>p.Id == id);
           return product;
        }


        public async Task<List<Product>> GetProductsByCategoryId(int id)
        {
            List<Product> products = await dbContext.Products.Where(p => p.CategoryRef == id).ToListAsync();
            return products;
        }
        

        public async Task<Product> UpdateAsync(Product entity)
        {
            var existingProduct = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == entity.Id);
            if (existingProduct == null)
                return null;

            existingProduct.Name = entity.Name;
            existingProduct.Description = entity.Description;
            existingProduct.Price = entity.Price;
            existingProduct.StockQuantity = entity.StockQuantity;
            existingProduct.CategoryRef = entity.CategoryRef;
            existingProduct.UpdatedAt = entity.UpdatedAt;

            return existingProduct;
        }



        



        public async Task<Product?> DeleteAsync(int id)
        {

            Product? product = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (product == null)
                   return null;

            dbContext.Products.Remove(product);
            return product;
        }


        public async Task<int> SaveAsync()
        {
            int x = await dbContext.SaveChangesAsync();
            return x;
        }

    }
}
