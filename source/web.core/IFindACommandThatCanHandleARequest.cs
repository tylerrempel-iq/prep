namespace code.web.core
{
  public interface IFindACommandThatCanHandleARequest
  {
    IHandleOneWebRequest get_command_that_can_handle(IProvideDetailsAboutAWebRequest request);
  }
}