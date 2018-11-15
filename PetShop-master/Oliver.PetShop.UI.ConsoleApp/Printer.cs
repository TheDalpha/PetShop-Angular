using Oliver.PetShop.Core;
using Oliver.PetShop.Core.ApplicationService;
using Oliver.PetShop.Core.ApplicationService.impl;
using Oliver.PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oliver.PetShop.UI.ConsoleApp
{
        public class Printer
        {
            IPetService _petService;

            public Printer(IPetService petService)
            {
                _petService = petService;
                StartUI();
                
            }

        void StartUI()
        {
            string[] menuItems =
            {
                "List All Pets",
                "Add Pet",
                "Delete Pet",
                "Edit Pet",
                "Search",
                "Sort By Price",
                "5 Cheapest Pets",
                "Exit"
            };

            var selection = ShowMenu(menuItems);
            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        GetAllPets();
                        break;
                    case 2:
                        AddPet();
                        break;
                    case 3:
                        Console.WriteLine("Type in id of the pet you want to delete");
                        DeletePet();
                        break;
                    case 4:
                        var idForEdit = PrintPetById();
                        var petToEdit = FindPetById(idForEdit);
                        Console.WriteLine($"Updating {petToEdit.Name}");
                        var newName = AskQuestion("Name: ");
                        var newType = AskQuestion("Type: ");
                        var newColor = AskQuestion("Color: ");
                        //var newPreviousOwner = AskQuestion("Previous Owner: ");
                        Console.WriteLine("Price: ");
                        double price;
                        while (!double.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Please insert a number");
                        }
                        var newPrice = price;
                        UpdatePet(idForEdit, newName, newType, newColor, newPrice);
                        break;
                    case 5:
                        Console.WriteLine("Type in type you want to find");
                        var type = Console.ReadLine();
                        Search(type);
                        break;
                    case 6:
                        SortByPrice();
                        break;
                    case 7:
                        CheapestPets();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye");
            Console.ReadLine();
        }

        private void Search(string type)
        {
            var pets = _petService.Search(type);
            foreach (var pet in pets)
            {
                if (pet.Type.Contains(type))
                {
                    Console.WriteLine("Name: {0} Type: {1} Price: {2:N}", pet.Name, pet.Type, pet.Price);
                }
                
            }
        }

        private void SortByPrice()
        {
            var pets = _petService.SortByPrice();
            foreach (var pet in pets)
            {
                Console.WriteLine("Name: {0} Type: {1} Price: {2:N}\n", pet.Name, pet.Type, pet.Price);
            }
        }

        private void UpdatePet(int id, string newName, string newType, string newColor, double newPrice)
        {
            var pet = FindPetById(id);
            pet.Name = newName;
            pet.Type = newType;
            pet.Color = newColor;
            //pet.PreviousOwner = newPreviousOwner;
            pet.Price = newPrice;
        }

        private Pet FindPetById(int id)
        {
            return _petService.ReadById(id);
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        int PrintPetById()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        private void CheapestPets()
        {
            var pets = _petService.Get5CheapestPets();
            foreach (var pet in pets)
            {
                Console.WriteLine("Name: {0} Type: {1} Price: {2:N}", pet.Name, pet.Type, pet.Price);
            }
        }

        

        private void DeletePet()
        {
            int id;

            while (!int.TryParse(Console.ReadLine(), out id)
                || id < 1)
            {
                Console.WriteLine("Select ID over 0");
            }
            _petService.DeletePet(id);
            
            Console.WriteLine("The Pet with id {0} is now deleted", id);
        }

        private void AddPet()
        {
            var pet = _petService.GetInstance();
            Console.WriteLine("What is the name of the pet?");
            pet.Name = Console.ReadLine();
            Console.WriteLine("What type of pet is it?");
            pet.Type = Console.ReadLine();
            Console.WriteLine("What Color is the pet?");
            pet.Color = Console.ReadLine();
            Console.WriteLine("Who was the previous owner?");
            //pet.PreviousOwner = Console.ReadLine();
            //Console.WriteLine("What is the price of the pet?");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Price must be a number");
            }
            pet.Price = price;
            _petService.AddPet(pet);
            Console.WriteLine("Pet has been added");
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("What do you want to do?\n---------------------------");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Select a number between 1-6");
            }

            return selection;
        }

        public void GetAllPets()
            {
            var listPets = _petService.GetPets();
            foreach (var pet in listPets)
            {
                Console.WriteLine("Id: {0}\nName: {1}\nType: {2}\nBirthday: {3}\nSold Date: {4}\nColor: {5}\nPrevious Owner: {6}\nPrice: {7:N}\n",
                    pet.Id, pet.Name, pet.Type, pet.Color, pet.PreviousOwner, pet.Price);
            }
            }
        }
    }

