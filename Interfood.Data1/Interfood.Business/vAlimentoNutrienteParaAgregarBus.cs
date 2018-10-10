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
    public class vAlimentoNutrienteParaAgregarBus
    {
        private string _nameConnection;

        public vAlimentoNutrienteParaAgregarBus()
        {
            this._nameConnection = string.Empty;
        }

        public vAlimentoNutrienteParaAgregarBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private vAlimentoNutrienteParaAgregarData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new vAlimentoNutrienteParaAgregarData();
                return new vAlimentoNutrienteParaAgregarData(this._nameConnection);
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

        public vAlimentoNutrienteParaAgregarEntityInfo.vAlimentoNutrienteParaAgregarEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            vAlimentoNutrienteParaAgregarEntityInfo[] pArray = new vAlimentoNutrienteParaAgregarEntityInfo[dt.Rows.Count];
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
            return new vAlimentoNutrienteParaAgregarEntityInfo.vAlimentoNutrienteParaAgregarEntityInfoList(pArray);
        }

        public vAlimentoNutrienteParaAgregarEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            vAlimentoNutrienteParaAgregarEntityInfo agregarEntityInfo = new vAlimentoNutrienteParaAgregarEntityInfo();
            try
            {
                agregarEntityInfo.AlimentoId = (int)dr["AlimentoId"];
                agregarEntityInfo.NutrienteId = (int)dr["NutrienteId"];
                agregarEntityInfo.NutrienteNombre = Convert.IsDBNull(dr["NutrienteNombre"]) ? (string)null : (string)dr["NutrienteNombre"];
                agregarEntityInfo.AlimentoNutrienteCantidad = (int)dr["AlimentoNutrienteCantidad"];
                agregarEntityInfo.NutrienteUDMId = Convert.IsDBNull(dr["NutrienteUDMId"]) ? (string)null : (string)dr["NutrienteUDMId"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return agregarEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, int? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeNutrienteNombre, NutrienteNombre, OpeAlimentoNutrienteCantidad, AlimentoNutrienteCantidad, OpeNutrienteUDMId, NutrienteUDMId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(vAlimentoNutrienteParaAgregarEntityFilter EntityFilter)
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
        public void Search(vAlimentoNutrienteParaAgregarEntityFilter EntityFilter, out vAlimentoNutrienteParaAgregarEntityInfo.vAlimentoNutrienteParaAgregarEntityInfoList listaAGenerar)
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
        public vAlimentoNutrienteParaAgregarEntityInfo.vAlimentoNutrienteParaAgregarEntityInfoList Search(vAlimentoNutrienteParaAgregarEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, int? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeNutrienteNombre, NutrienteNombre, OpeAlimentoNutrienteCantidad, AlimentoNutrienteCantidad, OpeNutrienteUDMId, NutrienteUDMId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(vAlimentoNutrienteParaAgregarEntityPaged EntityPaged, vAlimentoNutrienteParaAgregarEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, int? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeNutrienteNombre, NutrienteNombre, OpeAlimentoNutrienteCantidad, AlimentoNutrienteCantidad, OpeNutrienteUDMId, NutrienteUDMId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(vAlimentoNutrienteParaAgregarEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, int? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeNutrienteNombre, NutrienteNombre, OpeAlimentoNutrienteCantidad, AlimentoNutrienteCantidad, OpeNutrienteUDMId, NutrienteUDMId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(vAlimentoNutrienteParaAgregarEntityPaged EntityPaged, vAlimentoNutrienteParaAgregarEntityFilter EntityFilter)
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
        public void GetAll(string OrdenDeRegistros, out vAlimentoNutrienteParaAgregarEntityInfo.vAlimentoNutrienteParaAgregarEntityInfoList listaAGenerar)
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
        public vAlimentoNutrienteParaAgregarEntityInfo.vAlimentoNutrienteParaAgregarEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
