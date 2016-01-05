using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avanzar.Welkin.Core.Authentication
{
    public interface IAuthenticate
    {
        string GetApplicationAccountToken(string resourceUrl);
    }
}
