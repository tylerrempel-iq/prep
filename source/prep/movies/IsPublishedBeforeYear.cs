using code.utility.matching;

namespace code.prep.movies
{
  public class IsPublishedBeforeYear : IMatchA<Movie>
  {
    int year;

    public IsPublishedBeforeYear(int year)
    {
      this.year = year;
    }

    public bool matches(Movie movie)
    {
      return movie.date_published.Year < year;
    }     
  }
}