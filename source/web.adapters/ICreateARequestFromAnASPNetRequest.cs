using System.Web;
using code.web.core;

namespace code.web.adapters
{
  public delegate IProvideDetailsAboutAWebRequest ICreateARequestFromAnASPNetRequest(HttpContext request);
}