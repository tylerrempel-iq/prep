namespace code.utility.matching
{
  public delegate PropertyType IGetTheValueOfAProperty<in Target, out PropertyType>(Target target);
}