namespace WebApi_Authentication.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi_Authentication.Models.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi_Authentication.Models.Context.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApi_Authentication.Models.Context.AppDbContext context)
        {
            if (!context.AppUsers.Any())
            {
                AppUser user = new AppUser();
                user.Username = "admin";
                user.Password = "1234";
                user.Email = "admin@admin.com";

                context.AppUsers.Add(user);
                context.SaveChanges();

            }
            if (!context.Products.Any())
            {
                List<Product> products = new List<Product>
                {
                    new Product
                    {
                        ProductName="Çay",
                        UnitPrice=30
                    },
                    new Product
                    {
                        ProductName="Çikolata",
                        UnitPrice=10
                    },
                    new Product
                    {
                        ProductName="Ayakkabı",
                        UnitPrice=300
                    }
                };

                foreach (var product in products)
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }
            }
        }
    }
}
