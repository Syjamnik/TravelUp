using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Dto;

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
            Header = "HEADER";
            Text = "TEXT";
            Visited = DateTime.Now;
        }
        public Article(ArticleDto articleDto)
        {
            this.Header = articleDto.Header;
            this.Text = articleDto.Text;

        }
    }
}
