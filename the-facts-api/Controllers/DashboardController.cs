using AttributeRouting.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace the_facts_api.Controllers
{
    public class DashboardController : ApiController
    {
        readonly Repositories.DashboardRepository _dashboard = new Repositories.DashboardRepository();

        [AcceptVerbs("GET")]
        [GET("/dashboard/categories")]
        public IEnumerable<Models.JokeCategory> Categories() {
            return _dashboard.JokeCategories();
        }
    }
}
