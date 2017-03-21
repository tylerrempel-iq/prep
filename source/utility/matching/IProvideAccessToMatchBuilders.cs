namespace code.utility.matching
{
  public interface IProvideAccessToMatchBuilders<in ItemToMatch, out Property>
  {
    Criteria<ItemToMatch> create(Criteria<Property> value_matcher);
  }
}