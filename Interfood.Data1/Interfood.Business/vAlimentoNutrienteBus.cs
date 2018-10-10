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
    public class vAlimentoNutrienteBus
    {
        private string _nameConnection;

        public vAlimentoNutrienteBus()
        {
            this._nameConnection = string.Empty;
        }

        public vAlimentoNutrienteBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private vAlimentoNutrienteData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new vAlimentoNutrienteData();
                return new vAlimentoNutrienteData(this._nameConnection);
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

        public vAlimentoNutrienteEntityInfo.vAlimentoNutrienteEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            vAlimentoNutrienteEntityInfo[] pArray = new vAlimentoNutrienteEntityInfo[dt.Rows.Count];
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
            return new vAlimentoNutrienteEntityInfo.vAlimentoNutrienteEntityInfoList(pArray);
        }

        public vAlimentoNutrienteEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            vAlimentoNutrienteEntityInfo nutrienteEntityInfo = new vAlimentoNutrienteEntityInfo();
            try
            {
                nutrienteEntityInfo.AlimentoId = (int)dr["AlimentoId"];
                nutrienteEntityInfo.AlimentoCodigo = Convert.IsDBNull(dr["AlimentoCodigo"]) ? (string)null : (string)dr["AlimentoCodigo"];
                nutrienteEntityInfo.AlimentoNombre = Convert.IsDBNull(dr["AlimentoNombre"]) ? (string)null : (string)dr["AlimentoNombre"];
                nutrienteEntityInfo.NutrienteId = (int)dr["NutrienteId"];
                nutrienteEntityInfo.NutrienteNombre = Convert.IsDBNull(dr["NutrienteNombre"]) ? (string)null : (string)dr["NutrienteNombre"];
                nutrienteEntityInfo.AlimentoNutrienteCantidad = Convert.IsDBNull(dr["AlimentoNutrienteCantidad"]) ? new Decimal?() : (Decimal?)dr["AlimentoNutrienteCantidad"];
                nutrienteEntityInfo.NutrienteUDMId = Convert.IsDBNull(dr["NutrienteUDMId"]) ? (string)null : (string)dr["NutrienteUDMId"];
                nutrienteEntityInfo.PerteneceA = Convert.IsDBNull(dr["PerteneceA"]) ? new int?() : (int?)dr["PerteneceA"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return nutrienteEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeAlimentoNombre, string AlimentoNombre, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, Decimal? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId, string OpePerteneceA, int? PerteneceA)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeAlimentoCodigo, AlimentoCodigo, OpeAlimentoNombre, AlimentoNombre, OpeNutrienteId, NutrienteId, OpeNutrienteNombre, NutrienteNombre, OpeAlimentoNutrienteCantidad, AlimentoNutrienteCantidad, OpeNutrienteUDMId, NutrienteUDMId, OpePerteneceA, PerteneceA);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(vAlimentoNutrienteEntityFilter EntityFilter)
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
        public void Search(vAlimentoNutrienteEntityFilter EntityFilter, out vAlimentoNutrienteEntityInfo.vAlimentoNutrienteEntityInfoList listaAGenerar)
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
        public vAlimentoNutrienteEntityInfo.vAlimentoNutrienteEntityInfoList Search(vAlimentoNutrienteEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeAlimentoNombre, string AlimentoNombre, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, Decimal? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId, string OpePerteneceA, int? PerteneceA)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeAlimentoCodigo, AlimentoCodigo, OpeAlimentoNombre, AlimentoNombre, OpeNutrienteId, NutrienteId, OpeNutrienteNombre, NutrienteNombre, OpeAlimentoNutrienteCantidad, AlimentoNutrienteCantidad, OpeNutrienteUDMId, NutrienteUDMId, OpePerteneceA, PerteneceA);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(vAlimentoNutrienteEntityPaged EntityPaged, vAlimentoNutrienteEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeAlimentoNombre, string AlimentoNombre, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, Decimal? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId, string OpePerteneceA, int? PerteneceA)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeAlimentoCodigo, AlimentoCodigo, OpeAlimentoNombre, AlimentoNombre, OpeNutrienteId, NutrienteId, OpeNutrienteNombre, NutrienteNombre, OpeAlimentoNutrienteCantidad, AlimentoNutrienteCantidad, OpeNutrienteUDMId, NutrienteUDMId, OpePerteneceA, PerteneceA);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(vAlimentoNutrienteEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeAlimentoNombre, string AlimentoNombre, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, Decimal? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId, string OpePerteneceA, int? PerteneceA)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeAlimentoCodigo, AlimentoCodigo, OpeAlimentoNombre, AlimentoNombre, OpeNutrienteId, NutrienteId, OpeNutrienteNombre, NutrienteNombre, OpeAlimentoNutrienteCantidad, AlimentoNutrienteCantidad, OpeNutrienteUDMId, NutrienteUDMId, OpePerteneceA, PerteneceA);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(vAlimentoNutrienteEntityPaged EntityPaged, vAlimentoNutrienteEntityFilter EntityFilter)
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
        public void GetAll(string OrdenDeRegistros, out vAlimentoNutrienteEntityInfo.vAlimentoNutrienteEntityInfoList listaAGenerar)
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
        public vAlimentoNutrienteEntityInfo.vAlimentoNutrienteEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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

