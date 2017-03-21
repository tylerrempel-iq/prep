using System;

namespace code.utility.matching
{
  public static class FallsInMatchingExtensions
  {
    public static ReturnType falls_in<Item, Property, ReturnType>(
      this IProvideAccessToMatchBuilders<Item, Property, ReturnType> extension_point, Criteria<Property> compare)
      where Property : IComparable<Property>
    {
      return extension_point.create(compare);
    }
  }
}
