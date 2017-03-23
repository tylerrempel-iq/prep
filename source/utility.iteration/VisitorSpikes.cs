using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using Rhino.Mocks;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.iteration
{
  public class VisitorSpikes
  {
    public abstract class concern : spec.observe
    {
    }

    public class when_processing_all_of_the_items_in_a_iterator : concern
    {
      Establish c = () =>
      {
        visitor = fake.an<IProcessAn<int>>();
      };

      Because b = () =>
        Enumerable.Range(1, 10).process_all_using(visitor);

      It processes_each_item_using_the_visitor = () =>
        visitor.should().received(x => x.process(Arg<int>.Is.Anything)).Times(10);

      static IProcessAn<int> visitor;
    }

    public class when_getting_the_result_of_processing_all_items_in_an_iterator_with_a_visitor : concern
    {
      Establish c = () =>
      {
        visitor = fake.an<IProcessAndReturnAValue<int, int>>();
        expected_result = 42;
        visitor.setup(x => x.get_result()).Return(expected_result);
      };

      Because b = () =>
        result = Enumerable.Range(1, 10).get_result_of_processing_all_with(visitor);

      It uses_the_visitor_to_process_each_item = () =>
        visitor.should().received(x => x.process(Arg<int>.Is.Anything)).Times(10);

      It returns_the_result_of_the_visitor = () =>
        result.ShouldEqual(expected_result);

      static IProcessAndReturnAValue<int, int> visitor;
      static int result;
      static int expected_result;
    }

    public class concern_for_working_with_sets : concern
    {
      public class SomeItem
      {
        public int age { get; set; }
        public decimal cost { get; set; }
      }

      Establish c = () =>
      {
        values = new List<SomeItem>
        {
          new SomeItem {age = 10, cost = 20m},
          new SomeItem {age = 20, cost = 30m},
          new SomeItem {age = 30, cost = 40m},
          new SomeItem {age = 40, cost = 50m}
        };
      };

      protected static List<SomeItem> values;
    }

    public class when_calculating_the_sum_of_an_attribute : concern_for_working_with_sets
    {
      Because b = () =>
        result = values.sum(x => x.age);

      It returns_the_sum_of_the_provided_accessor = () =>
        result.ShouldEqual(100);

      static int result;
    }

    public class when_calculating_the_average_of_an_attribute : concern_for_working_with_sets
    {
      Because b = () =>
        result = values.avg(x => x.age);

      It returns_the_sum_of_the_provided_accessor = () =>
        result.ShouldEqual(25);

      static int result;
    }
  }
}