using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfood.Data;
using System;
using System.ComponentModel;

namespace Interfood.Business
{
    [DataObject]
    public class CustomBus
    {
        private string _nameConnection;

        public CustomBus()
        {
            this._nameConnection = string.Empty;
        }

        public CustomBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private CustomData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new CustomData();
                return new CustomData(this._nameConnection);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._nameConnection = NameNewConnection;
        }

        public void InsertarAlimentos(int EncuestaNro)
        {
            try
            {
                this.CreateDataAccess().InsertarAlimentos(EncuestaNro);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }
    }
}
