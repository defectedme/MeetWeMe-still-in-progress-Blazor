using MeetWeMe.Model;

namespace MeetWeMe.Web.Services
{
    public interface ICategoriesServices
    {
        Task<IEnumerable<Categories>> GetCategories();
        Task<Categories> GetCategoriesById(int catId);

    }
}
