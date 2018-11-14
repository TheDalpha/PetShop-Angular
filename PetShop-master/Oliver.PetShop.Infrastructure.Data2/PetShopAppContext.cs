using Microsoft.EntityFrameworkCore;
using Oliver.PetShop.Core;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Infrastructure.Data2
{
    public class PetShopAppContext: DbContext
    {
        public PetShopAppContext(DbContextOptions<PetShopAppContext> opt) : base(opt)
        {

        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
