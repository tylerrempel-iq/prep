namespace code.utility.core
{
  public delegate PropertyType IGetTheValueOfAProperty<in Target, out PropertyType>(Target target);
}