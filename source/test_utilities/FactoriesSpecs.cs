using System.Collections.Generic;
using System.Linq;
using code.prep.people;
using code.utility.iteration;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.test_utilities
{
  [Subject(typeof(Factories))]
  public class FactoriesSpecs
  {
    public abstract class concern : spec.observe
    {
    }

    public class when_generating_a_list_of_items : concern
    {
      Because b = () =>
        result = Factories.generate(100, x => x.ToString());

      It returns_a_set_of_items_created_using_the_provided_mapper = () =>
        result.Count().ShouldEqual(100);

      static IEnumerable<string> result;
    }

    public class generating_a_list_of_items : concern
    {
      Because b = () =>
        result = Factories.generate(1000, x => Factories.create_person());

      It returns_a_set_of_items_created_using_the_provided_mapper = () =>
      {
        result.each(x =>
        {
          return true;
        });
      };

      static IEnumerable<Person> result;
    }
  }
}