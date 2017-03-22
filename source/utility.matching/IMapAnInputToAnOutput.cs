namespace code.utility.matching
{
  public delegate Output IMapAnInputToAnOutput<in Input, out Output>(Input input);
}