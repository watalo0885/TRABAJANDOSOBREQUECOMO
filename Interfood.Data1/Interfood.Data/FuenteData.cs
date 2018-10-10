using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using Interfood.Configuration;
using Interfood.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Interfood.Data
{
    public class FuenteData
    {
        private Database _database;

        public Database Database
        {
            get { return _database; }
            set { _database = value; }
        }

        public FuenteData()
        {
            this.Database = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public FuenteData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public void Insert(string fntID, string Nombre)
        {
            DbCommand storeProcCommand = this._database.GetStoredProcCommand("Fuente_Insert");
            try
            {
                using (storeProcCommand)
                {
                    this.Database.AddInParameter(storeProcCommand, "fntID", DbType.AnsiString, (object)fntID);
                    this.Database.AddInParameter(storeProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.Database.ExecuteNonQuery(storeProcCommand);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception exep)
            {
                throw exep;
            }
        }

        public void Insert(FuenteEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityInsert.FntID);
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityInsert.Nombre);
                    this.Database.ExecuteNonQuery(storedProcCommand);
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception exec)
            { throw exec; }

        }

        public bool Delete(string FntID)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                    return Convert.ToBoolean(this.Database.ExecuteNonQuery(storedProcCommand));
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception exec)
            { throw exec; }
        }

        public bool Delete(FuenteEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityKey.FntID);
                    return Convert.ToBoolean(this.Database.ExecuteNonQuery(storedProcCommand));
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteWhereExtendido(string WhereEx)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuetne_DeleteWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    return Convert.ToBoolean(this.Database.ExecuteNonQuery(storedProcCommand));
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(string FntID, string Nombre)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_UpdateOptionalFields");
                try 
        	        {	        
	                    using(storedProcCommand){
                            this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                            this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                            return Convert.ToBoolean(this.Database.ExecuteNonQuery(storedProcCommand));
                        }
	                }       
	            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(FuenteEntityKey EntityKey, FuenteEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityKey.FntID);
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityUpdate.Nombre);
                    return Convert.ToBoolean(this.Database.ExecuteNonQuery(storedProcCommand));
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateWhereExtendido(string WhereEx, FuenteEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityUpdate.Nombre);
                    return Convert.ToBoolean(this.Database.ExecuteNonQuery(storedProcCommand));
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateNull(string FntID, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                    this.Database.AddInParameter(storedProcCommand, "FieldList", DbType.String, (object)ListaDeCampos);
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    return Convert.ToBoolean(this.Database.ExecuteNonQuery(storedProcCommand));
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateNull(FuenteEntityKey EntityKey, FuenteEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityKey.FntID);
                    this.Database.AddInParameter(storedProcCommand, "FieldList", DbType.String, (object)EntityUpdateNullFields.FieldList);
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityUpdateNullFields.WhereExtendido);
                    return Convert.ToBoolean(this.Database.ExecuteNonQuery(storedProcCommand));
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeFntID, string FntID, string OpeNombre, string Nombre)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)OpeFntID);
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                    this.Database.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Search(FuenteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFntID));
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityFilter.FntID);
                    this.Database.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeFntID, string FntID, string OpeNombre, string Nombre)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    if (PageSize < 1)
                        PageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                    if (PageReturn < 1)
                        PageReturn = int.Parse(ConfigurationManager.AppSettings["PageReturn"]);
                    this.Database.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)PageSize);
                    this.Database.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)PageReturn);
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)OpeFntID);
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                    this.Database.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchWithPagination(FuenteEntityPaged EntityPaged, FuenteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.Database.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFntID));
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityFilter.FntID);
                    this.Database.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeFntID, string FntID, string OpeNombre, string Nombre)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)OpeFntID);
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                    this.Database.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchCount(FuenteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFntID));
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityFilter.FntID);
                    this.Database.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeFntID, string FntID, string OpeNombre, string Nombre)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    if (PageSize < 1)
                        PageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                    if (PageReturn < 1)
                        PageReturn = int.Parse(ConfigurationManager.AppSettings["PageReturn"]);
                    this.Database.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)PageSize);
                    this.Database.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)PageReturn);
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)OpeFntID);
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                    this.Database.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchCountWithPagination(FuenteEntityPaged EntityPaged, FuenteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.Database.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.Database.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFntID));
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityFilter.FntID);
                    this.Database.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.Database.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchOne(string OpeFntID, string FntID)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)"=");
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchOne(FuenteEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)"=");
                    this.Database.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityKey.FntID);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAll(string OrdenDeRegistros)
        {
            DbCommand storedProcCommand = this.Database.GetStoredProcCommand("Fuente_GetAll");
            try
            {
                using (storedProcCommand)
                {
                    this.Database.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    return this.Database.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
