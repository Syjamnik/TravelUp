using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.Dto
{
    public class RatingDto
    {
        public long Votes { get; set; }
        public int NumberOfVotes { get; set; }
        public RatingDto(Rating ratingToConvert)
        {
            this.Votes = ratingToConvert.Votes;
            this.NumberOfVotes = NumberOfVotes;
        }
    }
}
