using System;

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

        public DateTime Birthday { get; set; }

        public DateTime SoldDate { get; set; }

        public string Color { get; set; }

        public Owner PreviousOwner { get; set; }

        public double Price { get; set; }
    }
}
