using AttributeRouting.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace the_facts_api.Controllers
{
    public class CategoriesController : ApiController
    {
        readonly Data.ChuckNorrisEntities _entities = new Data.ChuckNorrisEntities();

        [AcceptVerbs("GET")]
        [GET("/categories")]
        public IEnumerable<Models.Category> All() {
            return _entities.Categories.Select(c => new Models.Category {
                CategoryId = c.CategoryId,
                Description = c.Description
            });
        }
    }
}
