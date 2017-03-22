namespace code.utility.matching
{
  public interface IProvideAccessToMatchBuilders<in ItemToMatch, out Property, out ItemToCreate>
  {
    ItemToCreate create(Criteria<Property> value_matcher);
  }
}