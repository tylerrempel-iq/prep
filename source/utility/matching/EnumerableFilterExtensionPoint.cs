using System.Collections.Generic;

namespace code.utility.matching
{
  public class EnumerableFilterExtensionPoint<ItemToMatch, PropertyType> : IProvideAccessToMatchBuilders<ItemToMatch,
    PropertyType, IEnumerable<ItemToMatch>>
  {
    IEnumerable<ItemToMatch> items_to_filter;
    IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor;

    public EnumerableFilterExtensionPoint(IEnumerable<ItemToMatch> items_to_filter,
      IGetTheValueOfAProperty<ItemToMatch, PropertyType> accessor)
    {
      this.items_to_filter = items_to_filter;
      this.accessor = accessor;
    }

    public IProvideAccessToMatchBuilders<ItemToMatch, PropertyType, IEnumerable<ItemToMatch>> not
    {
      get { return new Negate(this); }
    }

    class Negate : IProvideAccessToMatchBuilders<ItemToMatch, PropertyType, IEnumerable<ItemToMatch>>
    {
      IProvideAccessToMatchBuilders<ItemToMatch, PropertyType, IEnumerable<ItemToMatch>> original;

      public Negate(IProvideAccessToMatchBuilders<ItemToMatch, PropertyType, IEnumerable<ItemToMatch>> original)
      {
        this.original = original;
      }

      public IEnumerable<ItemToMatch> create(Criteria<PropertyType> value_matcher)
      {
        return original.create(value_matcher.not());
      }
    }

    public IEnumerable<ItemToMatch> create(Criteria<PropertyType> value_matcher)
    {
      return items_to_filter.filter_using(Match<ItemToMatch>.with_attribute(accessor).create(value_matcher));
    }
  }
}