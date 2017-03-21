using System;

namespace code.prep.movies
{
    public class SortOrder
    {
        public static int descending<Item>(Item item1, Item item2) where Item : IComparable<Item>
        {
            return item2.CompareTo(item1);
        }

        public static int ascending<Item>(Item item1, Item item2) where Item : IComparable<Item>
        {
            return item1.CompareTo(item2);
        }
    }
}