using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery.AuxiliaryClasses
{
    public interface IDbUserQueries: ICRUD<User, string>
    {
        User ReadByEmail(string email);
    }
}
