using System;
using System.IO;
using System.Web;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web
{
  [Subject(typeof(ASPNetAdapter))]
  public class ASPNetAdapterSpecs
  {
    public abstract class concern : spec.observe<IHttpHandler, ASPNetAdapter>
    {
    }

    public class when_processing_an_asp_net_request : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessWebRequests>();
        a_request_created_from_the_aspnet_request = fake.an<IProvideDetailsAboutAWebRequest>();
        an_aspnet_request = new HttpContext(new HttpRequest("blah","http://localhost/blah",String.Empty),
          new HttpResponse(new StringWriter()));

        depends.on<ICreateARequestFromAnASPNetRequest>(x =>
        {
          x.ShouldEqual(an_aspnet_request);

          return a_request_created_from_the_aspnet_request;
        });

      };

      Because b = () =>
        sut.ProcessRequest(an_aspnet_request);

      It delegates_the_processing_of_a_new_front_controller_request_to_our_front_controller = () =>
        front_controller.should().received(x => x.run(a_request_created_from_the_aspnet_request));

      static IProcessWebRequests front_controller;
      static IProvideDetailsAboutAWebRequest a_request_created_from_the_aspnet_request;
      static HttpContext an_aspnet_request;
    }
  }
}