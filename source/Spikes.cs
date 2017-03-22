using System.Configuration;
using System.Data;
using Machine.Specifications;
using MySql.Data.MySqlClient;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code
{
  public class Spikes
  {
    public abstract class concern : spec.observe
    {
    }

    public class connecting_to_a_mysql_database_running_in_a_container : concern
    {
      It works = () =>
      {
        var table = new DataTable();
        using (var connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["code"].ConnectionString))
        using (var command = connection.CreateCommand())
        {
          command.CommandType = CommandType.Text;
          command.CommandText = "select * from people";
          connection.Open();
          using (var reader = command.ExecuteReader())
          {
            table.Load(reader);
          }

          table.Rows.Count.ShouldBeGreaterThan(0);
        }
      };
    }
  }
}