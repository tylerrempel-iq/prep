using System;

namespace code.utility.matching
{
  public static class DateMatchingExtensions
  {
    public static Criteria<Item> greater_than<Item>(this IProvideAccessToMatchBuilders<Item,DateTime> extension_point, int value) 
    {
      return extension_point.create(Match<DateTime>.with_attribute(x => x.Year).greater_than(value));
    }
  }
}