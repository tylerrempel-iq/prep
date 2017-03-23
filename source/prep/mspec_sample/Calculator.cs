using System;
using System.Data;
using System.Threading;

namespace code.prep.mspec_sample
{
  public interface ICalculate
  {
    int add(int i, int i1);
    bool disable();
  }

  public class Calculator : ICalculate
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
      this.connection = connection;
    }

    public bool disable()
    {
      return Thread.CurrentPrincipal.IsInRole("Admin");
    }

    public int add(int i, int i1)
    {
      if (i < 0 || i1 < 0) throw new NotImplementedException();
      using (connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        connection.CreateCommand().ExecuteNonQuery();
      }
      return i + i1;
    }
  }
}