using System.Collections.Generic;
using code.prep.people;
using code.web.stubs;

namespace code.web.features.list_people
{
  public class Handler : IImplementAUserStory
  {
	  IFetchDataUsingTheRequest<IEnumerable<Person>> all_people_query;
    ISendResponsesToTheClient response;

    public Handler():this(Stubs.dummy_list_of_people, Stubs.dummy_response_engine())
    {
    }

    public Handler(IFetchDataUsingTheRequest<IEnumerable<Person>> all_people_query, ISendResponsesToTheClient response)
    {
      this.all_people_query = all_people_query;
      this.response = response;
    }

    public void process(IProvideDetailsAboutAWebRequest request)
	  {
      response.send(all_people_query(request));
	  }
  }
}