using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using Interfood.Configuration;
using Interfood.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Interfood.Data
{
    public class vExtendedPropertiesData
    {
        private Database _database;

        private Database DataBase
        {
            get
            {
                return this._database;
            }
            set
            {
                this._database = value;
            }
        }

        public vExtendedPropertiesData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public vExtendedPropertiesData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta, string OpeUserName, string UserName, string OpePassword, string Password, string OpeEmail, string Email, string OpeIsApproved, bool? IsApproved, string OpeIsLockedOut, bool? IsLockedOut, string OpeLastLoginDate, string LastLoginDateDesde, string LastLoginDateHasta, string OpeRoleName, string RoleName)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)OpeApellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)OpeNombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmpresa", DbType.String, (object)OpeEmpresa);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLimiteDeEncuestas", DbType.String, (object)OpeLimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo1", DbType.String, (object)OpeTelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo2", DbType.String, (object)OpeTelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFax", DbType.String, (object)OpeFax);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCelular", DbType.String, (object)OpeCelular);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)OpeFechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)FechaAltaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)FechaAltaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserName", DbType.String, (object)OpeUserName);
                    this.DataBase.AddInParameter(storedProcCommand, "UserName", DbType.String, (object)UserName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePassword", DbType.String, (object)OpePassword);
                    this.DataBase.AddInParameter(storedProcCommand, "Password", DbType.String, (object)Password);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)OpeEmail);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.String, (object)Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsApproved", DbType.String, (object)OpeIsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "IsApproved", DbType.Boolean, (object)IsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsLockedOut", DbType.String, (object)OpeIsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "IsLockedOut", DbType.Boolean, (object)IsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLastLoginDate", DbType.String, (object)OpeLastLoginDate);
                    this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)LastLoginDateDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)LastLoginDateHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)OpeRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Search(vExtendedPropertiesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApellido));
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityFilter.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombres));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityFilter.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmpresa", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmpresa));
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)EntityFilter.Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLimiteDeEncuestas", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLimiteDeEncuestas));
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)EntityFilter.LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo1", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefonoFijo1));
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)EntityFilter.TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo2", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefonoFijo2));
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)EntityFilter.TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFax", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFax));
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)EntityFilter.Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCelular", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCelular));
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)EntityFilter.Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFechaAlta));
                    if (EntityFilter.FechaAltaDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaAltaDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.FechaAltaHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaAltaHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserName));
                    this.DataBase.AddInParameter(storedProcCommand, "UserName", DbType.String, (object)EntityFilter.UserName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePassword", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePassword));
                    this.DataBase.AddInParameter(storedProcCommand, "Password", DbType.String, (object)EntityFilter.Password);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmail));
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.String, (object)EntityFilter.Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsApproved", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIsApproved));
                    this.DataBase.AddInParameter(storedProcCommand, "IsApproved", DbType.Boolean, (object)EntityFilter.IsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsLockedOut", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIsLockedOut));
                    this.DataBase.AddInParameter(storedProcCommand, "IsLockedOut", DbType.Boolean, (object)EntityFilter.IsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLastLoginDate", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLastLoginDate));
                    if (EntityFilter.LastLoginDateDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.LastLoginDateDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.LastLoginDateHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.LastLoginDateHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityFilter.RoleName);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta, string OpeUserName, string UserName, string OpePassword, string Password, string OpeEmail, string Email, string OpeIsApproved, bool? IsApproved, string OpeIsLockedOut, bool? IsLockedOut, string OpeLastLoginDate, string LastLoginDateDesde, string LastLoginDateHasta, string OpeRoleName, string RoleName)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    if (PageSize < 1)
                        PageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                    if (PageReturn < 1)
                        PageReturn = int.Parse(ConfigurationManager.AppSettings["PageReturn"]);
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)PageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)PageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)OpeApellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)OpeNombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmpresa", DbType.String, (object)OpeEmpresa);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLimiteDeEncuestas", DbType.String, (object)OpeLimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo1", DbType.String, (object)OpeTelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo2", DbType.String, (object)OpeTelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFax", DbType.String, (object)OpeFax);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCelular", DbType.String, (object)OpeCelular);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)OpeFechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)FechaAltaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)FechaAltaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserName", DbType.String, (object)OpeUserName);
                    this.DataBase.AddInParameter(storedProcCommand, "UserName", DbType.String, (object)UserName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePassword", DbType.String, (object)OpePassword);
                    this.DataBase.AddInParameter(storedProcCommand, "Password", DbType.String, (object)Password);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)OpeEmail);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.String, (object)Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsApproved", DbType.String, (object)OpeIsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "IsApproved", DbType.Boolean, (object)IsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsLockedOut", DbType.String, (object)OpeIsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "IsLockedOut", DbType.Boolean, (object)IsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLastLoginDate", DbType.String, (object)OpeLastLoginDate);
                    this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)LastLoginDateDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)LastLoginDateHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)OpeRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchWithPagination(vExtendedPropertiesEntityPaged EntityPaged, vExtendedPropertiesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApellido));
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityFilter.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombres));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityFilter.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmpresa", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmpresa));
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)EntityFilter.Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLimiteDeEncuestas", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLimiteDeEncuestas));
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)EntityFilter.LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo1", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefonoFijo1));
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)EntityFilter.TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo2", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefonoFijo2));
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)EntityFilter.TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFax", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFax));
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)EntityFilter.Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCelular", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCelular));
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)EntityFilter.Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFechaAlta));
                    if (EntityFilter.FechaAltaDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaAltaDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.FechaAltaHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaAltaHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserName));
                    this.DataBase.AddInParameter(storedProcCommand, "UserName", DbType.String, (object)EntityFilter.UserName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePassword", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePassword));
                    this.DataBase.AddInParameter(storedProcCommand, "Password", DbType.String, (object)EntityFilter.Password);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmail));
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.String, (object)EntityFilter.Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsApproved", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIsApproved));
                    this.DataBase.AddInParameter(storedProcCommand, "IsApproved", DbType.Boolean, (object)EntityFilter.IsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsLockedOut", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIsLockedOut));
                    this.DataBase.AddInParameter(storedProcCommand, "IsLockedOut", DbType.Boolean, (object)EntityFilter.IsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLastLoginDate", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLastLoginDate));
                    if (EntityFilter.LastLoginDateDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.LastLoginDateDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.LastLoginDateHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.LastLoginDateHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityFilter.RoleName);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta, string OpeUserName, string UserName, string OpePassword, string Password, string OpeEmail, string Email, string OpeIsApproved, bool? IsApproved, string OpeIsLockedOut, bool? IsLockedOut, string OpeLastLoginDate, string LastLoginDateDesde, string LastLoginDateHasta, string OpeRoleName, string RoleName)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)OpeApellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)OpeNombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmpresa", DbType.String, (object)OpeEmpresa);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLimiteDeEncuestas", DbType.String, (object)OpeLimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo1", DbType.String, (object)OpeTelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo2", DbType.String, (object)OpeTelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFax", DbType.String, (object)OpeFax);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCelular", DbType.String, (object)OpeCelular);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)OpeFechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)FechaAltaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)FechaAltaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserName", DbType.String, (object)OpeUserName);
                    this.DataBase.AddInParameter(storedProcCommand, "UserName", DbType.String, (object)UserName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePassword", DbType.String, (object)OpePassword);
                    this.DataBase.AddInParameter(storedProcCommand, "Password", DbType.String, (object)Password);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)OpeEmail);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.String, (object)Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsApproved", DbType.String, (object)OpeIsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "IsApproved", DbType.Boolean, (object)IsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsLockedOut", DbType.String, (object)OpeIsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "IsLockedOut", DbType.Boolean, (object)IsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLastLoginDate", DbType.String, (object)OpeLastLoginDate);
                    this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)LastLoginDateDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)LastLoginDateHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)OpeRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchCount(vExtendedPropertiesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApellido));
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityFilter.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombres));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityFilter.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmpresa", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmpresa));
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)EntityFilter.Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLimiteDeEncuestas", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLimiteDeEncuestas));
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)EntityFilter.LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo1", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefonoFijo1));
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)EntityFilter.TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo2", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefonoFijo2));
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)EntityFilter.TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFax", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFax));
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)EntityFilter.Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCelular", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCelular));
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)EntityFilter.Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFechaAlta));
                    if (EntityFilter.FechaAltaDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaAltaDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.FechaAltaHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaAltaHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserName));
                    this.DataBase.AddInParameter(storedProcCommand, "UserName", DbType.String, (object)EntityFilter.UserName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePassword", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePassword));
                    this.DataBase.AddInParameter(storedProcCommand, "Password", DbType.String, (object)EntityFilter.Password);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmail));
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.String, (object)EntityFilter.Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsApproved", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIsApproved));
                    this.DataBase.AddInParameter(storedProcCommand, "IsApproved", DbType.Boolean, (object)EntityFilter.IsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsLockedOut", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIsLockedOut));
                    this.DataBase.AddInParameter(storedProcCommand, "IsLockedOut", DbType.Boolean, (object)EntityFilter.IsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLastLoginDate", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLastLoginDate));
                    if (EntityFilter.LastLoginDateDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.LastLoginDateDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.LastLoginDateHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.LastLoginDateHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityFilter.RoleName);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta, string OpeUserName, string UserName, string OpePassword, string Password, string OpeEmail, string Email, string OpeIsApproved, bool? IsApproved, string OpeIsLockedOut, bool? IsLockedOut, string OpeLastLoginDate, string LastLoginDateDesde, string LastLoginDateHasta, string OpeRoleName, string RoleName)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    if (PageSize < 1)
                        PageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                    if (PageReturn < 1)
                        PageReturn = int.Parse(ConfigurationManager.AppSettings["PageReturn"]);
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)PageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)PageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)OpeApellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)OpeNombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmpresa", DbType.String, (object)OpeEmpresa);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLimiteDeEncuestas", DbType.String, (object)OpeLimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo1", DbType.String, (object)OpeTelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo2", DbType.String, (object)OpeTelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFax", DbType.String, (object)OpeFax);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCelular", DbType.String, (object)OpeCelular);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)OpeFechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)FechaAltaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)FechaAltaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserName", DbType.String, (object)OpeUserName);
                    this.DataBase.AddInParameter(storedProcCommand, "UserName", DbType.String, (object)UserName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePassword", DbType.String, (object)OpePassword);
                    this.DataBase.AddInParameter(storedProcCommand, "Password", DbType.String, (object)Password);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)OpeEmail);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.String, (object)Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsApproved", DbType.String, (object)OpeIsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "IsApproved", DbType.Boolean, (object)IsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsLockedOut", DbType.String, (object)OpeIsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "IsLockedOut", DbType.Boolean, (object)IsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLastLoginDate", DbType.String, (object)OpeLastLoginDate);
                    this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)LastLoginDateDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)LastLoginDateHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)OpeRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SearchCountWithPagination(vExtendedPropertiesEntityPaged EntityPaged, vExtendedPropertiesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApellido));
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityFilter.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombres));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityFilter.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmpresa", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmpresa));
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)EntityFilter.Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLimiteDeEncuestas", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLimiteDeEncuestas));
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)EntityFilter.LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo1", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefonoFijo1));
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)EntityFilter.TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefonoFijo2", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefonoFijo2));
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)EntityFilter.TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFax", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFax));
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)EntityFilter.Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCelular", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCelular));
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)EntityFilter.Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFechaAlta));
                    if (EntityFilter.FechaAltaDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaAltaDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.FechaAltaHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaAltaHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserName));
                    this.DataBase.AddInParameter(storedProcCommand, "UserName", DbType.String, (object)EntityFilter.UserName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePassword", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePassword));
                    this.DataBase.AddInParameter(storedProcCommand, "Password", DbType.String, (object)EntityFilter.Password);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmail));
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.String, (object)EntityFilter.Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsApproved", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIsApproved));
                    this.DataBase.AddInParameter(storedProcCommand, "IsApproved", DbType.Boolean, (object)EntityFilter.IsApproved);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIsLockedOut", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIsLockedOut));
                    this.DataBase.AddInParameter(storedProcCommand, "IsLockedOut", DbType.Boolean, (object)EntityFilter.IsLockedOut);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLastLoginDate", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLastLoginDate));
                    if (EntityFilter.LastLoginDateDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.LastLoginDateDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.LastLoginDateHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.LastLoginDateHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "LastLoginDateHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityFilter.RoleName);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAll(string OrdenDeRegistros)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vExtendedProperties_GetAll");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    return this.DataBase.ExecuteDataSet(storedProcCommand).Tables[0];
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

