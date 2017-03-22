using System.Web;

namespace code.web
{
  public delegate IProvideDetailsAboutAWebRequest ICreateARequestFromAnASPNetRequest(HttpContext request);
}