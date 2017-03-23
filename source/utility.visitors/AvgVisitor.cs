namespace code.utility.visitors
{
  public class AvgVisitor<Element, Result> : IProcessAndReturnAValue<Element, Result>
  {
    IProcessAndReturnAValue<Element, Result> summer;
    int count;

    public AvgVisitor(IProcessAndReturnAValue<Element, Result> visitor)
    {
      this.summer = visitor;
    }

    public void process(Element value)
    {
      summer.process(value);
      count++;
    }

    public Result get_result()
    {
      return (dynamic) summer.get_result()/count;
    }
  }
}