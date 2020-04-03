using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.Services
{
    public class CalculateRating
    {
        public int Calculate(int numberOfVotes, long score)
        {
            double result;

            if (numberOfVotes <= 0)
                return 0;
            else
                result = score / numberOfVotes;

           return (int) Math.Round(result,0);
        }
    }
}
