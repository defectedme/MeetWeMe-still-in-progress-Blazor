using MeetWeMe.Api.Models;
using MeetWeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MeetWeMe.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IWebHostEnvironment _env;


        public UserController(IUsersRepository usersRepository, IWebHostEnvironment env)
        {
            _usersRepository = usersRepository;
            _env = env;

        }


        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Users>>> Search(string? name, Gender? gender)
        {
            try
            {
                var result = await _usersRepository.Search(name, gender);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await _usersRepository.GetUsers());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "error get data from database");
            }
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {

            try
            {
                var user = await _usersRepository.GetUserById(id);

                if (user == null)
                {
                    return NotFound(); // Return 404 Not Found if user with the given ID is not found
                }

                return Ok(user); // Return the user object with a 200 OK response

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");

            }

        }



        [HttpPost]
        public async Task<ActionResult<Users>> AddUser(Users users)
        {
            try
            {
                if (users == null)
                {
                    return BadRequest();
                }

                var createUser = await _usersRepository.AddUser(users);
                return CreatedAtAction(nameof(GetUserById), new { id = createUser.UserId }, createUser);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "error retrieving data fro the database");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {

            try
            {
                var deletUser = await _usersRepository.GetUserById(id);
                if (deletUser == null)
                {
                    return NotFound($"Employ with id = {id} not found");
                }

                return await _usersRepository.DeleteUser(id);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the databse");
            }

        }

        [HttpPut]
        public async Task<ActionResult<Users>> UpdateUser(Users users)
        {

            try
            {
                var userToUpdate = await _usersRepository.GetUserById(users.UserId);

                if (userToUpdate == null)


                    return NotFound($"User with id: {users.UserId} not found");




                return await _usersRepository.UpdateUser(users);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error updating data");
            }


        }




    }
}
