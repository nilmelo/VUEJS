using Microsoft.AspNetCore.Mvc;

namespace ProjetoEscolar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        public StudentController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{ProfessorId}")]
        public IActionResult Get(int professorId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{ProfessorId}")]
        public IActionResult Put(int professorId)
        {
            return Ok();
        }

        [HttpDelete("{ProfessorId}")]
        public IActionResult Delete(int professorId)
        {
            return Ok();
        }
    }
}