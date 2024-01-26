using Practice.Models;
namespace Practice.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category product);
        void Save();
    }
}
