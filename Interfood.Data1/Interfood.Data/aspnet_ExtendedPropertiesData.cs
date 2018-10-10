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
    public class aspnet_ExtendedPropertiesData
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

        public aspnet_ExtendedPropertiesData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public aspnet_ExtendedPropertiesData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public void Insert(Guid UserId, string Apellido, string Nombres, string Empresa, int LimiteDeEncuestas, string TelefonoFijo1, string TelefonoFijo2, string Fax, string Celular, string Email, DateTime FechaAlta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)Email);
                    DateTime dateTime = Convert.ToDateTime(FechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAlta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    this.DataBase.ExecuteNonQuery(storedProcCommand);
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

        public void Insert(aspnet_ExtendedPropertiesEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityInsert.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityInsert.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityInsert.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)EntityInsert.Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)EntityInsert.LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)EntityInsert.TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)EntityInsert.TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)EntityInsert.Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)EntityInsert.Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)EntityInsert.Email);
                    DateTime dateTime = Convert.ToDateTime(EntityInsert.FechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAlta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    this.DataBase.ExecuteNonQuery(storedProcCommand);
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

        public bool Delete(Guid UserId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool Delete(aspnet_ExtendedPropertiesEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityKey.UserId);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool DeleteWhereExtendido(string WhereEx)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_DeleteWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool Update(Guid? UserId, string Apellido, string Nombres, string Empresa, int? LimiteDeEncuestas, string TelefonoFijo1, string TelefonoFijo2, string Fax, string Celular, string Email, DateTime? FechaAlta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)Email);
                    if (FechaAlta.HasValue)
                    {
                        DateTime dateTime = Convert.ToDateTime((object)FechaAlta);
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAlta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAlta", DbType.DateTime, (object)null);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool Update(aspnet_ExtendedPropertiesEntityKey EntityKey, aspnet_ExtendedPropertiesEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityKey.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityUpdate.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityUpdate.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)EntityUpdate.Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)EntityUpdate.LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)EntityUpdate.TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)EntityUpdate.TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)EntityUpdate.Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)EntityUpdate.Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)EntityUpdate.Email);
                    if (EntityUpdate.FechaAlta.HasValue)
                    {
                        DateTime dateTime = Convert.ToDateTime((object)EntityUpdate.FechaAlta);
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAlta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAlta", DbType.DateTime, (object)null);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool UpdateWhereExtendido(string WhereEx, aspnet_ExtendedPropertiesEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityUpdate.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityUpdate.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Empresa", DbType.AnsiString, (object)EntityUpdate.Empresa);
                    this.DataBase.AddInParameter(storedProcCommand, "LimiteDeEncuestas", DbType.Int32, (object)EntityUpdate.LimiteDeEncuestas);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo1", DbType.AnsiString, (object)EntityUpdate.TelefonoFijo1);
                    this.DataBase.AddInParameter(storedProcCommand, "TelefonoFijo2", DbType.AnsiString, (object)EntityUpdate.TelefonoFijo2);
                    this.DataBase.AddInParameter(storedProcCommand, "Fax", DbType.AnsiString, (object)EntityUpdate.Fax);
                    this.DataBase.AddInParameter(storedProcCommand, "Celular", DbType.AnsiString, (object)EntityUpdate.Celular);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)EntityUpdate.Email);
                    if (EntityUpdate.FechaAlta.HasValue)
                    {
                        DateTime dateTime = Convert.ToDateTime((object)EntityUpdate.FechaAlta);
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAlta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaAlta", DbType.DateTime, (object)null);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool UpdateNull(Guid UserId, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "FieldList", DbType.String, (object)ListaDeCampos);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public bool UpdateNull(aspnet_ExtendedPropertiesEntityKey EntityKey, aspnet_ExtendedPropertiesEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityKey.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "FieldList", DbType.String, (object)EntityUpdateNullFields.FieldList);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityUpdateNullFields.WhereExtendido);
                    return Convert.ToBoolean(this.DataBase.ExecuteNonQuery(storedProcCommand));
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeEmail, string Email, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_Search");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)OpeEmail);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)OpeFechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)FechaAltaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)FechaAltaHasta);
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

        public DataTable Search(aspnet_ExtendedPropertiesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_Search");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmail));
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)EntityFilter.Email);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeEmail, string Email, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)OpeEmail);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)OpeFechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)FechaAltaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)FechaAltaHasta);
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

        public DataTable SearchWithPagination(aspnet_ExtendedPropertiesEntityPaged EntityPaged, aspnet_ExtendedPropertiesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmail));
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)EntityFilter.Email);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeEmail, string Email, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_SearchCount");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)OpeEmail);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)OpeFechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)FechaAltaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)FechaAltaHasta);
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

        public DataTable SearchCount(aspnet_ExtendedPropertiesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_SearchCount");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmail));
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)EntityFilter.Email);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeLimiteDeEncuestas, int? LimiteDeEncuestas, string OpeTelefonoFijo1, string TelefonoFijo1, string OpeTelefonoFijo2, string TelefonoFijo2, string OpeFax, string Fax, string OpeCelular, string Celular, string OpeEmail, string Email, string OpeFechaAlta, string FechaAltaDesde, string FechaAltaHasta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)OpeEmail);
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)Email);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFechaAlta", DbType.String, (object)OpeFechaAlta);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaDesde", DbType.String, (object)FechaAltaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaAltaHasta", DbType.String, (object)FechaAltaHasta);
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

        public DataTable SearchCountWithPagination(aspnet_ExtendedPropertiesEntityPaged EntityPaged, aspnet_ExtendedPropertiesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEmail", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEmail));
                    this.DataBase.AddInParameter(storedProcCommand, "Email", DbType.AnsiString, (object)EntityFilter.Email);
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

        public DataTable SearchOne(string OpeUserId, Guid UserId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
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

        public DataTable SearchOne(aspnet_ExtendedPropertiesEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityKey.UserId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_ExtendedProperties_GetAll");
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
