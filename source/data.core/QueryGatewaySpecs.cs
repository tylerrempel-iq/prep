using System.Data;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.data.core
{
  [Subject(typeof(QueryGateway))]
  public class QueryGatewaySpecs
  {
    public abstract class concern : spec.observe<QueryGateway>
    {
    }

    public class when_told_to_run_a_query : concern
    {
      Establish c = () =>
      {
        db_connection_factory = depends.on<ICreateDbConnections>();
        mapper = depends.on<IMap>();
        query = fake.an<IRunAQuery<SomeItem>>();
        connection = fake.an<IDbConnection>();
        reader = fake.an<IDataReader>();
        mapped_item = new SomeItem();
        command = fake.an<IDbCommand>();
        db_connection_factory.setup(x => x.create()).Return(connection);
        connection.setup(x => x.CreateCommand()).Return(command);

        command.setup(x => x.ExecuteReader(CommandBehavior.CloseConnection)).Return(reader);
        mapper.setup(x => x.from<IDataReader,SomeItem>(reader)).Return(mapped_item);

      };

      Because b = () =>
        result = sut.run(query);

      It opens_the_connection = () =>
        connection.should().received(x => x.Open());

      It tells_the_query_object_to_prepare_the_command = () =>
        query.should().received(x => x.prepare(command));

      It returns_the_result_mapped_by_the_mapper_for_the_result = () =>
        result.ShouldEqual(mapped_item);

      static ICreateDbConnections db_connection_factory;
      static IRunAQuery<SomeItem> query;
      static IDbConnection connection;
      static IDbCommand command;
      static SomeItem result;
      static IDataReader reader;
      static SomeItem mapped_item;
      static IMap mapper;
    }

    public class SomeItem
    {
    }
  }
}