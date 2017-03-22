using System.Data;
using System.Security.Principal;
using System.Threading;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using Rhino.Mocks;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.prep.mspec_sample
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern : spec.observe<ICalculate, Calculator>
    {
      protected static IDbConnection connection;

      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
      };
    }

    public class when_created : concern
    {
      It does_not_attempt_to_open_its_database_connection = () =>
        connection.should().never_received(x => x.Open());
    }

    public class when_disabling_calculation : concern
    {
      public class and_they_are_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          result = sut.disable();

        It allows_the_calculator_to_shutdown = () =>
          result.ShouldBeTrue();

        static IPrincipal principal;
        static bool result;
      }

      public class and_they_are_not_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          result = sut.disable();

        It does_not_allow_disabling = () =>
          result.ShouldBeFalse();

        static IPrincipal principal;
        static bool result;
      }
    }

    public class when_adding : concern
    {
      public class two_positive_numbers
      {
        Establish c = () =>
        {
          command = fake.an<IDbCommand>();
          connection.setup(x => x.CreateCommand()).Return(command);
        };

        Because b = () =>
          result = sut.add(2, 3);

        It opens_a_database_connection = () =>
          connection.should().received(x => x.Open());

        It runs_a_query = () =>
          command.should().received(x => x.ExecuteNonQuery());

        It returns_the_sum = () =>
          result.ShouldEqual(5);

        static int result;
        static IDbCommand command;
      }

      public class negative_to_a_positive
      {
        Because b = () =>
          spec.catch_exception(() => sut.add(2, -6));

        It cannot_handle_it = () =>
          spec.exception_thrown.ShouldNotBeNull();
      }
    }
  }
}