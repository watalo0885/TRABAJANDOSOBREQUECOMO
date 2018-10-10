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
    public class aspnet_RolesBus
    {
        private string _nameConnection;

        public aspnet_RolesBus()
        {
            this._nameConnection = string.Empty;
        }

        public aspnet_RolesBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private aspnet_RolesData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new aspnet_RolesData();
                return new aspnet_RolesData(this._nameConnection);
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

        public aspnet_RolesEntityInfo.aspnet_RolesEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            aspnet_RolesEntityInfo[] pArray = new aspnet_RolesEntityInfo[dt.Rows.Count];
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
            return new aspnet_RolesEntityInfo.aspnet_RolesEntityInfoList(pArray);
        }

        public aspnet_RolesEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            aspnet_RolesEntityInfo aspnetRolesEntityInfo = new aspnet_RolesEntityInfo();
            try
            {
                aspnetRolesEntityInfo.ApplicationId = (Guid)dr["ApplicationId"];
                aspnetRolesEntityInfo.RoleId = (Guid)dr["RoleId"];
                aspnetRolesEntityInfo.RoleName = (string)dr["RoleName"];
                aspnetRolesEntityInfo.LoweredRoleName = (string)dr["LoweredRoleName"];
                aspnetRolesEntityInfo.Description = Convert.IsDBNull(dr["Description"]) ? (string)null : (string)dr["Description"];
                aspnetRolesEntityInfo.LongDescription = Convert.IsDBNull(dr["LongDescription"]) ? (string)null : (string)dr["LongDescription"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return aspnetRolesEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Guid ApplicationId, Guid RoleId, string RoleName, string LoweredRoleName, string Description, string LongDescription)
        {
            try
            {
                this.CreateDataAccess().Insert(ApplicationId, RoleId, RoleName, LoweredRoleName, Description, LongDescription);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(aspnet_RolesEntityInsert EntityInsert)
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
        public void InsertFromInfo(aspnet_RolesEntityInfo EntityInfo)
        {
            try
            {
                aspnet_RolesEntityInsert EntityInsert = new aspnet_RolesEntityInsert();
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
        public bool Delete(Guid RoleId)
        {
            try
            {
                return this.CreateDataAccess().Delete(RoleId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(aspnet_RolesEntityKey EntityKey)
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
        public bool Update(Guid ApplicationId, Guid RoleId, string RoleName, string LoweredRoleName, string Description, string LongDescription)
        {
            try
            {
                return this.CreateDataAccess().Update(new Guid?(ApplicationId), new Guid?(RoleId), RoleName, LoweredRoleName, Description, LongDescription);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(aspnet_RolesEntityKey EntityKey, aspnet_RolesEntityUpdate EntityUpdate)
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
        public bool UpdateWhereExtendido(string WhereEx, aspnet_RolesEntityUpdate EntityUpdate)
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
        public bool UpdateFromInfo(aspnet_RolesEntityKey EntityKey, aspnet_RolesEntityInfo EntityInfo)
        {
            try
            {
                aspnet_RolesEntityUpdate EntityUpdate = new aspnet_RolesEntityUpdate();
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
        public bool UpdateNull(Guid RoleId, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(RoleId, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(aspnet_RolesEntityKey EntityKey, aspnet_RolesEntityUpdateNullFields EntityUpdateNullFields)
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
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeApplicationId, Guid? ApplicationId, string OpeRoleId, Guid? RoleId, string OpeRoleName, string RoleName, string OpeLoweredRoleName, string LoweredRoleName, string OpeDescription, string Description, string OpeLongDescription, string LongDescription)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeApplicationId, ApplicationId, OpeRoleId, RoleId, OpeRoleName, RoleName, OpeLoweredRoleName, LoweredRoleName, OpeDescription, Description, OpeLongDescription, LongDescription);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(aspnet_RolesEntityFilter EntityFilter)
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
        public void Search(aspnet_RolesEntityFilter EntityFilter, out aspnet_RolesEntityInfo.aspnet_RolesEntityInfoList listaAGenerar)
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
        public aspnet_RolesEntityInfo.aspnet_RolesEntityInfoList Search(aspnet_RolesEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeApplicationId, Guid? ApplicationId, string OpeRoleId, Guid? RoleId, string OpeRoleName, string RoleName, string OpeLoweredRoleName, string LoweredRoleName, string OpeDescription, string Description, string OpeLongDescription, string LongDescription)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeApplicationId, ApplicationId, OpeRoleId, RoleId, OpeRoleName, RoleName, OpeLoweredRoleName, LoweredRoleName, OpeDescription, Description, OpeLongDescription, LongDescription);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(aspnet_RolesEntityPaged EntityPaged, aspnet_RolesEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeApplicationId, Guid? ApplicationId, string OpeRoleId, Guid? RoleId, string OpeRoleName, string RoleName, string OpeLoweredRoleName, string LoweredRoleName, string OpeDescription, string Description, string OpeLongDescription, string LongDescription)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeApplicationId, ApplicationId, OpeRoleId, RoleId, OpeRoleName, RoleName, OpeLoweredRoleName, LoweredRoleName, OpeDescription, Description, OpeLongDescription, LongDescription);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(aspnet_RolesEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeApplicationId, Guid? ApplicationId, string OpeRoleId, Guid? RoleId, string OpeRoleName, string RoleName, string OpeLoweredRoleName, string LoweredRoleName, string OpeDescription, string Description, string OpeLongDescription, string LongDescription)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeApplicationId, ApplicationId, OpeRoleId, RoleId, OpeRoleName, RoleName, OpeLoweredRoleName, LoweredRoleName, OpeDescription, Description, OpeLongDescription, LongDescription);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(aspnet_RolesEntityPaged EntityPaged, aspnet_RolesEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeRoleId, Guid RoleId)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeRoleId, RoleId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(aspnet_RolesEntityKey EntityKey)
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
        public aspnet_RolesEntityInfo SearchOne(aspnet_RolesEntityKey EntityKey, bool NoUtilizar)
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
        public void GetAll(string OrdenDeRegistros, out aspnet_RolesEntityInfo.aspnet_RolesEntityInfoList listaAGenerar)
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
        public aspnet_RolesEntityInfo.aspnet_RolesEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
