namespace AutoLotDAL.Migrations
{
    using AutoLotDAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AutoLotDAL.EF.AutoLotEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AutoLotDAL.EF.AutoLotEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var customers = new List<Customers>
            {
            new Customers {FirstName = "Dave", LastName = "Brenner"},
            new Customers {FirstName = "Matt", LastName ="Walton"},
            new Customers {FirstName = "Steve", LastName = "Hagen" },
            new Customers {FirstName = "Pat", LastName = "Walton"},
            new Customers {FirstName = "Bad", LastName = "Customer"}
            };
            customers.ForEach(x => context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName }, x));

            var cars = new List<Test>
            {
                new Test {Make = "VW", Color = "Black", PetName = "Zippy"},
                new Test {Make = "Ford", Color ="Rust", PetName = "Rusty"},
                new Test {Make = "Saab", Color = "Black" , PetName = "Mel"},
                new Test {Make = "Yugo", Color = "Yellow ", PetName = "Clunker"},
                new Test {Make ="BMW", Color = "Black", PetName = "Bimmer"},
                new Test {Make = "BMW", Color = "Green", PetName = "Hank"},
                new Test {Make = "BMW", Color = "Pink", PetName = "Pinky"},
                new Test {Make = "Pinto", Color = "Black ", PetName = "Pete"},
                new Test {Make = "Yugo", Color = "Brown" , PetName = "Brownie" },
            };
            context.Cars.AddOrUpdate(c => new { c.Make, c.Color }, cars.ToArray());

            var orders = new List<Orders>
            {
                new Orders {Car = cars[0], Customer = customers[0]},
                new Orders {Car = cars[1], Customer = customers[1]},
                new Orders {Car = cars[2], Customer = customers[2]},
                new Orders {Car = cars[3], Customer = customers[3]},
            };
            orders.ForEach(x => context.Orders.AddOrUpdate(c => new { c.CarID, c.CustomerID }, x));
            context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName },
                new CreditRisks
                {
                    Id = customers[4].Id,
                    FirstName = customers[4].FirstName,
                    LastName = customers[4].LastName,
                });
        }
    }
}
