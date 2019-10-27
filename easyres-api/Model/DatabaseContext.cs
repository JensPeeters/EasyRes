﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace easyres_api.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                           : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Reservatie> Reservaties { get; set; }
        public DbSet<Bestelling> Bestellingen { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
    }
}
