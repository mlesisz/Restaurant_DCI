using System.Collections.Generic;
using System.Data.Entity;
using Restaurant_DCI.Roles;

namespace Restaurant_DCI.Models
{
    public class DB_EntitiesSeeder : DropCreateDatabaseIfModelChanges<DB_Entities>
    {
        protected override void Seed(DB_Entities context)
        {
            Account a1 = new Account()
            {
                idUser = 1,
                FirstName = "Szef",
                LastName = "Kuchni",
                Email = "Chef@wp.pl",
                Password = RegisterUserTraits.GetMD5("Chef"),
                Permissions = Permissions.Chef
            };

            context.Users.Add(a1);

            List<Product> products = new List<Product>() {
                new Product() { ProductId = 1, Name ="Burger InFormal z frytkami i sosem aioli", Description = "Wołowina Angus, sałata, pomidor, ogórek kiszony, karmelizowana czerwona cebula, sos musztardowy i BBQ", Category ="Dania główne", Price = 33.00m, Recipe="" },
            new Product() { ProductId = 2, Name ="Vege Burger z frytkami i sosem Aïoli", Description = "Kozi ser, chipsy z warzyw, pieczony burak, mus z awokado, sałata, sos żurawinowy", Category ="Dania główne", Price = 31.0m, Recipe="" },
            new Product() { ProductId = 3, Name ="Noga kaczki confit", Description = "Z purée ziemniaczanym, buraczkami i sosem wiśniowym", Category ="Dania główne", Price = 45.0m, Recipe="" },
            new Product() { ProductId = 4, Name ="Krewetki w sosie winno-maślanym z chorizo", Description = "Krewetki w sosie winno-maślanym z chorizo", Category ="Przystawki", Price = 38.0m, Recipe="" },
            new Product() { ProductId = 5, Name ="Focaccia z rozmarynem", Description = "I sosem pomidorowym", Category ="Przystawki", Price = 14.0m, Recipe="" },
            new Product() { ProductId = 6, Name ="Bruschetta z krewetkami", Description = "Guacamole i pomidorkami cherry", Category ="Przystawki", Price = 29.0m, Recipe="" },
            new Product() { ProductId = 7, Name ="Sałata Cezar z kurczakiem", Description = "Bekonem i parmezanem", Category ="Sałaty", Price = 30.0m, Recipe="" },
            new Product() { ProductId = 8, Name ="Sałata Cezar z krewetkami", Description = "Bekonem i parmezanem", Category ="Sałaty", Price = 39.0m, Recipe="" },
            new Product() { ProductId = 9, Name ="Sałata z pieczonym kozim serem", Description = "Burakiem, orzechami i dressingiem żurawinowym", Category ="Sałaty", Price = 34.0m, Recipe="" },
            new Product() { ProductId = 10, Name ="Krem z pieczonego kalafiora", Description = "Z oliwą truflową i parmezanem", Category ="Zupy", Price = 19.0m, Recipe="" },
            new Product() { ProductId = 11, Name ="Bulion", Description = "Z domowymi kluseczkami", Category ="Zupy", Price = 17.0m, Recipe="" },
            new Product() { ProductId = 12, Name ="Chłodnik litewski", Description = "Chłodnik litewski", Category ="Zupy", Price = 17.0m, Recipe="" },
            new Product() { ProductId = 13, Name ="Nemesis z konfiturą wiśniową", Description = "Nemesis z konfiturą wiśniową", Category ="Desery", Price = 21.0m, Recipe="" },
            new Product() { ProductId = 14, Name ="Sernik z białą czekoladą", Description = "Owocami i sorbetem malinowym", Category ="Desery", Price = 19.0m, Recipe="" },
            new Product() { ProductId = 15, Name ="Fasolka szparagowa", Description = "Fasolka szparagowa", Category ="Dodatki", Price = 10.0m, Recipe="" }, };



            base.Seed(context);
        }
    }
}