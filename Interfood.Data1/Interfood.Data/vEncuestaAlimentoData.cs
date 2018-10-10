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
    public class vEncuestaAlimentoData
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

        public vEncuestaAlimentoData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public vEncuestaAlimentoData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado, string OpeTipo, string Tipo)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)OpeCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)OpeVecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)OpeVecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)OpeVecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)OpePorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)OpePorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)OpePorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)OpeTamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)OpeTipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
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

        public DataTable Search(vEncuestaAlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityFilter.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorMes));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityFilter.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorSemana));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityFilter.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorDia));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityFilter.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionPequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityFilter.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityFilter.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityFilter.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTamañoPorcion));
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityFilter.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityFilter.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityFilter.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityFilter.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipo));
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityFilter.Tipo);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado, string OpeTipo, string Tipo)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)OpeCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)OpeVecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)OpeVecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)OpeVecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)OpePorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)OpePorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)OpePorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)OpeTamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)OpeTipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
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

        public DataTable SearchWithPagination(vEncuestaAlimentoEntityPaged EntityPaged, vEncuestaAlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityFilter.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorMes));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityFilter.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorSemana));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityFilter.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorDia));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityFilter.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionPequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityFilter.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityFilter.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityFilter.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTamañoPorcion));
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityFilter.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityFilter.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityFilter.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityFilter.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipo));
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityFilter.Tipo);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado, string OpeTipo, string Tipo)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)OpeCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)OpeVecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)OpeVecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)OpeVecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)OpePorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)OpePorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)OpePorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)OpeTamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)OpeTipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
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

        public DataTable SearchCount(vEncuestaAlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityFilter.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorMes));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityFilter.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorSemana));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityFilter.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorDia));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityFilter.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionPequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityFilter.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityFilter.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityFilter.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTamañoPorcion));
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityFilter.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityFilter.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityFilter.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityFilter.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipo));
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityFilter.Tipo);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado, string OpeTipo, string Tipo)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)OpeCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)OpeVecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)OpeVecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)OpeVecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)OpePorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)OpePorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)OpePorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)OpeTamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)OpePequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)OpeMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)OpeGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)OpeTipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)OpeOrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)OpeTipo);
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)Tipo);
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

        public DataTable SearchCountWithPagination(vEncuestaAlimentoEntityPaged EntityPaged, vEncuestaAlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "Codigo", DbType.AnsiString, (object)EntityFilter.Codigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorMes));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityFilter.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorSemana));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityFilter.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorDia));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityFilter.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionPequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityFilter.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityFilter.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityFilter.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTamañoPorcion));
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityFilter.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "Pequeña", DbType.Decimal, (object)EntityFilter.Pequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "Mediana", DbType.Decimal, (object)EntityFilter.Mediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "Grande", DbType.Decimal, (object)EntityFilter.Grande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimentoId", DbType.Int32, (object)EntityFilter.TipoDeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrdenDeVisualizacion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrdenDeVisualizacion));
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeVisualizacion", DbType.Int32, (object)EntityFilter.OrdenDeVisualizacion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipo));
                    this.DataBase.AddInParameter(storedProcCommand, "Tipo", DbType.AnsiString, (object)EntityFilter.Tipo);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaAlimento_GetAll");
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
