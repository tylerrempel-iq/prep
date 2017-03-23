using System.Text;

namespace code.prep.people
{
  public class Person
  {
    public int age { get; set; }    
    public string first_name { get; set; }    
    public string surname { get; set; }    
    public string country { get; set; }
    public Profession profession { get; set; }

    public override string ToString()
    {
      var builder = new StringBuilder();
      builder.AppendLine("Person");
      builder.AppendFormat("\t{0} {1}\n", first_name, surname);
      builder.AppendFormat("\tProfession: {0}\n", profession);
      builder.AppendFormat("\tCountry: {0}\n", country);
      builder.AppendFormat("\tAge: {0}\n", age);

      return builder.ToString();
    }
  }

  public enum Profession
  {
    baker,
    programmer,
    cashier,
    accountant,
    lawyer,
    doctor,
    security_guard,
  }
}