using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    interface ValueObject<T>
    {
        bool sameValueAs(T other);
    }
}
