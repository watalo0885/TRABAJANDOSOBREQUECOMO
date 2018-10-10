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
    public class TipoDeAlimentosBus
    {
        private string _nameConnection;

        public TipoDeAlimentosBus()
        {
            this._nameConnection = string.Empty;
        }

        public TipoDeAlimentosBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private TipoDeAlimentosData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new TipoDeAlimentosData();
                return new TipoDeAlimentosData(this._nameConnection);
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

        public TipoDeAlimentosEntityInfo.TipoDeAlimentosEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            TipoDeAlimentosEntityInfo[] pArray = new TipoDeAlimentosEntityInfo[dt.Rows.Count];
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
            return new TipoDeAlimentosEntityInfo.TipoDeAlimentosEntityInfoList(pArray);
        }

        public TipoDeAlimentosEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            TipoDeAlimentosEntityInfo alimentosEntityInfo = new TipoDeAlimentosEntityInfo();
            try
            {
                alimentosEntityInfo.TipoDeAlimentoId = (int)dr["TipoDeAlimentoId"];
                alimentosEntityInfo.TipoDeAlimento = (string)dr["TipoDeAlimento"];
                alimentosEntityInfo.OrdenDeVisualizacion = (int)dr["OrdenDeVisualizacion"];
                alimentosEntityInfo.Estado = Convert.IsDBNull(dr["Estado"]) ? (string)null : (string)dr["Estado"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return alimentosEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert_Return_Scalar(string TipoDeAlimento, int OrdenDeVisualizacion, string Estado)
        {
            try
            {
                return this.CreateDataAccess().Insert_Return_Scalar(TipoDeAlimento, OrdenDeVisualizacion, Estado);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert_Return_Scalar(TipoDeAlimentosEntityInsert EntityInsert)
        {
            try
            {
                if (!EntityInsert.Validate())
                    throw new Exception(EntityInsert.ErroresQueInvalidanLaEntidad);
                return this.CreateDataAccess().Insert_Return_Scalar(EntityInsert);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int InsertFromInfo(TipoDeAlimentosEntityInfo EntityInfo)
        {
            try
            {
                TipoDeAlimentosEntityInsert EntityInsert = new TipoDeAlimentosEntityInsert();
                EntityInsert.LoadFromInfo(EntityInfo);
                return this.Insert_Return_Scalar(EntityInsert);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(int TipoDeAlimentoId)
        {
            try
            {
                return this.CreateDataAccess().Delete(TipoDeAlimentoId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(TipoDeAlimentosEntityKey EntityKey)
        {
            try
            {
                if (!EntityKey.Validate())
                    throw new Exception(EntityKey.ErroresQueInvalidanLaEntidad);
                return this.CreateDataAccess().Delete(EntityKey);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool DeleteWhereExtendido(string WhereEx)
        {
            try
            {
                return this.CreateDataAccess().DeleteWhereExtendido(WhereEx);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int TipoDeAlimentoId, string TipoDeAlimento, int OrdenDeVisualizacion, string Estado)
        {
            try
            {
                return this.CreateDataAccess().Update(new int?(TipoDeAlimentoId), TipoDeAlimento, new int?(OrdenDeVisualizacion), Estado);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(TipoDeAlimentosEntityKey EntityKey, TipoDeAlimentosEntityUpdate EntityUpdate)
        {
            try
            {
                if (!EntityKey.Validate())
                    return false;
                return this.CreateDataAccess().Update(EntityKey, EntityUpdate);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateWhereExtendido(string WhereEx, TipoDeAlimentosEntityUpdate EntityUpdate)
        {
            try
            {
                return this.CreateDataAccess().UpdateWhereExtendido(WhereEx, EntityUpdate);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateFromInfo(TipoDeAlimentosEntityKey EntityKey, TipoDeAlimentosEntityInfo EntityInfo)
        {
            try
            {
                TipoDeAlimentosEntityUpdate EntityUpdate = new TipoDeAlimentosEntityUpdate();
                EntityUpdate.LoadFromInfo(EntityInfo);
                return this.Update(EntityKey, EntityUpdate);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(int TipoDeAlimentoId, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(TipoDeAlimentoId, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(TipoDeAlimentosEntityKey EntityKey, TipoDeAlimentosEntityUpdateNullFields EntityUpdateNullFields)
        {
            try
            {
                if (!EntityKey.Validate())
                    return false;
                return this.CreateDataAccess().UpdateNull(EntityKey, EntityUpdateNullFields);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeTipoDeAlimento, TipoDeAlimento, OpeOrdenDeVisualizacion, OrdenDeVisualizacion, OpeEstado, Estado);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(TipoDeAlimentosEntityFilter EntityFilter)
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
        public void Search(TipoDeAlimentosEntityFilter EntityFilter, out TipoDeAlimentosEntityInfo.TipoDeAlimentosEntityInfoList listaAGenerar)
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
        public TipoDeAlimentosEntityInfo.TipoDeAlimentosEntityInfoList Search(TipoDeAlimentosEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeTipoDeAlimento, TipoDeAlimento, OpeOrdenDeVisualizacion, OrdenDeVisualizacion, OpeEstado, Estado);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(TipoDeAlimentosEntityPaged EntityPaged, TipoDeAlimentosEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeTipoDeAlimento, TipoDeAlimento, OpeOrdenDeVisualizacion, OrdenDeVisualizacion, OpeEstado, Estado);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(TipoDeAlimentosEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion, string OpeEstado, string Estado)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeTipoDeAlimento, TipoDeAlimento, OpeOrdenDeVisualizacion, OrdenDeVisualizacion, OpeEstado, Estado);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(TipoDeAlimentosEntityPaged EntityPaged, TipoDeAlimentosEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeTipoDeAlimentoId, int TipoDeAlimentoId)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeTipoDeAlimentoId, TipoDeAlimentoId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(TipoDeAlimentosEntityKey EntityKey)
        {
            try
            {
                if (!EntityKey.Validate())
                    throw new Exception(EntityKey.ErroresQueInvalidanLaEntidad);
                return this.CreateDataAccess().SearchOne(EntityKey);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public TipoDeAlimentosEntityInfo SearchOne(TipoDeAlimentosEntityKey EntityKey, bool NoUtilizar)
        {
            try
            {
                if (!EntityKey.Validate())
                    throw new Exception(EntityKey.ErroresQueInvalidanLaEntidad);
                return this.DataRowToEntityInfo(this.CreateDataAccess().SearchOne(EntityKey).Rows[0]);
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
        public void GetAll(string OrdenDeRegistros, out TipoDeAlimentosEntityInfo.TipoDeAlimentosEntityInfoList listaAGenerar)
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
        public TipoDeAlimentosEntityInfo.TipoDeAlimentosEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
