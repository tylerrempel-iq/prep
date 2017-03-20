using code.utility.matching;

namespace code.prep.movies
{
  public class IsPublishedAfterYear : IMatchA<Movie>
  {
    int year;

    public IsPublishedAfterYear(int year)
    {
      this.year = year;
    }

    public bool matches(Movie movie)
    {
      return movie.date_published.Year > year;
    }     
  }
}