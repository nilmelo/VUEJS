using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoEscolar.WebAPI.Data;
using ProjetoEscolar.WebAPI.Models;

namespace ProjetoEscolar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IRepository _repo;

        public StudentController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllStudentsAsync(true);
                return Ok(result);  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }

        [HttpGet("{StudentId}")]
        public async Task<IActionResult> GetByStudentId(int StudentId)
        {
             try
            {
                var result = await _repo.GetStudentAsyncById(StudentId, true);
                return Ok(result);  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }

        [HttpGet("ByProfessor/{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorId(int ProfessorId)
        {
             try
            {
                var result = await _repo.GetStudentsAsyncByProfessorId(ProfessorId, true);
                return Ok(result);  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/student/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }

            return BadRequest();
        }

        [HttpPut("{StudentId}")]
        public async Task<IActionResult> Put(int StudentId, Student model)
        {
             try
            {
                var student = await _repo.GetStudentAsyncById(StudentId, false);
                if (student == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    student = await _repo.GetStudentAsyncById(StudentId, true);
                    return Created($"/api/student/{model.Id}", student);
                }  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }

            return BadRequest();
        }

        [HttpDelete("{StudentId}")]
        public async Task<IActionResult> Delete(int StudentId)
        {
             try
            {
                var student = await _repo.GetStudentAsyncById(StudentId, false);
                if (student == null) return NotFound();
                
                _repo.Delete(student);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }  
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "[ERROR_DB] Falha na conexão");
            }
            
            return BadRequest();
        }
    }
}