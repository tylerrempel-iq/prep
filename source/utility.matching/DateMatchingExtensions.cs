using System;

namespace code.utility.matching
{
  public static class DateMatchingExtensions
  {
    public static ReturnType greater_than<Item, ReturnType>(this IProvideAccessToMatchBuilders<Item,DateTime, ReturnType> extension_point, int value) 
    {
      return extension_point.create(Match<DateTime>.with_attribute(x => x.Year).greater_than(value));
    }
  }
}