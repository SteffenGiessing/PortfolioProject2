﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortfolioProject2.Models.DataInterfaces;
using PortfolioProject2.Models.DMOs;

namespace PortfolioProject2.Models.DataServices
{
    public class RatingsDataService : IRatings
    {
        public async Task<List<Ratings>> getRaitingById(string id)
        {
            var ctx = new DatabaseConnection();
            return await ctx.Ratings.FromSqlRaw("SELECT * FROM ratings WHERE titleid = {0}", id).ToListAsync();
        }
    }
}