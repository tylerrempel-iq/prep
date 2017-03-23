using System.Collections.Generic;

namespace code.utility.matching
{
  public class EqualToAny
  {
    public static Criteria<Value> values<Value>(params Value[] values)
    {
      return x => new List<Value>(values).Contains(x);
    }
  }

  public static partial class MatchingExtensions
  {
    public static ReturnType equal_to<Item,Property, ReturnType>(this IProvideAccessToMatchBuilders<Item,Property, ReturnType> extension_point, Property property)
    {
      return extension_point.equal_to_any(property);
    }

    public static ReturnType equal_to_any<Item,Property, ReturnType>(this IProvideAccessToMatchBuilders<Item,Property, ReturnType> extension_point, params Property[] values)
    {
      return extension_point.create(EqualToAny.values(values));
    }
  }
}