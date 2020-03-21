using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.Dto
{
    public class TravelDto:ArticleDto
    {
        public Rating Rating { get; }

        public TravelDto(Travel travelToConvert)
        {
            base.Header =  travelToConvert.Header;
            base.Text =    travelToConvert.Text;
            base.Created = travelToConvert.Created;
            base.Visited = travelToConvert.Visited;
            base.Author = new UserDto(travelToConvert.Author);

            this.Rating = travelToConvert.Rating;
        }
        public TravelDto()
        {

        }
    }
}
