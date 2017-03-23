using code.utility.matching;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web.core
{  
  [Subject(typeof(RequestHandler))]  
  public class RequestHandlerSpecs
  {

    public abstract class concern : spec.observe<IHandleOneWebRequest,RequestHandler>
    {
        
    }

   
    public class when_determining_if_it_can_process_a_request : concern
    {

      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutAWebRequest>();
        depends.on<Criteria<IProvideDetailsAboutAWebRequest>>(x =>
        {
          x.ShouldEqual(request);
          return true;
        });
      };

      Because b = () =>
        result = sut.can_process(request);

      It makes_the_decision_by_using_its_request_specification = () =>
        result.ShouldBeTrue();

      static bool result;
      static IProvideDetailsAboutAWebRequest request;
    }

    public class when_processing_a_request : concern
    {

      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutAWebRequest>();
        feature = depends.on<IImplementAUserStory>();
      };

      Because b = () =>
        sut.process(request);

      It run_the_application_specific_feature_using_the_request = () =>
        feature.should().received(x => x.process(request));

      static IProvideDetailsAboutAWebRequest request;
      static IImplementAUserStory feature;
    }
  }
}
