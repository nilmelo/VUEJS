using Microsoft.AspNetCore.Mvc;

namespace ProjetoEscolar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public ProfessorController()
        {
            
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{StudentId}")]
        public IActionResult Get(int studentId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("{StudentId}")]
        public IActionResult Put(int studentId)
        {
            return Ok();
        }

        [HttpDelete("{StudentId}")]
        public IActionResult Delete(int studentId)
        {
            return Ok();
        }
    }
}