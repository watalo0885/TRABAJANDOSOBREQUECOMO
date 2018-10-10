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
    public class vAlimentosData
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

        public vAlimentosData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public vAlimentosData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_Search");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
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

        public DataTable Search(vAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_Search");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento,string OpeEstacional, string Estacional,  string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
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

        public DataTable SearchWithPagination(vAlimentosEntityPaged EntityPaged, vAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_SearchCount");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.String, (object)OpeEstacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacional", DbType.AnsiString, (object)Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable SearchCount(vAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_SearchCount");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstacional", DbType.String, (object)OpeEstacional);
                    this.DataBase.AddInParameter(storedProcCommand, "Estacioanl", DbType.AnsiString, (object)Estacional);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable SearchCountWithPagination(vAlimentosEntityPaged EntityPaged, vAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
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

        public DataTable GetAll(string OrdenDeRegistros)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentos_GetAll");
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
