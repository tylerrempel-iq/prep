using System;
using System.Collections.Generic;
using System.Linq;
using code.prep.people;
using code.web.features.list_people;

namespace code.web.stubs
{
  public class Stubs
  {
    public static ICreateARequestFromAnASPNetRequest aspnet_request_builder = x => new StubRequest();

    public static ICreateAMissingCommandWhenOneCantBeFound missing_request_builder = delegate
    {
      throw new NotImplementedException("You dont have a handler for this feature");
    };

    public static IEnumerable<IHandleOneWebRequest> dummy_set_of_handlers()
    {
      yield return new RequestHandler(x => true, new Handler());
    }

    public static IFetchDataUsingTheRequest<IEnumerable<Person>> dummy_list_of_people = x =>
      Enumerable.Range(1, 100).Select(y => new Person());

    public static ISendResponsesToTheClient dummy_response_engine()
    {
      return new StubResponseEngine();
    }
  }

  public class StubResponseEngine : ISendResponsesToTheClient
  {
    public void send(IEnumerable<Person> data)
    {
      //      HttpContext.Current.Response
    }
  }

  public class StubRequest : IProvideDetailsAboutAWebRequest
  {

  }
}