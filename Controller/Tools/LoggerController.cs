using Infrastructure.Logger;

namespace Controller.Tools
{
    public class LoggerController
    {
        public LoggerManager Manager => LoggerManager.Instance;
    }
}
