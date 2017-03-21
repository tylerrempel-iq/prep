using System;

namespace code.utility.sorting
{
  public static class SortExtensions
  {
    public static ICompareTwoItems<Item> then_by<Item, Property>(this ICompareTwoItems<Item> previous_comparer,
      IGetTheValueOfAProperty<Item, Property> accessor, ICompareTwoItems<Property> order)
      where Property : IComparable<Property>
    {
      return (a, b) =>
      {
        var previous_result = previous_comparer(a, b);
        return previous_result == 0 ? Sort<Item>.by(accessor, order)(a, b) : previous_result;
      };
    }
  }
}