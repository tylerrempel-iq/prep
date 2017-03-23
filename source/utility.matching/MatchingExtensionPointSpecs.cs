using code.utility.core;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.matching
{
  [Subject(typeof(MatchingExtensionPoint<,>))]
  public class MatchingExtensionPointSpecs
  {
    public class SomeType
    {
    }

    public abstract class concern : spec.observe<IProvideAccessToMatchBuilders<SomeType, int, Criteria<SomeType>>,
      MatchingExtensionPoint<SomeType, int>>
    {
      Establish c = () =>
      {
        instance = new SomeType();

        depends.on<IGetTheValueOfAProperty<SomeType, int>>(x =>
        {
          x.ShouldEqual(instance);
          return 4;
        });
      };

      protected static SomeType instance;
    }

    public class when_creating_its_dsl_result : concern
    {
      Because b = () =>
        result = sut.create(x =>
        {
          x.ShouldEqual(4);
          return false;
        });

      It returns_a_criteria_that_matches_the_value_of_its_provided_accessor = () =>
        result(instance).ShouldBeFalse();

      static Criteria<SomeType> result;
    }
  }
}