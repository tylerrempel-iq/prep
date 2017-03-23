using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.containers
{
  [Subject(typeof(ContainerFacade))]
  public class ContainerFacadeSpecs
  {
    public abstract class concern : spec.observe<IFetchDependencies, ContainerFacade>
    {
    }

    public class when_fetching_a_dependency : concern
    {
      public class SomeItem
      {
      }

      public class using_generic_type_arguments
      {
        Establish c = () =>
        {
          factory_registry = depends.on<IFindFactoriesForAType>();
          the_type_factory = fake.an<ICreateOneDependency>();
          some_item = new SomeItem();

          factory_registry.setup(registry => registry.get_factory_that_can_create(typeof(SomeItem)))
            .Return(the_type_factory);
          the_type_factory.setup(x => x.create()).Return(some_item);
        };

        Because b = () =>
          result = sut.an<SomeItem>();

        It returns_the_item_created_by_the_factory_for_the_dependency = () =>
          result.ShouldEqual(some_item);

        static IFindFactoriesForAType factory_registry;
        static ICreateOneDependency the_type_factory;
        static SomeItem result;
        static SomeItem some_item;
      }

      public class using_runtime_provided_types
      {
        Establish c = () =>
        {
          factory_registry = depends.on<IFindFactoriesForAType>();
          the_type_factory = fake.an<ICreateOneDependency>();
          some_item = new SomeItem();

          factory_registry.setup(registry => registry.get_factory_that_can_create(typeof(SomeItem)))
            .Return(the_type_factory);
          the_type_factory.setup(x => x.create()).Return(some_item);
        };

        Because b = () =>
          result = sut.an(typeof(SomeItem));

        It returns_the_item_created_by_the_factory_for_the_dependency = () =>
          result.ShouldEqual(some_item);

        static IFindFactoriesForAType factory_registry;
        static ICreateOneDependency the_type_factory;
        static object result;
        static SomeItem some_item;
      }
    }
  }
}