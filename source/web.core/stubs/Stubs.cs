using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using code.api.v1.people.list.get;
using code.prep.people;
using code.test_utilities;
using code.web.adapters;
using Newtonsoft.Json;

namespace code.web.core.stubs
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

    public static IFetchDataUsingTheRequest<IEnumerable<Person>> dummy_list_of_people = x => Factories.generate(200, 
      y => Factories.create_person());
      

    public static ISendResponsesToTheClient dummy_response_engine()
    {
      return new StubResponseEngine();
    }
  }

  public class StubResponseEngine : ISendResponsesToTheClient
  {
    public void send<Data>(Data data)
    {
      var context = HttpContext.Current;
      context.Response.ContentType = "application/json";
      var serialize = new JsonSerializer();

      using (var writer = new JsonTextWriter(new StreamWriter(context.Response.OutputStream)))
      {
        serialize.Serialize(writer, data);
      }
    }
  }

  public class StubRequest : IProvideDetailsAboutAWebRequest
  {

  }
}