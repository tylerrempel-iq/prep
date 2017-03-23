using System;
using code.utility.core;

namespace code.utility.sorting
{
  public class Sort<Item>
  {
    public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor)
    where Property : IComparable<Property>
    {
        return by(accessor, SortOrders.@ascending);
    }

    public static ICompareTwoItems<Item> by_descending<Property>(IGetTheValueOfAProperty<Item, Property> accessor)
    where Property : IComparable<Property>
    {
        return by(accessor, SortOrders.@descending);
    }
    public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor,
      ICompareTwoItems<Property> order)
      where Property : IComparable<Property>
    {
      return (a, b) => order(accessor(a), accessor(b));
    }

    public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor,
      params Property[] sort_order)
    {
      return (a, b) => Array.IndexOf(sort_order, accessor(a)) - Array.IndexOf(sort_order, accessor(b));
    }
  }
}