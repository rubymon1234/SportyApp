namespace SportyApp.Models.Repository.IRepository
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAll();
        Task<Products> GetFindById(int id);
        Task UpdateById(Products entity);
        Task Create(Products entity);
        Task Delete(Products entity);
        Task Save();

        bool isRecordExist(string name);
    }
}
