using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.DTO;
using Infrastructure.Serializers;

namespace InfrastructureUnitTests
{
    [TestClass]
    public class Serializers
    {
        [TestMethod]
        public void TaxRateSerializer_OfCorrectTaxRateDTO_ShouldCorrectlySerializeIt()
        {
            var taxRateDTO = new TaxRateDTO()
            {
                Rate = new Decimal(0.23),
                Guid = new Guid("cb3daccc-3eda-4d67-9813-5d102149ac8f")
            };

            var serializer = new TaxRateSerializer();
            var xml = serializer.Serialize(taxRateDTO);

            string xmlToCompare = @"<?xml version=""1.0"" encoding=""utf-16""?>
<TaxRateDTO xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Guid>cb3daccc-3eda-4d67-9813-5d102149ac8f</Guid>
  <Rate>0.23</Rate>
</TaxRateDTO>";
            Assert.AreEqual(xml, xmlToCompare);
        }
    }
}
