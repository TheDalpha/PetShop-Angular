﻿using Microsoft.EntityFrameworkCore;
using Oliver.PetShop.Core;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Infrastructure.Data2
{
    public class PetShopAppContext : DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>().HasOne(p => p.PreviousOwner).WithMany(o => o.AllPets).OnDelete(DeleteBehavior.SetNull);


        }
    }
}