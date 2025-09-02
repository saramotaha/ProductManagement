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

        public async Task<Product> DeleteAsync(int id)
        {
            Product p = await dbContext.Products.SingleOrDefaultAsync(p=>p.Id == id);
            dbContext.Products.Remove(p);
            return p;
        }

        public async Task<List<Product>> GetAllAsync()
        {
          List<Product> products = await dbContext.Products.ToListAsync();
          return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
           Product p =  await dbContext.Products.SingleOrDefaultAsync(p=>p.Id == id);
           return p;
        }

        public async Task<int> SaveAsync()
        {
          int x =  await dbContext.SaveChangesAsync();
          return x; 
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            return entity;
        }



        public async Task<List<Product>> GetProductsByCategoryId(int id)
        {
          List<Product> products = await  dbContext.Products.Where(p=>p.CategoryId == id).ToListAsync();   
            return products;
        }
    }
}
