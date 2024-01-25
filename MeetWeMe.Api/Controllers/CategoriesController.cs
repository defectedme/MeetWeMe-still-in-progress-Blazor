using MeetWeMe.Api.Models;
using MeetWeMe.Model;
using Microsoft.AspNetCore.Mvc;

namespace MeetWeMe.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }





        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            try
            {
                return Ok(await _categoriesRepository.GetCategories());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "error get data from database");
            }
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categories>> GetCategoriesById(int id)
        {

            try
            {
                var cat = await _categoriesRepository.GetCategoriesById(id);

                if (cat == null)
                {
                    return NotFound(); // Return 404 Not Found if user with the given ID is not found
                }

                return Ok(cat); // Return the user object with a 200 OK response

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the databse");

            }

        }






    }
}
