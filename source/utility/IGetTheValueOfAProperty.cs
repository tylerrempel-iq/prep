namespace code.utility
{
  public delegate PropertyType IGetTheValueOfAProperty<in Target, out PropertyType>(Target target);
}