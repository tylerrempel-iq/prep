namespace code.web
{
  public interface IProcessWebRequests
  {
    void run(IProvideDetailsAboutAWebRequest request);
  }

  public class FrontController : IProcessWebRequests
  {
    IFindACommandThatCanHandleARequest commands;

    public FrontController():this(new CommandRegistry())
    {
    }

    public FrontController(IFindACommandThatCanHandleARequest commands)
    {
      this.commands = commands;
    }

    public void run(IProvideDetailsAboutAWebRequest request)
    {
      var handler = commands.get_command_that_can_handle(request);
      handler.process(request);
    }
  }
}