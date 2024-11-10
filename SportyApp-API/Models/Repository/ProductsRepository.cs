using Microsoft.EntityFrameworkCore;
using SportyApp.Data;
using SportyApp.Models.Repository.IRepository;
using System.Linq;

namespace SportyApp.Models.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductsRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<List<Products>> GetAll()
        {
            List<Products> products = await _dbContext.Products.ToListAsync();
            return products;
        }
        public async Task<Products> GetFindById(int id)
        {
            var produts = await _dbContext.Products.FindAsync(id);
            return produts;
        }
        public async Task UpdateById(Products entity)
        {
            _dbContext.Products.Update(entity);
            await Save();
        }
        public bool isRecordExist(string title)
        {
            var result = _dbContext.Products.AsQueryable().Where(x => x.Title == title).Any();
            return result;
        }
        public async Task Create(Products entity)
        {
            await _dbContext.Products.AddAsync(entity);
            await Save();
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Products product)
        {
            _dbContext.Products.Remove(product);
            await Save();
        }
    }
}

