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
    public class vAlimentosBus
    {
        private string _nameConnection;

        public vAlimentosBus()
        {
            this._nameConnection = string.Empty;
        }

        public vAlimentosBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private vAlimentosData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new vAlimentosData();
                return new vAlimentosData(this._nameConnection);
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

        public vAlimentosEntityInfo.vAlimentosEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            vAlimentosEntityInfo[] pArray = new vAlimentosEntityInfo[dt.Rows.Count];
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
            return new vAlimentosEntityInfo.vAlimentosEntityInfoList(pArray);
        }

        public vAlimentosEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            vAlimentosEntityInfo alimentosEntityInfo = new vAlimentosEntityInfo();
            try
            {
                alimentosEntityInfo.AlimentoId = (int)dr["AlimentoId"];
                alimentosEntityInfo.Codigo = (string)dr["Codigo"];
                alimentosEntityInfo.Nombre = (string)dr["Nombre"];
                alimentosEntityInfo.TipoDeAlimentoId = Convert.IsDBNull(dr["TipoDeAlimentoId"]) ? new int?() : (int?)dr["TipoDeAlimentoId"];
                alimentosEntityInfo.TipoDeAlimento = (string)dr["TipoDeAlimento"];
                alimentosEntityInfo.Estacional = (string)dr["Estacional"];
                alimentosEntityInfo.Pequeña = (Decimal)dr["Pequeña"];
                alimentosEntityInfo.Mediana = (Decimal)dr["Mediana"];
                alimentosEntityInfo.Grande = (Decimal)dr["Grande"];
                alimentosEntityInfo.Estado = (string)dr["Estado"];
                alimentosEntityInfo.OrdenDeVisualizacion = Convert.IsDBNull(dr["OrdenDeVisualizacion"]) ? new int?() : (int?)dr["OrdenDeVisualizacion"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return alimentosEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeTipoDeAlimento, TipoDeAlimento, OpeEstacional, Estacional, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeEstado, Estado, OpeOrdenDeVisualizacion, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(vAlimentosEntityFilter EntityFilter)
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
        public void Search(vAlimentosEntityFilter EntityFilter, out vAlimentosEntityInfo.vAlimentosEntityInfoList listaAGenerar)
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
        public vAlimentosEntityInfo.vAlimentosEntityInfoList Search(vAlimentosEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeTipoDeAlimento, TipoDeAlimento, OpeEstacional, Estacional, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeEstado, Estado, OpeOrdenDeVisualizacion, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(vAlimentosEntityPaged EntityPaged, vAlimentosEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeTipoDeAlimento, TipoDeAlimento, OpeEstacional, Estacional, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeEstado, Estado, OpeOrdenDeVisualizacion, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(vAlimentosEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento,string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeTipoDeAlimento, TipoDeAlimento,OpeEstacional, Estacional, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeEstado, Estado, OpeOrdenDeVisualizacion, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(vAlimentosEntityPaged EntityPaged, vAlimentosEntityFilter EntityFilter)
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
        public void GetAll(string OrdenDeRegistros, out vAlimentosEntityInfo.vAlimentosEntityInfoList listaAGenerar)
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
        public vAlimentosEntityInfo.vAlimentosEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
