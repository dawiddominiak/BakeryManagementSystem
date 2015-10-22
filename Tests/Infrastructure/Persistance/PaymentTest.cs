using System;
using System.Collections.Generic;
using Infrastructure.Persistance;
using Infrastructure.Persistance.Payment;
using Infrastructure.Persistance.Shop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infrastructure.Persistance
{
    /// <summary>
    /// Unit tests of Payment.
    /// </summary>
    [TestClass]
    public class PaymentTest
    {
        public BakeryContext BakeryContext;

        public PaymentTest()
        {
            BakeryContext = new BakeryContext();
        }

        [TestMethod]
        public void AddAndReadPayment()
        {
            var ownerAddress = new OwnerAddress
            {
            };

            var shopAddress = new ShopAddress();

            var owner = new Owner
            {
                Code = Guid.NewGuid().ToString(),
                Name = "Owner",
                OwnerAddress = ownerAddress
            };

            var shop = new Shop
            {
                Code = Guid.NewGuid().ToString(),
                Owner = owner,
                Name = "Żabka",
                ShopAddress = shopAddress,
                ShopPhones = new List<ShopPhone>
                {
                    new ShopPhone{Number = Guid.NewGuid().ToString()},
                    new ShopPhone{Number = Guid.NewGuid().ToString()}
                }
            };

            var payment = new Payment
            {
                PaymentId = Guid.NewGuid(),
                Amount = 100m,
                DateTime = new DateTime(2015, 11, 1),
                PaymentType = "direct",
                Shop = shop
            };

            BakeryContext.Payments.Add(payment);
            BakeryContext.SaveChanges();
        }
    }
}
