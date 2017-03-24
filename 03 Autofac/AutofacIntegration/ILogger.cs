using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacIntegration
{
    public interface ILogger
    {
        void Write(string message, params object[] args);
    }
}
