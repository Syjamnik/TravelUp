using System.Collections.Generic;
using TravelUp.Dto;

namespace TravelUp.Model
{
    public class Travel: Article, Queryable
    {
        public int Id { get; set; }
        public Rating Rating { get; } = new Rating();
        public IList<TravelUserVisitedList> OnVisitedList { get; set; }
        public IList<TravelUserFavouriteList> OnFavouriteList { get; set; }
        public Travel():base()
        {
        }

        /// <summary>
        /// author isn't set automatically  
        /// </summary>
        /// <param name="travelDto"></param>
        public Travel(TravelDto travelDto)
        {
            base.Text = travelDto.Text;
            base.Header = travelDto.Header;
        }
    }
}
