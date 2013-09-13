using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace the_facts_api.Repositories {
    public class DashboardRepository {

        readonly Data.ChuckNorrisEntities _entities = new Data.ChuckNorrisEntities();

        public IEnumerable<Models.JokeCategory> JokeCategories() {

            var categories = new List<Models.JokeCategory>();
            categories.Add(new Models.JokeCategory { CategoryId = 0, Description = "Nerdy", Jokes = 75 });
            categories.Add(new Models.JokeCategory { CategoryId = 1, Description = "Excplicit", Jokes = 25 });

            return categories;
        }
    }
}