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
    public class TipoDeDietaBus
    {
        private string _nameConnection;

        public TipoDeDietaBus()
        {
            this._nameConnection = string.Empty;
        }

        public TipoDeDietaBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private TipoDeDietaData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new TipoDeDietaData();
                return new TipoDeDietaData(this._nameConnection);
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

        public TipoDeDietaEntityInfo.TipoDeDietaEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            TipoDeDietaEntityInfo[] pArray = new TipoDeDietaEntityInfo[dt.Rows.Count];
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
            return new TipoDeDietaEntityInfo.TipoDeDietaEntityInfoList(pArray);
        }

        public TipoDeDietaEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            TipoDeDietaEntityInfo deDietaEntityInfo = new TipoDeDietaEntityInfo();
            try
            {
                deDietaEntityInfo.TipoDeDietaId = (int)dr["TipoDeDietaId"];
                deDietaEntityInfo.TipoDeDieta = (string)dr["TipoDeDieta"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return deDietaEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert_Return_Scalar(string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().Insert_Return_Scalar(TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert_Return_Scalar(TipoDeDietaEntityInsert EntityInsert)
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
        public int InsertFromInfo(TipoDeDietaEntityInfo EntityInfo)
        {
            try
            {
                TipoDeDietaEntityInsert EntityInsert = new TipoDeDietaEntityInsert();
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
        public bool Delete(int TipoDeDietaId)
        {
            try
            {
                return this.CreateDataAccess().Delete(TipoDeDietaId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(TipoDeDietaEntityKey EntityKey)
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
        public bool Update(int TipoDeDietaId, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().Update(new int?(TipoDeDietaId), TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(TipoDeDietaEntityKey EntityKey, TipoDeDietaEntityUpdate EntityUpdate)
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
        public bool UpdateWhereExtendido(string WhereEx, TipoDeDietaEntityUpdate EntityUpdate)
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
        public bool UpdateFromInfo(TipoDeDietaEntityKey EntityKey, TipoDeDietaEntityInfo EntityInfo)
        {
            try
            {
                TipoDeDietaEntityUpdate EntityUpdate = new TipoDeDietaEntityUpdate();
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
        public bool UpdateNull(int TipoDeDietaId, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(TipoDeDietaId, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(TipoDeDietaEntityKey EntityKey, TipoDeDietaEntityUpdateNullFields EntityUpdateNullFields)
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
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeTipoDeDietaId, TipoDeDietaId, OpeTipoDeDieta, TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(TipoDeDietaEntityFilter EntityFilter)
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
        public void Search(TipoDeDietaEntityFilter EntityFilter, out TipoDeDietaEntityInfo.TipoDeDietaEntityInfoList listaAGenerar)
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
        public TipoDeDietaEntityInfo.TipoDeDietaEntityInfoList Search(TipoDeDietaEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeTipoDeDietaId, TipoDeDietaId, OpeTipoDeDieta, TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(TipoDeDietaEntityPaged EntityPaged, TipoDeDietaEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeTipoDeDietaId, TipoDeDietaId, OpeTipoDeDieta, TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(TipoDeDietaEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeTipoDeDietaId, TipoDeDietaId, OpeTipoDeDieta, TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(TipoDeDietaEntityPaged EntityPaged, TipoDeDietaEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeTipoDeDietaId, int TipoDeDietaId)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeTipoDeDietaId, TipoDeDietaId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(TipoDeDietaEntityKey EntityKey)
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
        public TipoDeDietaEntityInfo SearchOne(TipoDeDietaEntityKey EntityKey, bool NoUtilizar)
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
        public void GetAll(string OrdenDeRegistros, out TipoDeDietaEntityInfo.TipoDeDietaEntityInfoList listaAGenerar)
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
        public TipoDeDietaEntityInfo.TipoDeDietaEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
