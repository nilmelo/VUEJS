using Microsoft.AspNetCore.Http;
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
            try
            {
                return Ok();  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }

        [HttpGet("{ProfessorId}")]
        public IActionResult Get(int professorId)
        {
             try
            {
                return Ok();  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
             try
            {
                return Ok();  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }

        [HttpPut("{ProfessorId}")]
        public IActionResult Put(int professorId)
        {
             try
            {
                return Ok();  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }

        [HttpDelete("{ProfessorId}")]
        public IActionResult Delete(int professorId)
        {
             try
            {
                return Ok();  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }
    }
}