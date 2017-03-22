using System.Collections.Generic;
using code.prep.people;

namespace code.web.features.list_people
{
  public interface ISendResponsesToTheClient
  {
    void send(IEnumerable<Person> data);
  }
}