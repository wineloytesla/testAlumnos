using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testWebapi.Models.Request;
using testWebapi.Repository;

namespace testWebapi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsuariosController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetUsuarios()
    {
      return Ok(AlumnoRepository.GetAlumnos());
    }
    [HttpGet("[action]")]
    public IActionResult GetCarrera()
    {
      return Ok("Informatica");
    }

    [HttpPost]
    public IActionResult GetCarreraPost()
    {
      return Ok("Informatica");
    }
    [HttpPost("[action]")]
    public IActionResult InsertStudent([FromBody] AlumnoResponse alumno)
    {
      var idAlumno = AlumnoRepository.InsertAlumno(alumno);

      return Ok(alumno);
    }
  }
}
