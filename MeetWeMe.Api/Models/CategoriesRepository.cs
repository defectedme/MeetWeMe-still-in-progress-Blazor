using MeetWeMe.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetWeMe.Api.Models
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoriesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Categories> GetCategoriesById(int categoriesId)
        {
            var result = await _appDbContext.Categories.FirstOrDefaultAsync(e => e.CategoriesId == categoriesId);
            return result;
        }

        public async Task<IEnumerable<Categories>> GetCategories()
        {
            return await _appDbContext.Categories.ToListAsync();
        }
    }
}
