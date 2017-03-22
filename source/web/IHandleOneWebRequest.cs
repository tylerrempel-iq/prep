namespace code.web
{
  public interface IHandleOneWebRequest : IImplementAUserStory
  {
    bool can_process(IProvideDetailsAboutAWebRequest request);
  }
}