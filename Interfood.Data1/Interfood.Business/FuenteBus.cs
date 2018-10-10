using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfood.Data;
using Interfood.Entities;
using System.Data;
using System.ComponentModel;

namespace Interfood.Business
{
    [DataObject]
    public class FuenteBus
    {
        private string _nameConnection;

        public FuenteBus() 
        {
            this._nameConnection = string.Empty;            
        }
        
        public FuenteBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private FuenteData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new FuenteData();
                return new FuenteData(this._nameConnection);
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

        public FuenteEntityInfo.FuenteEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            FuenteEntityInfo[] pArray = new FuenteEntityInfo[dt.Rows.Count];
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
            return new FuenteEntityInfo.FuenteEntityInfoList(pArray);
        }

        public FuenteEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            FuenteEntityInfo medidaEntityInfo = new FuenteEntityInfo();
            try
            {
                medidaEntityInfo.FntID = (string)dr["FntID"];
                medidaEntityInfo.Nombre = Convert.IsDBNull(dr["Nombre"]) ? (string)null : (string)dr["Nombre"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return medidaEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(string FntID, string Nombre)
        {
            try
            {
                this.CreateDataAccess().Insert(FntID, Nombre);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(FuenteEntityInsert EntityInsert)
        {
            try
            {
                if (!EntityInsert.Validate())
                    throw new Exception(EntityInsert.ErroresQueInvalidanLaEntidad);
                this.CreateDataAccess().Insert(EntityInsert);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void InsertFromInfo(FuenteEntityInfo EntityInfo)
        {
            try
            {
                FuenteEntityInsert EntityInsert = new FuenteEntityInsert();
                EntityInsert.LoadFromInfo(EntityInfo);
                this.Insert(EntityInsert);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(string FntID)
        {
            try
            {
                return this.CreateDataAccess().Delete(FntID);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(FuenteEntityKey EntityKey)
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
        public bool Update(string FntID, string Nombre)
        {
            try
            {
                return this.CreateDataAccess().Update(FntID, Nombre);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(FuenteEntityKey EntityKey, FuenteEntityUpdate EntityUpdate)
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
        public bool UpdateWhereExtendido(string WhereEx, FuenteEntityUpdate EntityUpdate)
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
        public bool UpdateFromInfo(FuenteEntityKey EntityKey, FuenteEntityInfo EntityInfo)
        {
            try
            {
                FuenteEntityUpdate EntityUpdate = new FuenteEntityUpdate();
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
        public bool UpdateNull(string FtnID, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(FtnID, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(FuenteEntityKey EntityKey, FuenteEntityUpdateNullFields EntityUpdateNullFields)
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
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeFntID, string FntID, string OpeNombre, string Nombre)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeFntID, FntID, OpeNombre, Nombre);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(FuenteEntityFilter EntityFilter)
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
        public void Search(FuenteEntityFilter EntityFilter, out FuenteEntityInfo.FuenteEntityInfoList listaAGenerar)
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
        public FuenteEntityInfo.FuenteEntityInfoList Search(FuenteEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeFntID, string FntID, string OpeNombre, string Nombre)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeFntID, FntID, OpeNombre, Nombre);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(FuenteEntityPaged EntityPaged, FuenteEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeFntID, string FntID, string OpeNombre, string Nombre)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeFntID, FntID, OpeNombre, Nombre);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(FuenteEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeFntID, string FntID, string OpeNombre, string Nombre)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeFntID, FntID, OpeNombre, Nombre);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(FuenteEntityPaged EntityPaged, FuenteEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeFntID, string FntID)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeFntID, FntID);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(FuenteEntityKey EntityKey)
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
        public FuenteEntityInfo SearchOne(FuenteEntityKey EntityKey, bool NoUtilizar)
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
        public void GetAll(string OrdenDeRegistros, out FuenteEntityInfo.FuenteEntityInfoList listaAGenerar)
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
        public FuenteEntityInfo.FuenteEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
