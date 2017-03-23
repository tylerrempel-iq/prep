using System.Data;

namespace code.data.core
{
  public interface IRunAQuery<QueryResult>
  {
    void prepare(IDbCommand command);
  }
}