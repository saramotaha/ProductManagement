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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public Task<List<Category>> GetAllAsync()
        {
           return dbContext.Categories.ToListAsync(); 
        }


        
        public async Task<Category> DeleteAsync(int id)
        {

          Category category= await  dbContext.Categories.SingleOrDefaultAsync(c=> c.Id == id);
           dbContext.Categories.Remove(category);
           await SaveAsync();
           return category;

        }


        public async Task<int> SaveAsync()
        {
            int changes=   await dbContext.SaveChangesAsync();
            return changes;
        }




        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
