using APILibrary.Test.Mock;
using APILibrary.Test.Mock.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication.Controllers;
using Xunit;

namespace APILibraryXUnit.Test
{
    [Trait("Création d'une pizza", "")]
    public class PizzaTest
    {
        private MockDbContext _db;
        private PizzasController _controller;

        public PizzaTest()
        {
            _db = MockDbContext.GetDbContext();

            var httpContext = new DefaultHttpContext();
            _controller = new PizzasController(_db)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext,
                }
            };
        }

        [Fact(DisplayName = "Je peux créer une commande")]
        public async Task TestCreate()
        {
            PizzaMock pizza = new PizzaMock
            {
                Name = "Pizza Regina",
                Topping = "tomate, mozzarella, jambon, champignons",
                Price = 12,
                DateCreation = new System.DateTime()
            };
            var actionResult = await _controller.CreateItem(pizza);
            var result = actionResult.Result as ObjectResult;

            var okResult = result.Should().BeOfType<CreatedResult>().Subject;

        }
    }
}
