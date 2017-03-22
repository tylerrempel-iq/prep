namespace code.utility.matching
{
  public class Never
  {
    public static Criteria<Item> matches<Item>()
    {
      return x => false;
    }
  }
}