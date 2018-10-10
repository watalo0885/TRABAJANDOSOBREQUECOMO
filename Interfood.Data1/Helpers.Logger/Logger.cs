using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Xml;

namespace Helpers.Logger
{

    [Serializable]
    public class Logger
    {
        private static string exceptionTitle = "Exception";
        private Guid instanceId;

        public Logger()
        {
            this.instanceId = Guid.NewGuid();
        }

        public void LogDebug(string message)
        {
            this.Log(message, LogCategories.Debug);
        }

        public void LogInfo(string message)
        {
            this.Log(message, LogCategories.Info);
        }

        public void LogMessage(XmlDocument message)
        {
            this.Log(message.OuterXml, LogCategories.Message);
        }

        public void LogMessage(string messageName, XmlDocument message)
        {
            this.Log(messageName, message.OuterXml, LogCategories.Message);
        }

        public void LogError(string message)
        {
            this.Log(message, LogCategories.Error);
        }

        public void LogFatalError(string message)
        {
            this.Log(message, LogCategories.FatalError);
        }

        public void LogException(Exception e)
        {
            this.Log(Helpers.Logger.Logger.exceptionTitle, e.ToString(), LogCategories.Error);
        }

        public void Log(string message, LogCategories category)
        {
            this.Log((string)null, message, category);
        }

        public void Log(string title, string message, LogCategories category)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(new LogEntry()
            {
                ActivityId = this.instanceId,
                Title = title,
                Message = message,
                ExtendedProperties = {
          {
            "InstanceId",
            (object) this.instanceId
          }
        },
                Categories = {
          category.ToString()
        }
            });
        }

        public static void LogErrorStatic(string message)
        {
            Helpers.Logger.Logger.LogStatic((string)null, message, LogCategories.Error);
        }

        public static void LogFatalErrorStatic(string message)
        {
            Helpers.Logger.Logger.LogStatic((string)null, message, LogCategories.FatalError);
        }

        public static void LogExceptionStatic(Exception e)
        {
            Helpers.Logger.Logger.LogStatic(Helpers.Logger.Logger.exceptionTitle, e.ToString(), LogCategories.Error);
        }

        public static void LogStatic(string title, string message, LogCategories category)
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(new LogEntry()
            {
                Title = title,
                Message = message,
                Categories = {
          category.ToString()
        }
            });
        }
    }
}
