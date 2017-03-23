using System;

namespace code.utility.containers
{
  public interface IFindFactoriesForAType
  {
    ICreateOneDependency get_factory_that_can_create(Type item_to_create);
  }
}