using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Serializers
{
    public class TaxRateSerializer : DTOSerializer
    {
        public DTO.TaxRateDTO Deserialize(string xml)
        {

            return (DTO.TaxRateDTO)this.Deserialize(xml, new DTO.TaxRateDTO());
        }
    }
}
