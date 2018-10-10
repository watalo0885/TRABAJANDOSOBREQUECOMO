using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfood.Data;
using Interfood.Entities;
using System;
using System.ComponentModel;
using System.Data;

namespace Interfood.Business
{
    [DataObject]
    public class vEncuestaAlimentoBus
    {
        private string _nameConnection;

        public vEncuestaAlimentoBus()
        {
            this._nameConnection = string.Empty;
        }

        public vEncuestaAlimentoBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private vEncuestaAlimentoData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new vEncuestaAlimentoData();
                return new vEncuestaAlimentoData(this._nameConnection);
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

        public vEncuestaAlimentoEntityInfo.vEncuestaAlimentoEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            vEncuestaAlimentoEntityInfo[] pArray = new vEncuestaAlimentoEntityInfo[dt.Rows.Count];
            try
            {
                for (int index = 0; index < dt.Rows.Count; ++index)
                    pArray[index] = this.DataRowToEntityInfo(dt.Rows[index]);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return new vEncuestaAlimentoEntityInfo.vEncuestaAlimentoEntityInfoList(pArray);
        }

        public vEncuestaAlimentoEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            vEncuestaAlimentoEntityInfo alimentoEntityInfo = new vEncuestaAlimentoEntityInfo();
            try
            {
                alimentoEntityInfo.EncuestaNro = (int)dr["EncuestaNro"];
                alimentoEntityInfo.AlimentoId = (int)dr["AlimentoId"];
                alimentoEntityInfo.Codigo = (string)dr["Codigo"];
                alimentoEntityInfo.Nombre = (string)dr["Nombre"];
                alimentoEntityInfo.Nunca = Convert.IsDBNull(dr["Nunca"]) ? new bool?() : (bool?)dr["Nunca"];
                alimentoEntityInfo.VecesPorMes = Convert.IsDBNull(dr["VecesPorMes"]) ? new int?() : (int?)dr["VecesPorMes"];
                alimentoEntityInfo.VecesPorSemana = Convert.IsDBNull(dr["VecesPorSemana"]) ? new int?() : (int?)dr["VecesPorSemana"];
                alimentoEntityInfo.VecesPorDia = Convert.IsDBNull(dr["VecesPorDia"]) ? new int?() : (int?)dr["VecesPorDia"];
                alimentoEntityInfo.PorcionPequeña = Convert.IsDBNull(dr["PorcionPequeña"]) ? new bool?() : (bool?)dr["PorcionPequeña"];
                alimentoEntityInfo.PorcionMediana = Convert.IsDBNull(dr["PorcionMediana"]) ? new bool?() : (bool?)dr["PorcionMediana"];
                alimentoEntityInfo.PorcionGrande = Convert.IsDBNull(dr["PorcionGrande"]) ? new bool?() : (bool?)dr["PorcionGrande"];
                alimentoEntityInfo.TamañoPorcion = Convert.IsDBNull(dr["TamañoPorcion"]) ? new Decimal?() : (Decimal?)dr["TamañoPorcion"];
                alimentoEntityInfo.Cantidad = Convert.IsDBNull(dr["Cantidad"]) ? new Decimal?() : (Decimal?)dr["Cantidad"];
                alimentoEntityInfo.Pequeña = (Decimal)dr["Pequeña"];
                alimentoEntityInfo.Mediana = (Decimal)dr["Mediana"];
                alimentoEntityInfo.Grande = (Decimal)dr["Grande"];
                alimentoEntityInfo.TipoDeAlimentoId = Convert.IsDBNull(dr["TipoDeAlimentoId"]) ? new int?() : (int?)dr["TipoDeAlimentoId"];
                alimentoEntityInfo.OrdenDeVisualizacion = Convert.IsDBNull(dr["OrdenDeVisualizacion"]) ? new int?() : (int?)dr["OrdenDeVisualizacion"];
                alimentoEntityInfo.Estado = (string)dr["Estado"];
                alimentoEntityInfo.Tipo = Convert.IsDBNull(dr["Tipo"]) ? (string)null : (string)dr["Tipo"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return alimentoEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado, string OpeTipo, string Tipo)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeNunca, Nunca, OpeVecesPorMes, VecesPorMes, OpeVecesPorSemana, VecesPorSemana, OpeVecesPorDia, VecesPorDia, OpePorcionPequeña, PorcionPequeña, OpePorcionMediana, PorcionMediana, OpePorcionGrande, PorcionGrande, OpeTamañoPorcion, TamañoPorcion, OpeCantidad, Cantidad, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeOrdenDeVisualizacion, OrdenDeVisualizacion, OpeEstado, Estado, OpeTipo, Tipo);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(vEncuestaAlimentoEntityFilter EntityFilter)
        {
            try
            {
                return this.CreateDataAccess().Search(EntityFilter);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public void Search(vEncuestaAlimentoEntityFilter EntityFilter, out vEncuestaAlimentoEntityInfo.vEncuestaAlimentoEntityInfoList listaAGenerar)
        {
            try
            {
                listaAGenerar = this.DataTableToListOfEntityInfo(this.CreateDataAccess().Search(EntityFilter));
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public vEncuestaAlimentoEntityInfo.vEncuestaAlimentoEntityInfoList Search(vEncuestaAlimentoEntityFilter EntityFilter, bool NoUtilizar)
        {
            try
            {
                return this.DataTableToListOfEntityInfo(this.CreateDataAccess().Search(EntityFilter));
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado, string OpeTipo, string Tipo)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeNunca, Nunca, OpeVecesPorMes, VecesPorMes, OpeVecesPorSemana, VecesPorSemana, OpeVecesPorDia, VecesPorDia, OpePorcionPequeña, PorcionPequeña, OpePorcionMediana, PorcionMediana, OpePorcionGrande, PorcionGrande, OpeTamañoPorcion, TamañoPorcion, OpeCantidad, Cantidad, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeOrdenDeVisualizacion, OrdenDeVisualizacion, OpeEstado, Estado, OpeTipo, Tipo);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(vEncuestaAlimentoEntityPaged EntityPaged, vEncuestaAlimentoEntityFilter EntityFilter)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(EntityPaged, EntityFilter);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado, string OpeTipo, string Tipo)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeNunca, Nunca, OpeVecesPorMes, VecesPorMes, OpeVecesPorSemana, VecesPorSemana, OpeVecesPorDia, VecesPorDia, OpePorcionPequeña, PorcionPequeña, OpePorcionMediana, PorcionMediana, OpePorcionGrande, PorcionGrande, OpeTamañoPorcion, TamañoPorcion, OpeCantidad, Cantidad, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeOrdenDeVisualizacion, OrdenDeVisualizacion, OpeEstado, Estado, OpeTipo, Tipo);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(vEncuestaAlimentoEntityFilter EntityFilter)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(EntityFilter);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado, string OpeTipo, string Tipo)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeNunca, Nunca, OpeVecesPorMes, VecesPorMes, OpeVecesPorSemana, VecesPorSemana, OpeVecesPorDia, VecesPorDia, OpePorcionPequeña, PorcionPequeña, OpePorcionMediana, PorcionMediana, OpePorcionGrande, PorcionGrande, OpeTamañoPorcion, TamañoPorcion, OpeCantidad, Cantidad, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeOrdenDeVisualizacion, OrdenDeVisualizacion, OpeEstado, Estado, OpeTipo, Tipo);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(vEncuestaAlimentoEntityPaged EntityPaged, vEncuestaAlimentoEntityFilter EntityFilter)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(EntityPaged, EntityFilter);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable GetAll(string OrdenDeRegistros)
        {
            try
            {
                return this.CreateDataAccess().GetAll(OrdenDeRegistros);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public void GetAll(string OrdenDeRegistros, out vEncuestaAlimentoEntityInfo.vEncuestaAlimentoEntityInfoList listaAGenerar)
        {
            try
            {
                listaAGenerar = this.DataTableToListOfEntityInfo(this.CreateDataAccess().GetAll(OrdenDeRegistros));
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public vEncuestaAlimentoEntityInfo.vEncuestaAlimentoEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
        {
            try
            {
                return this.DataTableToListOfEntityInfo(this.CreateDataAccess().GetAll(OrdenDeRegistros));
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }
    }
}

