using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.iteration
{
  [Subject(typeof(IteratorExtensions))]
  public class IteratorExtensionSpecs
  {
    public class when_applying_a_filter_to_a_set_of_items : spec.observe
    {
      Because b = () =>
        results = Enumerable.Range(1, 10).filter_using(x => x%2 == 0);

      It returns_only_the_items_that_match_the_filter = () =>
        results.ShouldContainOnly(2, 4, 6, 8, 10);

      static IEnumerable<int> results;
    }

    public class when_iterating_a_set_of_items : spec.observe
    {
      public class and_iteration_is_not_stopped
      {
        Establish c = () =>
        {
          visited = new List<int>();
        };

        Because b = () =>
          Enumerable.Range(1, 4).each(x =>
          {
            visited.Add(x);
            return true;
          });

        It proceses_all_items_against_the_provided_visitor = () =>
          visited.ShouldContain(1,2,3,4);

        static List<int> visited;
      }

      public class and_iteration_is_stopped
      {
        Establish c = () =>
        {
          visited = new List<int>();
        };

        Because b = () =>
          Enumerable.Range(1, 4).each(x =>
          {
            visited.Add(x);
            return x < 2;
          });

        It proceses_only_the_items_before_it_stopped = () =>
          visited.ShouldContain(1,2);

        static List<int> visited;
      }
    }

    public class reducing_a_set_of_items : spec.observe
    {

    }
  }
}