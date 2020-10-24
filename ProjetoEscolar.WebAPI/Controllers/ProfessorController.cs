using Microsoft.AspNetCore.Http;
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
             try
            {
                return Ok();  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }

        [HttpGet("{StudentId}")]
        public IActionResult Get(int studentId)
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

        [HttpPut("{StudentId}")]
        public IActionResult Put(int studentId)
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

        [HttpDelete("{StudentId}")]
        public IActionResult Delete(int studentId)
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