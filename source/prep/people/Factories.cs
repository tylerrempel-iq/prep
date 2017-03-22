using System;
using System.Collections.Generic;
using System.Linq;
using code.utility.matching;
using Faker;

namespace code.prep.people
{
  public class Factories
  {
    static Random randomizer = new Random();

    public static Person create_person()
    {
      return new Person
      {
        age = randomizer.Next(1, 120),
        first_name = Name.First(),
        surname = Name.Last(),
        country = Address.Country(),
        profession = one_of(typeof(Profession).GetEnumValues().Cast<Profession>())
      };
    }

    public static Value one_of<Value>(params Value[] values)
    {
      return one_of(values as IEnumerable<Value>);
    }

    public static Value one_of<Value>(IEnumerable<Value> values)
    {
      var list = new List<Value>(values);
      return list[randomizer.Next(0, list.Count)];
    }

    public static IEnumerable<Element> generate<Element>(int count, IMapAnInputToAnOutput<int, Element> mapper)
    {
      return Enumerable.Range(1, count).Select(mapper.Invoke);
    }
  }
}