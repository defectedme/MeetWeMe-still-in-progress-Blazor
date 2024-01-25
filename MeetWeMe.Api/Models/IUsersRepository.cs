using MeetWeMe.Model;

namespace MeetWeMe.Api.Models
{
    public interface IUsersRepository
    {

        Task<IEnumerable<Users>> Search(string? name, Gender? gender);

        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUserById(int userId);
        Task<Users> GetUserByEmail(string email);

        Task<Users> AddUser(Users user);
        Task<Users> UpdateUser(Users user);
        Task<Users> DeleteUser(int id);


    }
}
