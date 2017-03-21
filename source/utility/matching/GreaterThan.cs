using System;

namespace code.utility.matching
{
  public class GreaterThan
  {
    public static Criteria<Value> value<Value>(Value value) where Value : IComparable<Value>
    {
      return x => x.CompareTo(value) > 0;
    }
  }

  public static class GreaterThanMatchingExtensions
  {
    public static Criteria<Item> greater_than<Item,Property>(this IProvideAccessToMatchBuilders<Item,Property> extension_point, Property value) where Property : IComparable<Property>
    {
      return extension_point.create(GreaterThan.value(value));
    }

  }
}