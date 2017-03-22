using System;
using code.utility.core;

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

    public static ICompareTwoItems<Item> then_by<Item, Property>(this ICompareTwoItems<Item> previous_comparer,
      IGetTheValueOfAProperty<Item, Property> accessor)
      where Property : IComparable<Property>
    {
      return previous_comparer.then_by(accessor, SortOrders.ascending);
    }

    public static ICompareTwoItems<Item> then_by_descending<Item, Property>(this ICompareTwoItems<Item> previous_comparer,
      IGetTheValueOfAProperty<Item, Property> accessor)
      where Property : IComparable<Property>
    {
      return previous_comparer.then_by(accessor, SortOrders.descending);
    }

    public static ICompareTwoItems<Item> then_by<Item, Property>(this ICompareTwoItems<Item> previous_comparer,
      IGetTheValueOfAProperty<Item, Property> accessor, params Property[] sort_order)
      where Property : IComparable<Property>
        {
            return (a, b) =>
            {
                var previous_result = previous_comparer(a, b);
                return previous_result == 0 ? Sort<Item>.by(accessor, sort_order)(a, b) : previous_result;
            };
        }
    }
}
