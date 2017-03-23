namespace code.utility.visitors
{
  public interface IProcessAndReturnAValue<Element, Result> : IProcessAn<Element>
  {
    Result get_result();
  }
}