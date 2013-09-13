using AttributeRouting.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace the_facts_api.Controllers
{
    public class JokesController : ApiController
    {
        readonly Repositories.JokesRepository _jokes = new Repositories.JokesRepository();

        [AcceptVerbs("GET")]
        [GET("/joke/clean")]
        public Models.Joke Clean() {

            return _jokes.Random(Repositories.JokesRepository.JokeType.clean);

        }
    }
}
