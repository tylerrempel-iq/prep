using System;

namespace code.utility.sorting
{
  public class SortOrders
  {
    public static int ascending<Item>(Item a, Item b) where Item : IComparable<Item>
    {
      return a.CompareTo(b);
    }

    public static int descending<Item>(Item a, Item b) where Item : IComparable<Item>
    {
      return b.CompareTo(a);
    }
  }
}