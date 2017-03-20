using System;
using code.utility.matching;

namespace code.prep.movies
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }
    public DateTime date_published { get; set; }

    public bool Equals(Movie other)
    {
      if (other == null) return false;
      if (ReferenceEquals(this, other)) return true;

      return this.title.Equals(other.title);
    }

    public override bool Equals(object obj)
    {
      return Equals(obj as Movie);
    }

    public override int GetHashCode()
    {
      return title.GetHashCode();
    }

    public static IMatchA<Movie> published_by(ProductionStudio studio)
    {
      return new IsPublishedBy(studio);
    }

    public static IMatchA<Movie> in_genre(Genre genre)
    {
      return new IsInGenre(genre);
    }

    public static IMatchA<Movie> published_after(int year)
    {
      return new IsPublishedAfterYear(year);   
    }

    public static IMatchA<Movie> published_before(int year)
    {
        return new IsPublishedBeforeYear(year);
    }

    public static IMatchA<Movie> published_in(int year)
    {
        return new IsPublishedInYear(year);
    }
    }
}