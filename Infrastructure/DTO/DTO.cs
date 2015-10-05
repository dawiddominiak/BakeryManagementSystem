using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public abstract class DTO
    {
        public DTO()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; set; }
    }
}
