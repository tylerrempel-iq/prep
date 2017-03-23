using System;

namespace code.utility.containers
{
  public class ContainerFacade : IFetchDependencies
  {
    IFindFactoriesForAType factory_registry;

    public ContainerFacade(IFindFactoriesForAType factory_registry)
    {
      this.factory_registry = factory_registry;
    }

    public ItemToFetch an<ItemToFetch>()
    {
      return (ItemToFetch) an(typeof(ItemToFetch));
    }

    public object an(Type type_to_fetch)
    {
      var factory = factory_registry.get_factory_that_can_create(type_to_fetch);

      return factory.create();
    }
  }
}