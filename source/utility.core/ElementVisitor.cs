namespace code.utility.core
{
  public delegate bool ElementVisitor<in Element>(Element element);
  public delegate void ExhaustiveElementVisitor<in Element>(Element element);
}