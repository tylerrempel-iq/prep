namespace code.utility.matching
{
  public static class MatchExtensions
  {
    public static Criteria<Element> or<Element>(this Criteria<Element> left, Criteria<Element> right)
    {
      return x => left(x) || right(x);
    }

	  public static Criteria<Element> and<Element>(this Criteria<Element> left, Criteria<Element> right)
	  {
	    return x => left(x) && right(x);
	  }

    public static Criteria<Element> not<Element>(this Criteria<Element> to_negate)
    {
      return x => !(to_negate(x));
    }
  }
}