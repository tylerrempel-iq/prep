namespace code.utility.iteration
{
  public delegate Element ElementAccumulator<Element, Value>(Element accumulator, Value stepValue);
}