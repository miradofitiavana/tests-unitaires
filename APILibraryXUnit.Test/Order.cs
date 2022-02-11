using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;
using WebApplication.Models;

namespace APILibraryXUnit.Test
{
    public class Order : ValueObject
    {
        readonly Customer customer;
        readonly Pizza[] pizza;
        private Order(Customer customer, Pizza[] pizza)
        {
            this.customer = customer;
            this.pizza = pizza;
        }

        public static Result<Order> Create(Customer customer, Pizza[] pizza)
        {
            if (customer == null)
            {
                return Result.Failure<Order>("Le champ Customer ne doit pas etre null");
            }
            if (pizza == null)
            {
                return Result.Failure<Order>("Le champ Pizza ne doit pas etre null");
            }
            return new Order(customer, pizza);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.customer;
            yield return this.pizza;
        }
    }
}
