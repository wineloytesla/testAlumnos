using System.Collections.Generic;
using System.Data;
using testWebapi.Models.Request;

namespace testWebapi.Repository
{
  public static class AlumnoRepository
  {
    public static int InsertAlumno(AlumnoResponse alumno)
    {
      string sql = $"insert into Alumnos(NoControl, Nombre, apellidos, Telefono) VALUES ('{alumno.NoControl}', '{alumno.Nombre}', '{alumno.Apellidos}', '{alumno.Telefono}'); SELECT SCOPE_IDENTITY() as IdAlumno;";
      DataTable idAlumno = General.ML().ConsultarDT(sql);
      string idalumno2 = string.Empty;

      if (idAlumno?.Rows.Count > 0)
      {
        idalumno2 = idAlumno.Rows[0]["IdAlumno"].ToString();
      }

      return int.Parse(idalumno2);
    }

    /// <summary>
    /// Obten un listado de los alumnos de base de datos
    /// </summary>
    /// <returns>Lista de alumnos</returns>
    public static List<AlumnoResponse> GetAlumnos()
    {
      string sql = "select  NoControl, Nombre, apellidos, Telefono from Alumnos;";
      DataTable DTAlumnos = General.ML().ConsultarDT(sql);
      List<AlumnoResponse> alumnos = new List<AlumnoResponse>();

      //Valido que mi lista de alumnos no sea nula
      if (DTAlumnos?.Rows.Count > 0)
      {
        for(int i = 0; i < DTAlumnos.Rows.Count; i++)
        {
          alumnos.Add(new AlumnoResponse()
          {
            NoControl = DTAlumnos.Rows[i]["NoControl"].ToString(),
            Nombre = DTAlumnos.Rows[i]["Nombre"].ToString(),
            Apellidos = DTAlumnos.Rows[i]["Apellidos"].ToString(),
            Telefono = DTAlumnos.Rows[i]["Telefono"].ToString()
          });
        }
      }

      return alumnos;

    }
  }
}
