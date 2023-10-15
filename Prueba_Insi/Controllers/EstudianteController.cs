using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using Prueba_Insi.Models;
using AutoMapper;
using System;

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

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Lista de estudiantes", response = lista });

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

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Estudiante encontrado", response = oEstudiante });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("Guardar")]

        public IActionResult Guardar([FromBody] Estudiante objeto)
        {
            try
            {
                _dbcontext.Estudiantes.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Estudiante Guardado Correctamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

       

[HttpPut]
    [Route("Editar")]
    public IActionResult Editar([FromBody] Estudiante objeto)
    {
        Estudiante oEstudiante = _dbcontext.Estudiantes.Find(objeto.IdEstudiante);

        if (oEstudiante == null)
        {
            return BadRequest("Estudiante no encontrado");
        }

        // Configurar el mapeo entre Estudiante y el objeto recibido en la solicitud
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Estudiante, Estudiante>();
        });
        var mapper = new Mapper(mapperConfig);

        try
        {
            // Mapear las propiedades del objeto recibido en el objeto Estudiante
            mapper.Map(objeto, oEstudiante);

            _dbcontext.Estudiantes.Update(oEstudiante);
            _dbcontext.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Estudiante editado correctamente" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
        }
    }

        [HttpDelete]
        [Route("Eliminar/{idEstudiante:int}")]
        public IActionResult Eliminar(int idEstudiante)
        {
            Estudiante oEstudiante = _dbcontext.Estudiantes.Find(idEstudiante);
            if (oEstudiante == null)
            {
                return BadRequest("Estudiante no encontrado");
            }

            try
            {
                _dbcontext.Estudiantes.Remove(oEstudiante);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Estudiante eliminado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

    }
}
