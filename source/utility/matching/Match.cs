namespace code.utility.matching
{
  public static class Match<Item>
  {
    public static MatchingExtensionPoint<Item, ItemProperty> with_attribute<ItemProperty>(
      IGetTheValueOfAProperty<Item, ItemProperty> get_the_value_of_a_property)
    {
      return new MatchingExtensionPoint<Item, ItemProperty>(get_the_value_of_a_property);
    }
  }
}