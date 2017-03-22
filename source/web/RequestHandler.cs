using code.utility.matching;

namespace code.web
{
  public class RequestHandler : IHandleOneWebRequest
  {
    Criteria<IProvideDetailsAboutAWebRequest> request_criteria;
    IImplementAUserStory feature;

    public RequestHandler(Criteria<IProvideDetailsAboutAWebRequest> request_criteria, IImplementAUserStory feature)
    {
      this.request_criteria = request_criteria;
      this.feature = feature;
    }

    public void process(IProvideDetailsAboutAWebRequest request)
    {
      feature.process(request);
    }

    public bool can_process(IProvideDetailsAboutAWebRequest request)
    {
      return request_criteria(request);
    }
  }
}