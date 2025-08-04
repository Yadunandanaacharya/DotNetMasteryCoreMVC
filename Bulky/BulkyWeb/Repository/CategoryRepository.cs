using System.Linq.Expressions;
using BulkyWeb.Data;
using BulkyWeb.Models;
using BulkyWeb.Repository.IRepository;

namespace BulkyWeb.Repository
{
    public class CategoryRepository :  Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save(Category category)
        {
            _db.SaveChanges();
        }

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
