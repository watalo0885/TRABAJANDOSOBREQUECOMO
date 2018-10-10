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
    public class aspnet_ExtendedPropertiesBus
    {
        private string _nameConnection;

        public aspnet_ExtendedPropertiesBus()
        {
            this._nameConnection = string.Empty;
        }

        public aspnet_ExtendedPropertiesBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private aspnet_ExtendedPropertiesData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new aspnet_ExtendedPropertiesData();
                return new aspnet_ExtendedPropertiesData(this._nameConnection);
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

        public aspnet_ExtendedPropertiesEntityInfo.aspnet_ExtendedPropertiesEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            aspnet_ExtendedPropertiesEntityInfo[] pArray = new aspnet_ExtendedPropertiesEntityInfo[dt.Rows.Count];
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
            return new aspnet_ExtendedPropertiesEntityInfo.aspnet_ExtendedPropertiesEntityInfoList(pArray);
        }

        public aspnet_ExtendedPropertiesEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            aspnet_ExtendedPropertiesEntityInfo propertiesEntityInfo = new aspnet_ExtendedPropertiesEntityInfo();
            try
            {
                propertiesEntityInfo.UserId = (Guid)dr["UserId"];
                propertiesEntityInfo.Apellido = (string)dr["Apellido"];
                propertiesEntityInfo.Nombres = (string)dr["Nombres"];
                propertiesEntityInfo.Empresa = Convert.IsDBNull(dr["Empresa"]) ? (string)null : (string)dr["Empresa"];
                propertiesEntityInfo.LimiteDeEncuestas = (int)dr["LimiteDeEncuestas"];
                propertiesEntityInfo.TelefonoFijo1 = Convert.IsDBNull(dr["TelefonoFijo1"]) ? (string)null : (string)dr["TelefonoFijo1"];
                propertiesEntityInfo.TelefonoFijo2 = Convert.IsDBNull(dr["TelefonoFijo2"]) ? (string)null : (string)dr["TelefonoFijo2"];
                propertiesEntityInfo.Fax = Convert.IsDBNull(dr["Fax"]) ? (string)null : (string)dr["Fax"];
                propertiesEntityInfo.Celular = Convert.IsDBNull(dr["Celular"]) ? (string)null : (string)dr["Celular"];
                propertiesEntityInfo.Email = Convert.IsDBNull(dr["Email"]) ? (string)null : (string)dr["Email"];
                propertiesEntityInfo.FechaAlta = (DateTime)dr["FechaAlta"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return propertiesEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(Guid UserId, string Apellido, string Nombres, string Empresa, int LimiteDeEncuestas, string TelefonoFijo1, string TelefonoFijo2, string Fax, string Celular, string Email, DateTime FechaAlta)
        {
            try
            {
                this.CreateDataAccess().Insert(UserId, Apellido, Nombres, Empresa, LimiteDeEncuestas, TelefonoFijo1, TelefonoFijo2, Fax, Celular, Email, FechaAlta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(aspnet_ExtendedPropertiesEntityInsert EntityInsert)
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
        public void InsertFromInfo(aspnet_ExtendedPropertiesEntityInfo EntityInfo)
        {
            try
            {
                aspnet_ExtendedPropertiesEntityInsert EntityInsert = new aspnet_ExtendedPropertiesEntityInsert();
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
        public bool Delete(Guid UserId)
        {
            try
            {
                return this.CreateDataAccess().Delete(UserId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(aspnet_ExtendedPropertiesEntityKey EntityKey)
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
        public bool Update(Guid UserId, string Apellido, string Nombres, string Empresa, int LimiteDeEncuestas, string TelefonoFijo1, string TelefonoFijo2, string Fax, string Celular, string Email, DateTime FechaAlta)
        {
            try
            {
                return this.CreateDataAccess().Update(new Guid?(UserId), Apellido, Nombres, Empresa, new int?(LimiteDeEncuestas), TelefonoFijo1, TelefonoFijo2, Fax, Celular, Email, new DateTime?(FechaAlta));
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(aspnet_ExtendedPropertiesEntityKey EntityKey, aspnet_ExtendedPropertiesEntityUpdate EntityUpdate)
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
        public bool UpdateWhereExtendido(string WhereEx, aspnet_ExtendedPropertiesEntityUpdate EntityUpdate)
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
        public bool UpdateFromInfo(aspnet_ExtendedPropertiesEntityKey EntityKey, aspnet_ExtendedPropertiesEntityInfo EntityInfo)
        {
            try
            {
                aspnet_ExtendedPropertiesEntityUpdate EntityUpdate = new aspnet_ExtendedPropertiesEntityUpdate();
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
        public bool UpdateNull(Guid UserId, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(UserId, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(aspnet_ExtendedPropertiesEntityKey EntityKey, aspnet_ExtendedPropertiesEntityUpdateNullFields EntityUpdateNullFields)
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
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeEmail, string Email, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeLimiteDeEncuestas, LimiteDeEncuestas, OpeTelefonoFijo1, TelefonoFijo1, OpeTelefonoFijo2, TelefonoFijo2, OpeFax, Fax, OpeCelular, Celular, OpeEmail, Email, OpeFechaAlta, FechaAltaDesde, FechaAltaHasta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(aspnet_ExtendedPropertiesEntityFilter EntityFilter)
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
        public void Search(aspnet_ExtendedPropertiesEntityFilter EntityFilter, out aspnet_ExtendedPropertiesEntityInfo.aspnet_ExtendedPropertiesEntityInfoList listaAGenerar)
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
        public aspnet_ExtendedPropertiesEntityInfo.aspnet_ExtendedPropertiesEntityInfoList Search(aspnet_ExtendedPropertiesEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeEmail, string Email, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeLimiteDeEncuestas, LimiteDeEncuestas, OpeTelefonoFijo1, TelefonoFijo1, OpeTelefonoFijo2, TelefonoFijo2, OpeFax, Fax, OpeCelular, Celular, OpeEmail, Email, OpeFechaAlta, FechaAltaDesde, FechaAltaHasta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(aspnet_ExtendedPropertiesEntityPaged EntityPaged, aspnet_ExtendedPropertiesEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeEmail, string Email, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeLimiteDeEncuestas, LimiteDeEncuestas, OpeTelefonoFijo1, TelefonoFijo1, OpeTelefonoFijo2, TelefonoFijo2, OpeFax, Fax, OpeCelular, Celular, OpeEmail, Email, OpeFechaAlta, FechaAltaDesde, FechaAltaHasta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(aspnet_ExtendedPropertiesEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeEmail, string Email, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeLimiteDeEncuestas, LimiteDeEncuestas, OpeTelefonoFijo1, TelefonoFijo1, OpeTelefonoFijo2, TelefonoFijo2, OpeFax, Fax, OpeCelular, Celular, OpeEmail, Email, OpeFechaAlta, FechaAltaDesde, FechaAltaHasta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(aspnet_ExtendedPropertiesEntityPaged EntityPaged, aspnet_ExtendedPropertiesEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeUserId, Guid UserId)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeUserId, UserId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(aspnet_ExtendedPropertiesEntityKey EntityKey)
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
        public aspnet_ExtendedPropertiesEntityInfo SearchOne(aspnet_ExtendedPropertiesEntityKey EntityKey, bool NoUtilizar)
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
        public void GetAll(string OrdenDeRegistros, out aspnet_ExtendedPropertiesEntityInfo.aspnet_ExtendedPropertiesEntityInfoList listaAGenerar)
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
        public aspnet_ExtendedPropertiesEntityInfo.aspnet_ExtendedPropertiesEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
