using System;

namespace TravelUp.Model
{
    public class Article
    {

        public string Header { get; set; }
        public string Text { get; set; }
        public readonly DateTime Created = DateTime.Now;
        public DateTime Visited { get; }
        public User Author { get; }

        public Article()
        {

        }
    }
}
