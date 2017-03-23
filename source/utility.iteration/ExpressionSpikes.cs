using System;
using System.Linq.Expressions;
using code.prep.people;
using code.test_utilities;
using code.utility.core;
using developwithpassion.specifications.extensions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility.iteration
{
  [Subject(typeof(Expression))]
  public class ExpressionSpikes
  {
    public abstract class concern : spec.observe
    {
    }

    public class when_playing_around_with_expressions : concern
    {
      Establish c = () =>
      {
        person = Factories.create_person();
      };

      It can_get_the_value_of_a_property = () =>
      {
        IGetTheValueOfAProperty<Person, string> accessor = x => x.first_name;

        accessor(person).ShouldEqual(person.first_name);
      };

      It can_get_the_value_of_a_property_by_compiling_an_expression_tree = () =>
      {
        Expression<IGetTheValueOfAProperty<Person, string>> code_as_data = x => x.first_name;

        IGetTheValueOfAProperty<Person, string> accessor = code_as_data.Compile();
        accessor(person).ShouldEqual(person.first_name);
      };

      It can_get_the_name_of_the_property_it_is_trying_to_read = () =>
      {
        Expression<IGetTheValueOfAProperty<Person, string>> code_as_data = x => x.first_name;

        code_as_data.Body.downcast_to<MemberExpression>().Member.Name.ShouldEqual("first_name");
      };

      It can_build_an_expression_tree_to_determine_if_a_number_is_even = () =>
      {
        Func<int, bool> inline = x => x%2 == 0;

        var zero = Expression.Constant(0);
        var two = Expression.Constant(2);
        var parameter = Expression.Parameter(typeof(int), "x");
        var mod = Expression.Modulo(two, parameter);
        var is_equal = Expression.Equal(mod, zero);

        var lambda = Expression.Lambda<Func<int, bool>>(is_equal, parameter);
        var instance = lambda.Compile();
        instance(2).ShouldBeTrue();
      };

      static Person person;
    }
  }
}