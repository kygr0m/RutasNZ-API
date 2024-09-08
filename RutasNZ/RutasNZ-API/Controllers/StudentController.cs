using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RutasNZ_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet]

        public IActionResult GetAllStudents()
        {
            string[] students = new string[] { "Paco", "Pepo", "Tere"};
            return Ok(students);
        }
    }
}
