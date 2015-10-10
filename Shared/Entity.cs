using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IEntity<in T>
    {
        bool SameIdentityAs(T other);
    }
}
