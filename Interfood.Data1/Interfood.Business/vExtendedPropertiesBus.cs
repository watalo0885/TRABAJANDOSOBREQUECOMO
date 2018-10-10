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
    public class vExtendedPropertiesBus
    {
        private string _nameConnection;

        public vExtendedPropertiesBus()
        {
            this._nameConnection = string.Empty;
        }

        public vExtendedPropertiesBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private vExtendedPropertiesData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new vExtendedPropertiesData();
                return new vExtendedPropertiesData(this._nameConnection);
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

        public vExtendedPropertiesEntityInfo.vExtendedPropertiesEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            vExtendedPropertiesEntityInfo[] pArray = new vExtendedPropertiesEntityInfo[dt.Rows.Count];
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
            return new vExtendedPropertiesEntityInfo.vExtendedPropertiesEntityInfoList(pArray);
        }

        public vExtendedPropertiesEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            vExtendedPropertiesEntityInfo propertiesEntityInfo = new vExtendedPropertiesEntityInfo();
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
                propertiesEntityInfo.FechaAlta = (DateTime)dr["FechaAlta"];
                propertiesEntityInfo.UserName = Convert.IsDBNull(dr["UserName"]) ? (string)null : (string)dr["UserName"];
                propertiesEntityInfo.Password = Convert.IsDBNull(dr["Password"]) ? (string)null : (string)dr["Password"];
                propertiesEntityInfo.Email = Convert.IsDBNull(dr["Email"]) ? (string)null : (string)dr["Email"];
                propertiesEntityInfo.IsApproved = Convert.IsDBNull(dr["IsApproved"]) ? new bool?() : (bool?)dr["IsApproved"];
                propertiesEntityInfo.IsLockedOut = Convert.IsDBNull(dr["IsLockedOut"]) ? new bool?() : (bool?)dr["IsLockedOut"];
                propertiesEntityInfo.LastLoginDate = Convert.IsDBNull(dr["LastLoginDate"]) ? new DateTime?() : (DateTime?)dr["LastLoginDate"];
                propertiesEntityInfo.RoleName = Convert.IsDBNull(dr["RoleName"]) ? (string)null : (string)dr["RoleName"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return propertiesEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta, string OpeUserName, string UserName, string OpePassword, string Password, string OpeEmail, string Email, string OpeIsApproved, bool? IsApproved, string OpeIsLockedOut, bool? IsLockedOut, string OpeLastLoginDate, string LastLoginDateDesde, string LastLoginDateHasta, string OpeRoleName, string RoleName)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeLimiteDeEncuestas, LimiteDeEncuestas, OpeTelefonoFijo1, TelefonoFijo1, OpeTelefonoFijo2, TelefonoFijo2, OpeFax, Fax, OpeCelular, Celular, OpeFechaAlta, FechaAltaDesde, FechaAltaHasta, OpeUserName, UserName, OpePassword, Password, OpeEmail, Email, OpeIsApproved, IsApproved, OpeIsLockedOut, IsLockedOut, OpeLastLoginDate, LastLoginDateDesde, LastLoginDateHasta, OpeRoleName, RoleName);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(vExtendedPropertiesEntityFilter EntityFilter)
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
        public void Search(vExtendedPropertiesEntityFilter EntityFilter, out vExtendedPropertiesEntityInfo.vExtendedPropertiesEntityInfoList listaAGenerar)
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
        public vExtendedPropertiesEntityInfo.vExtendedPropertiesEntityInfoList Search(vExtendedPropertiesEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta, string OpeUserName, string UserName, string OpePassword, string Password, string OpeEmail, string Email, string OpeIsApproved, bool? IsApproved, string OpeIsLockedOut, bool? IsLockedOut, string OpeLastLoginDate, string LastLoginDateDesde, string LastLoginDateHasta, string OpeRoleName, string RoleName)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeLimiteDeEncuestas, LimiteDeEncuestas, OpeTelefonoFijo1, TelefonoFijo1, OpeTelefonoFijo2, TelefonoFijo2, OpeFax, Fax, OpeCelular, Celular, OpeFechaAlta, FechaAltaDesde, FechaAltaHasta, OpeUserName, UserName, OpePassword, Password, OpeEmail, Email, OpeIsApproved, IsApproved, OpeIsLockedOut, IsLockedOut, OpeLastLoginDate, LastLoginDateDesde, LastLoginDateHasta, OpeRoleName, RoleName);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(vExtendedPropertiesEntityPaged EntityPaged, vExtendedPropertiesEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta, string OpeUserName, string UserName, string OpePassword, string Password, string OpeEmail, string Email, string OpeIsApproved, bool? IsApproved, string OpeIsLockedOut, bool? IsLockedOut, string OpeLastLoginDate, string LastLoginDateDesde, string LastLoginDateHasta, string OpeRoleName, string RoleName)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeLimiteDeEncuestas, LimiteDeEncuestas, OpeTelefonoFijo1, TelefonoFijo1, OpeTelefonoFijo2, TelefonoFijo2, OpeFax, Fax, OpeCelular, Celular, OpeFechaAlta, FechaAltaDesde, FechaAltaHasta, OpeUserName, UserName, OpePassword, Password, OpeEmail, Email, OpeIsApproved, IsApproved, OpeIsLockedOut, IsLockedOut, OpeLastLoginDate, LastLoginDateDesde, LastLoginDateHasta, OpeRoleName, RoleName);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(vExtendedPropertiesEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta, string OpeUserName, string UserName, string OpePassword, string Password, string OpeEmail, string Email, string OpeIsApproved, bool? IsApproved, string OpeIsLockedOut, bool? IsLockedOut, string OpeLastLoginDate, string LastLoginDateDesde, string LastLoginDateHasta, string OpeRoleName, string RoleName)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeLimiteDeEncuestas, LimiteDeEncuestas, OpeTelefonoFijo1, TelefonoFijo1, OpeTelefonoFijo2, TelefonoFijo2, OpeFax, Fax, OpeCelular, Celular, OpeFechaAlta, FechaAltaDesde, FechaAltaHasta, OpeUserName, UserName, OpePassword, Password, OpeEmail, Email, OpeIsApproved, IsApproved, OpeIsLockedOut, IsLockedOut, OpeLastLoginDate, LastLoginDateDesde, LastLoginDateHasta, OpeRoleName, RoleName);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(vExtendedPropertiesEntityPaged EntityPaged, vExtendedPropertiesEntityFilter EntityFilter)
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
        public void GetAll(string OrdenDeRegistros, out vExtendedPropertiesEntityInfo.vExtendedPropertiesEntityInfoList listaAGenerar)
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
        public vExtendedPropertiesEntityInfo.vExtendedPropertiesEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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

