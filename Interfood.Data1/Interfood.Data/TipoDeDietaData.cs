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
    public class TipoDeDietaData
    {
        private Database _database;

        private Database DataBase
        {
            get
            {
                return this._database;
            }
            set
            {
                this._database = value;
            }
        }

        public TipoDeDietaData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public TipoDeDietaData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public int Insert_Return_Scalar(string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    return (int)this.DataBase.ExecuteScalar(storedProcCommand);
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

        public int Insert_Return_Scalar(TipoDeDietaEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityInsert.TipoDeDieta);
                    return (int)this.DataBase.ExecuteScalar(storedProcCommand);
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

        public bool Delete(int TipoDeDietaId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool Delete(TipoDeDietaEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityKey.TipoDeDietaId);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_DeleteWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool Update(int? TipoDeDietaId, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool Update(TipoDeDietaEntityKey EntityKey, TipoDeDietaEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityKey.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityUpdate.TipoDeDieta);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool UpdateWhereExtendido(string WhereEx, TipoDeDietaEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityUpdate.TipoDeDieta);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool UpdateNull(int TipoDeDietaId, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "FieldList", DbType.String, (object)ListaDeCampos);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool UpdateNull(TipoDeDietaEntityKey EntityKey, TipoDeDietaEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityKey.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "FieldList", DbType.String, (object)EntityUpdateNullFields.FieldList);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityUpdateNullFields.WhereExtendido);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)OpeTipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable Search(TipoDeDietaEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDietaId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityFilter.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    if (PageSize < 1)
                        PageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                    if (PageReturn < 1)
                        PageReturn = int.Parse(ConfigurationManager.AppSettings["PageReturn"]);
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)PageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)PageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)OpeTipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable SearchWithPagination(TipoDeDietaEntityPaged EntityPaged, TipoDeDietaEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDietaId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityFilter.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)OpeTipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable SearchCount(TipoDeDietaEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDietaId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityFilter.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    if (PageSize < 1)
                        PageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                    if (PageReturn < 1)
                        PageReturn = int.Parse(ConfigurationManager.AppSettings["PageReturn"]);
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)PageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)PageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)OpeTipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable SearchCountWithPagination(TipoDeDietaEntityPaged EntityPaged, TipoDeDietaEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDietaId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityFilter.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable SearchOne(string OpeTipoDeDietaId, int TipoDeDietaId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

        public DataTable SearchOne(TipoDeDietaEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityKey.TipoDeDietaId);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeDieta_GetAll");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
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

