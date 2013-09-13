using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace the_facts_api.Repositories {
    public class JokesRepository {

        readonly Data.ChuckNorrisEntities _entities = new Data.ChuckNorrisEntities();

        public enum JokeType {
            clean = 0,
            xplicit = 1
        }

        public Models.Joke Random(JokeType jokeType) {
            var jokes = Get();
            return jokes.Where(c => c.Category.CategoryId == (int)jokeType)
                .OrderBy(x => Guid.NewGuid())
                .Take(1).FirstOrDefault();
        }

        public IQueryable<Models.Joke> Get() {

            return _entities.Jokes.Select(j => new Models.Joke {
                JokeId = j.JokeId,
                JokeText = j.JokeText,
                Category = j.Categories.Select(c => new Models.Category {
                    CategoryId = c.CategoryId,
                    Description = c.Description
                }).FirstOrDefault()
            });
        
        }
    }
}