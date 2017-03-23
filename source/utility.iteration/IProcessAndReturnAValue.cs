namespace code.utility.iteration
{
  public interface IProcessAndReturnAValue<Element, Result> : IProcessAn<Element>
  {
    Result get_result();
  }
}