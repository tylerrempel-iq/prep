using System;
using code.utility.core;

namespace code.utility.visitors
{
	public class ReducingVisitor<Element, Result> : IProcessAndReturnAValue<Element, Result>
		where Result : IComparable<Result>
	{
		IGetTheValueOfAProperty<Element, Result> accessor;
		Func<Result, Result, Result> reducer;
		bool first_result;
		Result result;

		public ReducingVisitor(IGetTheValueOfAProperty<Element, Result> accessor, Func<Result, Result, Result> reducer)
		{
			this.reducer = reducer;
			this.accessor = accessor;
			first_result = true;
		}

		public void process(Element value)
		{
			var current = accessor(value);
			if (first_result)
			{
				first_result = false;
				result = current;
				return;
			}
			result = reducer(current, result);
		}

		public Result get_result()
		{
			return result;
		}
	}

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