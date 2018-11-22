using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.Core.Entity
{
    public class Pet
    {
        public Pet()
        {

        }

        public Pet(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }

        public Owner PreviousOwner { get; set; }

        public double Price { get; set; }
    }
}
