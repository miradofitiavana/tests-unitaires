using APILibrary.Test.Mock.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;

namespace APILibrary.Test.Mock
{
    public class MockDbContext : EatDbContext
    {
        public MockDbContext(DbContextOptions options) : base(options)
        {
        }

        public static MockDbContext GetDbContext(bool withData = true)
        {
            var options = new DbContextOptionsBuilder().UseInMemoryDatabase("dbtest").Options;
            var db = new MockDbContext(options);

            if (withData)
            {
                db.Pizzas.Add(new PizzaMock
                {
                    Name = "Pizza 4 fromages",
                    Price = 12,
                    Topping = "4 fromages",
                    DateCreation = new System.DateTime()
                });

                db.Pizzas.Add(new PizzaMock
                {
                    Name = "Pizza 2",
                    Price = 11,
                    Topping = "Pizza 12 12",
                    DateCreation = new System.DateTime()
                });

                db.Pizzas.Add(new PizzaMock
                {
                    Name = "Pizza 3",
                    Price = 15,
                    Topping = "Pizza 3 3 3",
                    DateCreation = new System.DateTime()
                });

                db.SaveChanges();
            }

            return db;
        }
    }
}
