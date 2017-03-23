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

  public static partial class MatchingExtensions
  {
    public static ReturnType greater_than<Item,Property, ReturnType>(this IProvideAccessToMatchBuilders<Item,Property, ReturnType> extension_point, Property value) where Property : IComparable<Property>
    {
      return extension_point.create(GreaterThan.value(value));
    }

  }
}