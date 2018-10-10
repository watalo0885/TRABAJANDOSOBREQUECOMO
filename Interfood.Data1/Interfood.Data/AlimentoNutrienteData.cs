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
    public class AlimentoNutrienteData
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

        public AlimentoNutrienteData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public AlimentoNutrienteData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public void Insert(int AlimentoId, int NutrienteId, Decimal? Cantidad, string FntID)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
                    this.DataBase.ExecuteNonQuery(storedProcCommand);
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

        public void Insert(AlimentoNutrienteEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityInsert.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityInsert.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityInsert.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityInsert.FntID);
                        
                    this.DataBase.ExecuteNonQuery(storedProcCommand);
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

        public bool Delete(int AlimentoId, int NutrienteId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
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

        public bool Delete(AlimentoNutrienteEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityKey.NutrienteId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_DeleteWhereExtendido");
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

        public bool Update(int? AlimentoId, int? NutrienteId, Decimal? Cantidad, string FntID)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
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

        public bool Update(AlimentoNutrienteEntityKey EntityKey, AlimentoNutrienteEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityKey.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityUpdate.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityUpdate.FntID);
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

        public bool UpdateWhereExtendido(string WhereEx, AlimentoNutrienteEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityUpdate.Cantidad);
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

        public bool UpdateNull(int AlimentoId, int NutrienteId, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
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

        public bool UpdateNull(AlimentoNutrienteEntityKey EntityKey, AlimentoNutrienteEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityKey.NutrienteId);
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad, string OpeFntID, string FntID)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFntID", DbType.AnsiString, (object)OpeFntID);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
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

        public DataTable Search(AlimentoNutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFntID", DbType.AnsiString, (object)EntityFilter.OpeFntID);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityFilter.FntID);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad, string OpeFntID, string FntID)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFntID", DbType.AnsiString, (object)OpeFntID);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
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

        public DataTable SearchWithPagination(AlimentoNutrienteEntityPaged EntityPaged, AlimentoNutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFntID));
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityFilter.FntID);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad, string OpeFntID, string FntID)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFntID", DbType.AnsiString, (object)OpeFntID);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
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

        public DataTable SearchCount(AlimentoNutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFntID));
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityFilter.FntID);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad, string OpeFntID, string FntID)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFntID", DbType.AnsiString, (object)OpeFntID);
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)FntID);
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

        public DataTable SearchCountWithPagination(AlimentoNutrienteEntityPaged EntityPaged, AlimentoNutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFntID", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFntID));
                    this.DataBase.AddInParameter(storedProcCommand, "FntID", DbType.AnsiString, (object)EntityFilter.FntID);
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

        public DataTable SearchOne(string OpeAlimentoId, int AlimentoId, string OpeNutrienteId, int NutrienteId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
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

        public DataTable SearchOne(AlimentoNutrienteEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityKey.NutrienteId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("AlimentoNutriente_GetAll");
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

