using System;
using code.utility.core;

namespace code.utility.iteration
{
  public class SummingVisitor<Element, Result> : IProcessAndReturnAValue<Element, Result>
  {
    IGetTheValueOfAProperty<Element, Result> accessor;
    Func<Result, Result, Result> accumulator;
    Result result;

    public SummingVisitor(IGetTheValueOfAProperty<Element, Result> accessor, Func<Result, Result, Result> accumulator)
    {
      this.accessor = accessor;
      this.accumulator = accumulator;
    }

    public void process(Element value)
    {
      result = accumulator(result, accessor(value));
    }

    public Result get_result()
    {
      return result;
    }
  }
}