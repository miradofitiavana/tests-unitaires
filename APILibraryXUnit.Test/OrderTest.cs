using System;
using Xunit;
using FluentAssertions;
using WebApplication.Models;

namespace APILibraryXUnit.Test
{

    [Trait("creation d'une commande", "")]
    public class OrderTest
    {
        [Fact(DisplayName = "je peux creer une commande")]
        public void Je_peux_creer_une_commande()
        {
            //given
            var pizza = new Pizza();
            var customer = new Customer();

            //when
            var result = Order.Create(customer,pizza);

            //then

            result.IsSuccess.Should().BeTrue();
        }

        [Fact(DisplayName = "je ne peux pas creer une commande sans customer")]
        public void Je_ne_peux_pas_creer_une_commande_sans_customer()
        {
            //given
            var pizza = new Pizza();
            var customer = new Customer();
            
            //when
            var result = Order.Create(null, pizza);

            //then
            result.Error.Should().Be("Le champ Customer ne doit pas etre null");
        }

        [Fact(DisplayName = "je ne peux pas creer une commande sans pizza")]
        public void Je_ne_peux_pas_creer_une_commande_sans_pizza()
        {
            //given
            var pizza = new Pizza();
            var customer = new Customer();

            //when
            var result = Order.Create(customer, null);

            //then
            result.Error.Should().Be("Le champ Pizza ne doit pas etre null");
        }
    }
}