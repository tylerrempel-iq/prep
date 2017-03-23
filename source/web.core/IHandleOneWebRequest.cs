namespace code.web.core
{
  public interface IHandleOneWebRequest : IImplementAUserStory
  {
    bool can_process(IProvideDetailsAboutAWebRequest request);
  }
}