using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.web.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.containers
{
    [Subject(typeof(FactoryRepository))]
    public class FactoryRepositorySpecs
    {
        public abstract class concern : spec.observe<IFindFactoriesForAType, FactoryRepository>
        {
        }

        public class when_getting_a_factory : concern
        {
            Establish c = () =>
            {
                factory = fake.an<ICreateOneDependency>();
                factories = new List<ICreateOneDependency> { factory };
                
                depends.on<IEnumerable<ICreateOneDependency>>(factories);
            };

            private Because b = () =>
                result = sut.get_factory_that_can_create(typeof(SomeType));

            It returns_the_factory = () =>
                result.ShouldEqual(factory);

            private static ICreateOneDependency result;
            private static ICreateOneDependency factory;
            private static List<ICreateOneDependency> factories;
        }
    }

    internal class SomeType
    {
    }
}
