using System.Collections.Generic;
using Shared.Logger;

namespace Infrastructure.Logger
{
    public class LoggerManager
    {
        private static LoggerManager _instance;

        public Dictionary<LogLevel, List<ILogger>> Loggers { get; private set; } = new Dictionary<LogLevel, List<ILogger>>();

        public static LoggerManager Instance => _instance ?? (_instance = new LoggerManager());

        private LoggerManager()
        { }

        public void AddNewLogger(ILogger logger, LogLevel from = LogLevel.Debug, LogLevel to = LogLevel.Fatal)
        {
            var iStart = (int) from;
            var iEnd = (int) to;
            for (var i = iStart; i <= iEnd; i++)
            {
                var iLogLevel = (LogLevel) i;

                if (!Loggers.ContainsKey(iLogLevel))
                {
                    Loggers.Add(iLogLevel, new List<ILogger>());
                }
                Loggers[iLogLevel].Add(logger);
            }
        }

        public void NewLog(Log log)
        {
            var loggers = Loggers[log.LogLevel];
            loggers.ForEach(lggr => lggr.NewLogHandled(log));
        }
    }
}
