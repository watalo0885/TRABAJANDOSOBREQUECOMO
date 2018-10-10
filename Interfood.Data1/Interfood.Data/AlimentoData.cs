using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using Interfood.Configuration;
using Interfood.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Interfood.Data
{
    public class AlimentoData
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

        public AlimentoData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public AlimentoData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public int Insert_Return_Scalar(string Codigo, string Nombre, string Estacional, string Tipo, Decimal Pequeña, Decimal Mediana, Decimal Grande, string Estado, int? TipoDeAlimentoId, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
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

        public int Insert_Return_Scalar(AlimentoEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityInsert.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityInsert.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityInsert.Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)EntityInsert.Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityInsert.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityInsert.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityInsert.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityInsert.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityInsert.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityInsert.OrdenDeVisualizacion);
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

        public bool Delete(int AlimentoId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
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

        public bool Delete(AlimentoEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_DeleteWhereExtendido");
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

        public bool Update(int? AlimentoId, string Codigo, string Nombre, string Tipo, string Estacional, Decimal? Pequeña, Decimal? Mediana, Decimal? Grande, string Estado, int? TipoDeAlimentoId, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
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

        public bool Update(AlimentoEntityKey EntityKey, AlimentoEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityUpdate.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityUpdate.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityUpdate.Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)EntityUpdate.Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityUpdate.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityUpdate.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityUpdate.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityUpdate.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityUpdate.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityUpdate.OrdenDeVisualizacion);
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

        public bool UpdateWhereExtendido(string WhereEx, AlimentoEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityUpdate.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityUpdate.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityUpdate.Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)EntityUpdate.Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityUpdate.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityUpdate.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityUpdate.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityUpdate.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityUpdate.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityUpdate.OrdenDeVisualizacion);
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

        public bool UpdateNull(int AlimentoId, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
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

        public bool UpdateNull(AlimentoEntityKey EntityKey, AlimentoEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipo, string Tipo, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)OpeCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)OpeTipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.AnsiString, (object)OpeEstacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
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

        public DataTable Search(AlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityFilter.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipo));
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityFilter.Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.AnsiString, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstacional));
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)EntityFilter.Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityFilter.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityFilter.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityFilter.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipo, string Tipo, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)OpeCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)OpeTipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.String, (object)OpeEstacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
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

        public DataTable SearchWithPagination(AlimentoEntityPaged EntityPaged, AlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityFilter.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipo));
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityFilter.Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstacional));
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)EntityFilter.Estacional);        
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityFilter.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityFilter.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityFilter.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipo, string Tipo, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)OpeCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)OpeTipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.String, (object)OpeEstacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
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

        public DataTable SearchCount(AlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityFilter.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipo));
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityFilter.Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstacional));
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)EntityFilter.Estacional);        
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityFilter.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityFilter.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityFilter.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipo, string Tipo, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)OpeCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)OpeTipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.String, (object)OpeEstacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
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

        public DataTable SearchCountWithPagination(AlimentoEntityPaged EntityPaged, AlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityFilter.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipo));
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityFilter.Tipo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstacional));
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)EntityFilter.Estacional);        
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityFilter.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityFilter.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityFilter.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
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

        public DataTable SearchOne(string OpeAlimentoId, int AlimentoId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
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

        public DataTable SearchOne(AlimentoEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Alimento_GetAll");
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

