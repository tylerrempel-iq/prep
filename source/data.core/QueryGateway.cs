using System.Data;

namespace code.data.core
{
  public class QueryGateway
  {
    ICreateDbConnections db_connection_factory;
    IMap mapper;

    public QueryGateway(ICreateDbConnections db_connection_factory, IMap mapper)
    {
      this.db_connection_factory = db_connection_factory;
      this.mapper = mapper;
    }

    public QueryResult run<QueryResult>(IRunAQuery<QueryResult> query)
    {
      using (var connection = db_connection_factory.create())
      using (var command = connection.CreateCommand())
      {
        query.prepare(command);
        connection.Open();
        return mapper.from<IDataReader, QueryResult>(command.ExecuteReader(CommandBehavior.CloseConnection));
      }
    }
  }
}