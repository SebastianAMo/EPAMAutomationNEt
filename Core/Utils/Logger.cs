using log4net;
using log4net.Config;
using System.Reflection;

namespace Core.Utils
{
    public static class Logger
    {
        static Logger()
        {
            var logConfigPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Log.config");
            XmlConfigurator.Configure(new FileInfo(logConfigPath));
        }

        public static ILog GetLogger<T>()
        {
            return LogManager.GetLogger(typeof(T));
        }

        public static ILog GetLogger(string name)
        {
            return LogManager.GetLogger(name);
        }
    }

}
