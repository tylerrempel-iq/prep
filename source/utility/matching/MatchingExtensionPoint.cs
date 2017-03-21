namespace code.utility.matching
{
  public class MatchingExtensionPoint<ItemToMatch, Property> : IProvideAccessToMatchBuilders<ItemToMatch, Property>
  {
    IGetTheValueOfAProperty<ItemToMatch, Property> accessor { get; }


    public MatchingExtensionPoint(IGetTheValueOfAProperty<ItemToMatch, Property> accessor)
    {
      this.accessor = accessor;
    }

    public IProvideAccessToMatchBuilders<ItemToMatch, Property> not
    {
      get { return new NegatingMatchingExtensionPoint(this); }
    }

    class NegatingMatchingExtensionPoint : IProvideAccessToMatchBuilders<ItemToMatch, Property>
    {
      IProvideAccessToMatchBuilders<ItemToMatch, Property> original;

      public NegatingMatchingExtensionPoint(IProvideAccessToMatchBuilders<ItemToMatch, Property> original)
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