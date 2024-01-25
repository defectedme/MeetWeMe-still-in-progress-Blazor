using MeetWeMe.Model;

namespace MeetWeMe.Web.Services
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly HttpClient _httpClient;
        public CategoriesServices(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }


        public async Task<IEnumerable<Categories>> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<Categories[]>("/api/Categories");
        }

        public async Task<Categories> GetCategoriesById(int catId)
        {
            return await _httpClient.GetFromJsonAsync<Categories>($"api/Categories/{catId}");
        }
    }
}
