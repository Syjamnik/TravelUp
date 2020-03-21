using System;
using TravelUp.Model;

namespace TravelUp.Dto
{
    public class ArticleDto
    {

        public string Header { get; set; }
        public string Text { get; set; }

        public DateTime Created { get; protected set; }
        public DateTime Visited { get; protected set; }
        public UserDto Author { get; protected set; }

        public ArticleDto()
        {

        }

    }

}

