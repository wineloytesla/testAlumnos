using DarkSoft.SQL;

namespace testWebapi.Repository
{
  public static class General
  {
    public static Conexion ML()
    {
      return new Conexion("TESTALUMNOS", "201.159.38.50", "DeSoftv", "1975huli");
    }
  }
}
