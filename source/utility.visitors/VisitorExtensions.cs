using System;
using System.Collections.Generic;
using code.utility.core;
using code.utility.iteration;
using code.utility.matching;

namespace code.utility.visitors
{
  public static class VisitorExtensions
  {
    public static IProcessAndReturnAValue<Element, Result> create_summing_visitor<Element, Result>(
      IGetTheValueOfAProperty<Element, Result> accessor)
    {
        return new SummingVisitor<Element, Result>(accessor,
          (x, y) =>
          {
            dynamic first = x;
            dynamic second = y;
            return first + second;
          });
      
    }
    public static Result sum<Element, Result>(this IEnumerable<Element> items,
      IGetTheValueOfAProperty<Element, Result> accessor)
    {
      return items.get_result_of_processing_all_with(create_summing_visitor(accessor));
    }

		public static Result min<Element, Result>(this IEnumerable<Element> items,
			IGetTheValueOfAProperty<Element, Result> accessor)
			where Result : IComparable<Result>
		{
			return items.get_result_of_processing_all_with(new ReducingVisitor<Element, Result>(accessor, (a, b) =>
			{
				return a.CompareTo(b) < 0 ? a : b;
			}));
		}

		public static Result max<Element, Result>(this IEnumerable<Element> items,
			IGetTheValueOfAProperty<Element, Result> accessor)
			where Result : IComparable<Result>
		{
			return items.get_result_of_processing_all_with(new ReducingVisitor<Element, Result>(accessor, (a, b) =>
			{
				return a.CompareTo(b) > 0 ? a : b;
			}));
		}

		public static Result avg<Element, Result>(this IEnumerable<Element> items,
      IGetTheValueOfAProperty<Element, Result> accessor)
    {
      return items.get_result_of_processing_all_with(
        new AvgVisitor<Element, Result>(create_summing_visitor(accessor)));
    }

    public static Result get_result_of_processing_all_with<Element, Result>(this IEnumerable<Element> items,
      IProcessAndReturnAValue<Element, Result> visitor)
    {
      items.process_all_using(visitor);
      return visitor.get_result();
    }

    public static Result get_result_of_processing_all_with<Element, Result>(this IEnumerable<Element> items,
      IProcessAndReturnAValue<Element, Result> visitor, Criteria<Element> constraint)
    {
      var constrained = new ConstrainedVisitor<Element>(constraint, visitor);
      items.process_all_using(constrained);
      return visitor.get_result();
    }

    public static void process_all_using<Element>(this IEnumerable<Element> items, IProcessAn<Element> visitor)
    {
      items.each_for_all(visitor.process);
    }

    public static void each_for_all<Element>(this IEnumerable<Element> items, ExhaustiveElementVisitor<Element> visitor)
    {
      items.each(x =>
      {
        visitor(x);
        return true;
      });
    }

    public static void each<Element>(this IEnumerable<Element> items, ElementVisitor<Element> visitor)
    {
      foreach (var element in items)
      {
        var result = visitor(element);
        if (!result) return;
      }
    }

    public static Element reduce<Element, Value>(this IEnumerable<Value> items, Element start,
      ElementAccumulator<Element, Value> element_accumulator)
    {
      var result = start;

      items.each(x =>
      {
        result = element_accumulator(result, x);
        return true;
      });

      return result;
    }
  }
}