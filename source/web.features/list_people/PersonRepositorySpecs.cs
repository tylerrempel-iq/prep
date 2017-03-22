using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.utility.matching;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web.features.list_people
{
    [Subject(typeof (PersonRepository))]
    public class PersonRepositorySpecs
    {
        public abstract class concern : spec.observe<PersonRepository>
        {

        }


        public class when_getting_all_people : concern
        {
            Establish c = () =>
            {
                request = fake.an<IProvideDetailsAboutAWebRequest>();
                depends.on<IBuildAQueryFromARequest>();
            };

            Because b = () =>
                sut.get_all_people(request);

            private static IProvideDetailsAboutAWebRequest request;
        }
    }

    internal interface IBuildAQueryFromARequest
    {
    }
}
