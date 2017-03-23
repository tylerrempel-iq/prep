using code.utility.iteration;
using System.Collections.Generic;

namespace code.prep.movies
{
  public class MovieLibrary
  {
    IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (movies.Contains(movie)) return;

      movies.Add(movie);
    }
  }
}