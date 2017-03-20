namespace code.utility.matching
{
  public class AndMatch<Item> : IMatchA<Item>
  {
    IMatchA<Item> left;
    IMatchA<Item> right;

    public AndMatch(IMatchA<Item> left, IMatchA<Item> right)
    {
      this.left = left;
      this.right = right;
    }

    public bool matches(Item item)
    {
      return left.matches(item) && right.matches(item);
    }
  }
}