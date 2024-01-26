using Practice.Data;
using Practice.Models;
using Practice.Repository.IRepository;
using System.Linq.Expressions;

namespace Practice.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        { 
            _context = applicationDbContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category product)
        {
            _context.Update(product);
        }
    }
}
