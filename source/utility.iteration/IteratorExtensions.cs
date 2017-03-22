using System.Collections.Generic;
using code.utility.core;
using code.utility.matching;

namespace code.utility.iteration
{
  public static class IteratorExtensions
  {
    public static IEnumerable<Element> one_at_a_time<Element>(this IEnumerable<Element> items)
    {
      foreach (var element in items)
        yield return element;
    }

    public static IEnumerable<Element> filter_using<Element>(this IEnumerable<Element> items, Criteria<Element> criteria)
    {
      foreach (var element in items) if (criteria(element)) yield return element;
    }

    public static IEnumerable<Element> sort_using<Element>(this IEnumerable<Element> items, ICompareTwoItems<Element> comparer)
    {
      var sorted = new List<Element>(items);
      sorted.Sort(comparer.Invoke);
      return sorted;
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

  public delegate Element ElementAccumulator<Element, Value>(Element accumulator, Value stepValue);
}