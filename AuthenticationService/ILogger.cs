using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService
{
    public interface ILogger
    {
        void WriteEvent(string EventMessage);

        void WriteError(string ErrorMessage);
    }
}
