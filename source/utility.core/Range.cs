using System;
using code.utility.matching;

namespace code.utility.core
{
  public static class Range
  {
    delegate Criteria<Value> IBuildARangeMatcher<in Value>(Value value);

    static Criteria<Value> create<Value>(Value value, bool inclusive, IBuildARangeMatcher<Value> builder) where Value : IComparable<Value>
    {
      var matcher = builder(value);

      return inclusive ? matcher.or(EqualToAny.values(value)) : matcher;
    }

    public static Criteria<Value> after<Value>(Value value, bool inclusive) where Value : IComparable<Value>
    {
      return create(value, inclusive, GreaterThan.value);
    }

    public static Criteria<Value> before<Value>(Value value, bool inclusive) where Value : IComparable<Value>
    {
      return create(value, inclusive, LessThan.value);
    }

    public static Criteria<Value> between<Value>(Value start, bool inclusive_start, Value end, bool inclusive_end)
      where Value : IComparable<Value>
    {
      return after(start, inclusive_start).and(before(end, inclusive_end));
    }
  }
  public static partial class MatchingExtensions
  {
    public static ReturnType between<Item,Property, ReturnType>(this IProvideAccessToMatchBuilders<Item,Property, ReturnType> extension_point, Property start, Property end) where Property : IComparable<Property>
    {
      return extension_point.create(Between.values(start, end));
    }

  }
}