namespace code.utility.visitors
{
  public class ChainedVisitor<Element> : IProcessAn<Element>
  {
    IProcessAn<Element> first;
    IProcessAn<Element> second;

    public ChainedVisitor(IProcessAn<Element> first, IProcessAn<Element> second)
    {
      this.first = first;
      this.second = second;
    }

    public void process(Element value)
    {
      first.process(value);
      second.process(value);
    }
  }
}