using MeetWeMe.Model;

namespace MeetWeMe.Web.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly HttpClient _httpClient;


        private readonly IConfiguration _config;


        public UsersServices(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _httpClient.GetFromJsonAsync<Users[]>("/api/User");
        }


        public async Task DeleteUser(int id)
        {

            await _httpClient.DeleteAsync($"api/User/{id}");


        }

        public async Task<Users> GetUserById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Users>($"api/User/{id}");

        }



        public async Task<Users> UpdateUser(Users user)
        {


            var response = await _httpClient.PutAsJsonAsync<Users>("api/User", user);
            return await response.Content.ReadFromJsonAsync<Users>();
        }

        public async Task<Users> CreateUser(Users user)
        {


            var response = await _httpClient.PostAsJsonAsync<Users>("api/User", user);
            return await response.Content.ReadFromJsonAsync<Users>();



        }


    }
}
