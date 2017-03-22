using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.matching
{
  [Subject(typeof(MatchExtensions))]
  public class MatchExtensionsSpecs
  {
    public abstract class concern : spec.observe
    {

    }

    public class when_combining_matchers : concern
    {
      static Criteria<int> sut;

      public class binary_and
      {
        Establish c = () =>
        {
          sut = MatchExtensions.and<int>(x => x > 2, x => x < 8);
        };

        It returns_a_matchers_that_passes_if_both_conditions_match = () =>
        {
          sut(7).ShouldBeTrue();
          sut(9).ShouldBeFalse();
        };
          
      }

      public class binary_or
      {
        Establish c = () =>
        {
          sut = MatchExtensions.or<int>(x => x > 2, x => x < 8);
        };

        It returns_a_matcher_that_passes_if_any_conditions_match = () =>
        {
          sut(7).ShouldBeTrue();
          sut(9).ShouldBeTrue();
        };
          
      }
        
    }
  }
}
