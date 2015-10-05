using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Infrastructure.DTO
{
    class ProductDTO : DTO
    {
        public ProductDTO() : base() { }

        [XmlElement(IsNullable=true)]
        public string Code { get; set; }

        [XmlElement(IsNullable=false)]
        public string Name { get; set; }

        [XmlElement(IsNullable=false)]
        public Guid TaxRateID { get; set; }
    }
}
