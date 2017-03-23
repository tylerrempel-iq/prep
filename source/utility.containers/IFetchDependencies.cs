using System;

namespace code.utility.containers
{
  public interface IFetchDependencies
  {
    ItemToFetch an<ItemToFetch>();
    object an(Type type_to_fetch);
  }
}