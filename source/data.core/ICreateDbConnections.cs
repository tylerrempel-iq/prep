using System.Data;

namespace code.data.core
{
  public interface ICreateDbConnections
  {
    IDbConnection create();
  }

}