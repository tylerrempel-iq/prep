using System.Web;
using code.web.stubs;

namespace code.web
{
  public class ASPNetAdapter : IHttpHandler
  {
    ICreateARequestFromAnASPNetRequest request_builder;
    IProcessWebRequests front_controller;

    public ASPNetAdapter():this(Stubs.aspnet_request_builder, 
      new FrontController())
    {
    }

    public ASPNetAdapter(ICreateARequestFromAnASPNetRequest request_builder, IProcessWebRequests front_controller)
    {
      this.request_builder = request_builder;
      this.front_controller = front_controller;
    }

    public void ProcessRequest(HttpContext context)
    {
      front_controller.run(request_builder(context));
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}