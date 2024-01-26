using Practice.Data;
using Practice.Models;
using Practice.Repository.IRepository;
using System.Linq.Expressions;

namespace Practice.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        { 
            _context = applicationDbContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}
