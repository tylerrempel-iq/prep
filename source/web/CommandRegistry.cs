using System.Collections.Generic;
using System.Linq;
using code.web.stubs;

namespace code.web
{
  public class CommandRegistry : IFindACommandThatCanHandleARequest
  {
    IEnumerable<IHandleOneWebRequest> commands;
    ICreateAMissingCommandWhenOneCantBeFound missing_handler_builder;

    public CommandRegistry():this(Stubs.dummy_set_of_handlers(), 
      Stubs.missing_request_builder)
    {
    }

    public CommandRegistry(IEnumerable<IHandleOneWebRequest> commands,
      ICreateAMissingCommandWhenOneCantBeFound missing_command_builder)
    {
      this.commands = commands;
      this.missing_handler_builder = missing_command_builder;
    }

    public IHandleOneWebRequest get_command_that_can_handle(IProvideDetailsAboutAWebRequest request)
    {
      var command_that_can_handle = commands.FirstOrDefault(command => command.can_process(request));

      return command_that_can_handle ?? missing_handler_builder(request);
    }
  }
}