﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelUp.Model;

namespace TravelUp.Data.DbQuery.AuxiliaryClasses
{
    public interface IDbFavouriteMTMQueries
    {
        Task Create(TravelUserFavouriteList item);
        Task Delete(string idUser);
    }
}
