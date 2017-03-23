using Machine.Specifications;
using developwithpassion.specifications.assertions.core;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.containers
{
  [Subject(typeof(Dependencies))]
  public class DependenciesSpecs
  {
    public abstract class concern : spec.observe
    {

    }

    public class when_initiating_a_call_to_fetch_a_dependency  : concern
    {
      Establish c = () =>
      {
        the_container_facade = fake.an<IFetchDependencies>();
        IConfigureTheContainer startup = () => the_container_facade;
        spec.change(() => Dependencies.startup).to(startup);
      };

      Because b = () =>
        result = Dependencies.fetch;

      It returns_an_instance_of_the_container_facade_it_was_configured_with_at_startup = () =>
        result.ShouldEqual(the_container_facade);

      static IFetchDependencies result;
      static IFetchDependencies the_container_facade;
    }
  }
}
