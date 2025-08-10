using BulkyWeb.Models;

namespace BulkyWeb.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
        void Save(Product product);
    }
}
