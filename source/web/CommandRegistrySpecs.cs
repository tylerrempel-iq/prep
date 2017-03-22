using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web
{
  [Subject(typeof(CommandRegistry))]
  public class CommandRegistrySpecs
  {

    public abstract class concern : spec.observe<IFindACommandThatCanHandleARequest, CommandRegistry>
    {
    }

    public class when_getting_a_command_that_can_handle_a_request : concern
    {
      public class and_it_has_the_command
      {
        Establish c = () =>
        {
          the_command_that_can_handle = fake.an<IHandleOneWebRequest>();
          request = fake.an<IProvideDetailsAboutAWebRequest>();
          all_commands = Enumerable.Range(1, 100).Select(x => fake.an<IHandleOneWebRequest>()).ToList();
          all_commands.Add(the_command_that_can_handle);
          the_command_that_can_handle.setup(x => x.can_process(request)).Return(true);

          depends.on<IEnumerable<IHandleOneWebRequest>>(all_commands);
        };

        Because b = () =>
          result = sut.get_command_that_can_handle(request);

        It returns_the_command_to_the_caller = () =>
          result.ShouldEqual(the_command_that_can_handle);

        static IHandleOneWebRequest result;
        static IHandleOneWebRequest the_command_that_can_handle;
        static IProvideDetailsAboutAWebRequest request;
        static List<IHandleOneWebRequest> all_commands;
      }

      public class and_it_does_not_have_the_command
      {
        Establish c = () =>
        {
          the_special_case = fake.an<IHandleOneWebRequest>();
          request = fake.an<IProvideDetailsAboutAWebRequest>();
          all_commands = Enumerable.Range(1, 100).Select(x => fake.an<IHandleOneWebRequest>()).ToList();
          all_commands.Add(the_special_case);

          depends.on<ICreateAMissingCommandWhenOneCantBeFound>(x =>
          {
            x.ShouldEqual(request);
            return the_special_case;
          });

          depends.on<IEnumerable<IHandleOneWebRequest>>(all_commands);
        };

        Because b = () =>
          result = sut.get_command_that_can_handle(request);

        It returns_the_missing_command_special_case_to_the_caller = () =>
          result.ShouldEqual(the_special_case);

        static IHandleOneWebRequest result;
        static IHandleOneWebRequest the_special_case;
        static IProvideDetailsAboutAWebRequest request;
        static List<IHandleOneWebRequest> all_commands;
      }
    }
  }
}