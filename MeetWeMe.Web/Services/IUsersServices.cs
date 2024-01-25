using MeetWeMe.Model;

namespace MeetWeMe.Web.Services
{
    public interface IUsersServices
    {

        Task<IEnumerable<Users>> GetUsers();

        Task DeleteUser(int id);

        Task<Users> GetUserById(int id);

        Task<Users> UpdateUser(Users user);

        Task<Users> CreateUser(Users user);









    }
}
