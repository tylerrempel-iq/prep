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

  public static class EqualityMatchingExtensions
  {
    public static Criteria<Item> equal_to<Item,Property>(this IProvideAccessToMatchBuilders<Item,Property> extension_point, Property property)
    {
      return extension_point.equal_to_any(property);
    }

    public static Criteria<Item> equal_to_any<Item,Property>(this IProvideAccessToMatchBuilders<Item,Property> extension_point, params Property[] values)
    {
      return extension_point.create(EqualToAny.values(values));
    }
    
  }
}