using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;
using Machine.Specifications;


namespace code.web
{   

  [Subject(typeof(FrontController))]
  public class FrontControllerSpecs
  {

    public abstract class concern : spec.observe<IProcessWebRequests, FrontController>
    {
        
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutAWebRequest>();
        command_that_can_handle_the_request = fake.an<IHandleOneWebRequest>();
        commands = depends.on<IFindACommandThatCanHandleARequest>();
        commands.setup(x => x.get_command_that_can_handle(request)).Return(command_that_can_handle_the_request);
      };

      Because b = () =>
        sut.run(request);

      It delegates_processing_of_the_request_to_the_command_that_can_handle_it = () =>
        command_that_can_handle_the_request.should().received(x => x.process(request));

      static IFindACommandThatCanHandleARequest commands;
      static IProvideDetailsAboutAWebRequest request;
      static IHandleOneWebRequest command_that_can_handle_the_request;
    }
  }
}
