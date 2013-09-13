using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace the_facts_api.Models {
    public class JokeCategory {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public int Jokes { get; set; }
    }
}