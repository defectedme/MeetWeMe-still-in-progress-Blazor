using MeetWeMe.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace MeetWeMe.Api.Models
{
    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext _appDbContext;

        public UsersRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Users> AddUser(Users user)
        {
            var result = await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Users> DeleteUser(int id)
        {

            var result = await _appDbContext.Users.FirstOrDefaultAsync(e => e.UserId == id);

            var filePath = result.PhotoPath;

            if (result != null)
            {
                //System.IO.File.Delete(@$"C:\Users\defected\source\repos\BlazorMeetWeMe\MeetWeMe\MeetWeMe.Web\wwwroot\{filePath}");
                System.IO.File.Delete(@$"../MeetWeMe.Web/wwwroot/{filePath}");


               

                _appDbContext.Users.Remove(result);

                await _appDbContext.SaveChangesAsync();


                return result;
            }
    

            return null;
        }

        public async Task<Users> GetUserById(int userId)
        {
            var result = await _appDbContext.Users.Include(e => e.Categories)
                .FirstOrDefaultAsync(e => e.UserId == userId);
            return result;


        }

        public Task<Users> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _appDbContext.Users.OrderByDescending(p => p.DateOfBirth).ToListAsync();
        }

        public async Task<IEnumerable<Users>> Search(string? name, Gender? gender)
        {
            IQueryable<Users> query = _appDbContext.Users;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.NickName.Contains(name)
                            || e.NickName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }



        public async Task<Users> UpdateUser(Users user)
        {

            var result = await _appDbContext.Users.FirstOrDefaultAsync(e => e.UserId == user.UserId);
            var date = DateTime.Now;
            var filePath = result.PhotoPath;

            if (result != null)
            {

                if (filePath != null)
                {
                    //System.IO.File.Delete(@$"C:\Users\defected\source\repos\BlazorMeetWeMe\MeetWeMe\MeetWeMe.Web\wwwroot\{filePath}");
                    System.IO.File.Delete(@$"../MeetWeMe.Web/wwwroot/{filePath}");

                    //result.PhotoPath = user.PhotoPath;

                }


                result.FirstName = user.FirstName;
                result.NickName = user.NickName;
                result.Email = user.Email;
                result.DateOfBirth = date;
                result.DateOfMeeting = user.DateOfMeeting;
                result.LocationName = user.LocationName;
                result.Message = user.Message;
                result.City = user.City;
                result.Gender = user.Gender;
                result.CategoriesId = user.CategoriesId;
                result.PhotoPath = user.PhotoPath;

                await _appDbContext.SaveChangesAsync();
                return result;


            }
            return null;
        }


    }
}
