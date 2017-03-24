using System.Diagnostics;

namespace OwinSelfHostAutofacNTLM
{
    public class Logger : ILogger
    {
        public void Write(string message, params object[] args)
        {
            Debug.WriteLine(message, args);
        }
    }
}