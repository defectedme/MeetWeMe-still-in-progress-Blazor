using MeetWeMe.Model;

namespace MeetWeMe.Api.Models
{
    public interface ICategoriesRepository
    {

        Task<IEnumerable<Categories>> GetCategories();
        Task<Categories> GetCategoriesById(int departmentId);
    }
}
