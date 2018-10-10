using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Helpers;

namespace Interfood.Configuration
{
    public static class InterfoodConfiguration
    {
        private static string _connectionStringNameInput;

        public static string ConnectionStringNameInput
        {
            get
            {
                return InterfoodConfiguration._connectionStringNameInput;
            }
        }

        static InterfoodConfiguration()
        {
            try
            {
                InterfoodConfiguration._connectionStringNameInput = ConfigurationManager.AppSettings["ConnectionStringNameInput"].ToString();
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }
    }

}
