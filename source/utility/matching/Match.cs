namespace code.utility.matching
{
  public static class Match<ItemToMatch>
  {
    public static MatchingExtensionPoint<ItemToMatch, Property> with_attribute<Property>(
      IGetTheValueOfAProperty<ItemToMatch, Property> get_the_value_of_a_property)
    {
      return new MatchingExtensionPoint<ItemToMatch, Property>(get_the_value_of_a_property);
    }
  }
}