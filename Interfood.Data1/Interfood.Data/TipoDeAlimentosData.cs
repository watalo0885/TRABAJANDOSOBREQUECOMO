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
    public class TipoDeAlimentosData
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

        public TipoDeAlimentosData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public TipoDeAlimentosData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public int Insert_Return_Scalar(string TipoDeAlimento, int OrdenDeVisualizacion, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public int Insert_Return_Scalar(TipoDeAlimentosEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityInsert.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityInsert.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityInsert.Estado);
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

        public bool Delete(int TipoDeAlimentoId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
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

        public bool Delete(TipoDeAlimentosEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityKey.TipoDeAlimentoId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_DeleteWhereExtendido");
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

        public bool Update(int? TipoDeAlimentoId, string TipoDeAlimento, int? OrdenDeVisualizacion, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public bool Update(TipoDeAlimentosEntityKey EntityKey, TipoDeAlimentosEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityKey.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityUpdate.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityUpdate.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityUpdate.Estado);
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

        public bool UpdateWhereExtendido(string WhereEx, TipoDeAlimentosEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityUpdate.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityUpdate.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityUpdate.Estado);
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

        public bool UpdateNull(int TipoDeAlimentoId, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
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

        public bool UpdateNull(TipoDeAlimentosEntityKey EntityKey, TipoDeAlimentosEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityKey.TipoDeAlimentoId);
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable Search(TipoDeAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable SearchWithPagination(TipoDeAlimentosEntityPaged EntityPaged, TipoDeAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable SearchCount(TipoDeAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable SearchCountWithPagination(TipoDeAlimentosEntityPaged EntityPaged, TipoDeAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
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

        public DataTable SearchOne(string OpeTipoDeAlimentoId, int TipoDeAlimentoId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
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

        public DataTable SearchOne(TipoDeAlimentosEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityKey.TipoDeAlimentoId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("TipoDeAlimentos_GetAll");
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
