namespace Shared.Logger
{
    public class Log
    {
        public string Message { get; }
        public string Stack { get; }
        public LogLevel LogLevel { get; }

        public Log(LogLevel logLevel, string message, string stack = null)
        {
            LogLevel = logLevel;
            Message = message;
            Stack = stack;
        }
    }

    public class Debug : Log
    {
        public Debug(string message, string stack = null) : base(LogLevel.Debug, message, stack)
        { }
    }

    public class Information : Log
    {
        public Information(string message, string stack = null) : base(LogLevel.Information, message, stack)
        { }
    }

    public class Warning : Log
    {
        public Warning(string message, string stack = null) : base(LogLevel.Warning, message, stack)
        { }
    }

    public class Error : Log
    {
        public Error(string message, string stack = null) : base(LogLevel.Error, message, stack)
        { }
    }

    public class Fatal : Log
    {
        public Fatal(string message, string stack = null) : base(LogLevel.Fatal, message, stack)
        { }
    }
    
    public enum LogLevel
    {
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Fatal = 5
    }
}
