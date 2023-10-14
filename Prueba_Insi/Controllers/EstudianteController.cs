using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using Prueba_Insi.Models;

namespace Prueba_Insi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        public readonly PruebaInsiContext _dbcontext;

        public EstudianteController(PruebaInsiContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {
            List<Estudiante> lista = new List<Estudiante>();

            try
            {
                lista = _dbcontext.Estudiantes.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }

        [HttpGet]
        [Route("Obtener/{idEstudiante:int}")]
        public IActionResult Obtener(int idEstudiante)
        {
            try
            {
                Estudiante oEstudiante = _dbcontext.Estudiantes.Find(idEstudiante);

                if (oEstudiante == null)
                {
                    return BadRequest("Estudiante no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oEstudiante });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

    }
}
