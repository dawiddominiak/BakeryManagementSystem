using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Infrastructure.Serializers
{
    abstract public class DTOSerializer
    {
        public string Serialize(DTO.DTO dto)
        {
            var serializer = new XmlSerializer(dto.GetType());
            var writer = new StringWriter();
            serializer.Serialize(writer, dto);

            return writer.ToString();
        }

        protected DTO.DTO Deserialize(string xml, DTO.DTO dto)
        {
            var serializer = new XmlSerializer(dto.GetType());
            var reader = new StringReader(xml);
            var newDto = (DTO.DTO)serializer.Deserialize(reader);

            return newDto;
        }
    }
}
