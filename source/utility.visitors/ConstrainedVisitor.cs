using code.utility.matching;

namespace code.utility.visitors
{
  public class ConstrainedVisitor<Element> : IProcessAn<Element>
  {
    Criteria<Element> constraint;
    IProcessAn<Element> visitor;

    public ConstrainedVisitor(Criteria<Element> constraint, IProcessAn<Element> visitor)
    {
      this.constraint = constraint;
      this.visitor = visitor;
    }

    public void process(Element value)
    {
      if (constraint(value))
        visitor.process(value);
    }
  }
}