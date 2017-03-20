using code.utility.matching;

namespace code.prep.movies
{
  public class IsPublishedInYear : IMatchA<Movie>
  {
    int year;

    public IsPublishedInYear(int year)
    {
      this.year = year;
    }

    public bool matches(Movie movie)
    {
      return movie.date_published.Year == year;
    }     
  }
}