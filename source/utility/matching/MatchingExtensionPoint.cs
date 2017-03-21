namespace code.utility.matching
{
  public class MatchingExtensionPoint<ItemToMatch, Property> : IProvideAccessToMatchBuilders<ItemToMatch, Property, Criteria<ItemToMatch>>
  {
    IGetTheValueOfAProperty<ItemToMatch, Property> accessor { get; }


    public MatchingExtensionPoint(IGetTheValueOfAProperty<ItemToMatch, Property> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToMatchBuilders<ItemToMatch, Property,Criteria<ItemToMatch>> not
    {
      get { return new NegatingMatchingExtensionPoint(this); }
    }

    class NegatingMatchingExtensionPoint : IProvideAccessToMatchBuilders<ItemToMatch, Property, Criteria<ItemToMatch>>
    {
      IProvideAccessToMatchBuilders<ItemToMatch, Property, Criteria<ItemToMatch>> original;

      public NegatingMatchingExtensionPoint(IProvideAccessToMatchBuilders<ItemToMatch, Property, Criteria<ItemToMatch>> original)
      {
        this.original = original;
      }

      public Criteria<ItemToMatch> create(Criteria<Property> value_matcher)
      {
        return original.create(value_matcher).not();
      }
    }

    public Criteria<ItemToMatch> create(Criteria<Property> value_matcher)
    {
      return x => value_matcher(accessor(x));
    }
  }
}