using System.Collections.Generic;
using code.utility.core;

namespace code.utility.matching
{
  public static class Filter
  {
    public static EnumerableFilterExtensionPoint<Item, ItemProperty> filter<Item, ItemProperty>(
      this IEnumerable<Item> enumerable,
      IGetTheValueOfAProperty<Item, ItemProperty> accessor)
    {
      return new EnumerableFilterExtensionPoint<Item, ItemProperty>(enumerable, accessor);
    }
  }
}