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
    public class aspnet_RolesData
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

        public aspnet_RolesData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public aspnet_RolesData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public void Insert(Guid ApplicationId, Guid RoleId, string RoleName, string LoweredRoleName, string Description, string LongDescription)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)Description);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)LongDescription);
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

        public void Insert(aspnet_RolesEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)EntityInsert.ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityInsert.RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityInsert.RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)EntityInsert.LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)EntityInsert.Description);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)EntityInsert.LongDescription);
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

        public bool Delete(Guid RoleId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
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

        public bool Delete(aspnet_RolesEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityKey.RoleId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_DeleteWhereExtendido");
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

        public bool Update(Guid? ApplicationId, Guid? RoleId, string RoleName, string LoweredRoleName, string Description, string LongDescription)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)Description);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)LongDescription);
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

        public bool Update(aspnet_RolesEntityKey EntityKey, aspnet_RolesEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityKey.RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)EntityUpdate.ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityUpdate.RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)EntityUpdate.LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)EntityUpdate.Description);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)EntityUpdate.LongDescription);
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

        public bool UpdateWhereExtendido(string WhereEx, aspnet_RolesEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)EntityUpdate.ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityUpdate.RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)EntityUpdate.LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)EntityUpdate.Description);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)EntityUpdate.LongDescription);
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

        public bool UpdateNull(Guid RoleId, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
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

        public bool UpdateNull(aspnet_RolesEntityKey EntityKey, aspnet_RolesEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityKey.RoleId);
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeApplicationId, Guid? ApplicationId, string OpeRoleId, Guid? RoleId, string OpeRoleName, string RoleName, string OpeLoweredRoleName, string LoweredRoleName, string OpeDescription, string Description, string OpeLongDescription, string LongDescription)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApplicationId", DbType.String, (object)OpeApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)OpeRoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)OpeRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLoweredRoleName", DbType.String, (object)OpeLoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDescription", DbType.String, (object)OpeDescription);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)Description);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLongDescription", DbType.String, (object)OpeLongDescription);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)LongDescription);
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

        public DataTable Search(aspnet_RolesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApplicationId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApplicationId));
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)EntityFilter.ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleId));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityFilter.RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityFilter.RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLoweredRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLoweredRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)EntityFilter.LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDescription", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeDescription));
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)EntityFilter.Description);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLongDescription", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLongDescription));
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)EntityFilter.LongDescription);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeApplicationId, Guid? ApplicationId, string OpeRoleId, Guid? RoleId, string OpeRoleName, string RoleName, string OpeLoweredRoleName, string LoweredRoleName, string OpeDescription, string Description, string OpeLongDescription, string LongDescription)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApplicationId", DbType.String, (object)OpeApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)OpeRoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)OpeRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLoweredRoleName", DbType.String, (object)OpeLoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDescription", DbType.String, (object)OpeDescription);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)Description);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLongDescription", DbType.String, (object)OpeLongDescription);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)LongDescription);
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

        public DataTable SearchWithPagination(aspnet_RolesEntityPaged EntityPaged, aspnet_RolesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApplicationId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApplicationId));
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)EntityFilter.ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleId));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityFilter.RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityFilter.RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLoweredRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLoweredRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)EntityFilter.LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDescription", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeDescription));
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)EntityFilter.Description);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLongDescription", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLongDescription));
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)EntityFilter.LongDescription);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeApplicationId, Guid? ApplicationId, string OpeRoleId, Guid? RoleId, string OpeRoleName, string RoleName, string OpeLoweredRoleName, string LoweredRoleName, string OpeDescription, string Description, string OpeLongDescription, string LongDescription)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApplicationId", DbType.String, (object)OpeApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)OpeRoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)OpeRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLoweredRoleName", DbType.String, (object)OpeLoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDescription", DbType.String, (object)OpeDescription);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)Description);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLongDescription", DbType.String, (object)OpeLongDescription);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)LongDescription);
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

        public DataTable SearchCount(aspnet_RolesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApplicationId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApplicationId));
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)EntityFilter.ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleId));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityFilter.RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityFilter.RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLoweredRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLoweredRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)EntityFilter.LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDescription", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeDescription));
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)EntityFilter.Description);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLongDescription", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLongDescription));
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)EntityFilter.LongDescription);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeApplicationId, Guid? ApplicationId, string OpeRoleId, Guid? RoleId, string OpeRoleName, string RoleName, string OpeLoweredRoleName, string LoweredRoleName, string OpeDescription, string Description, string OpeLongDescription, string LongDescription)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApplicationId", DbType.String, (object)OpeApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)OpeRoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)OpeRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLoweredRoleName", DbType.String, (object)OpeLoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDescription", DbType.String, (object)OpeDescription);
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)Description);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLongDescription", DbType.String, (object)OpeLongDescription);
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)LongDescription);
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

        public DataTable SearchCountWithPagination(aspnet_RolesEntityPaged EntityPaged, aspnet_RolesEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApplicationId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApplicationId));
                    this.DataBase.AddInParameter(storedProcCommand, "ApplicationId", DbType.Guid, (object)EntityFilter.ApplicationId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleId));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityFilter.RoleId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "RoleName", DbType.String, (object)EntityFilter.RoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLoweredRoleName", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLoweredRoleName));
                    this.DataBase.AddInParameter(storedProcCommand, "LoweredRoleName", DbType.String, (object)EntityFilter.LoweredRoleName);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDescription", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeDescription));
                    this.DataBase.AddInParameter(storedProcCommand, "Description", DbType.String, (object)EntityFilter.Description);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeLongDescription", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeLongDescription));
                    this.DataBase.AddInParameter(storedProcCommand, "LongDescription", DbType.AnsiString, (object)EntityFilter.LongDescription);
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

        public DataTable SearchOne(string OpeRoleId, Guid RoleId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)RoleId);
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

        public DataTable SearchOne(aspnet_RolesEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeRoleId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "RoleId", DbType.Guid, (object)EntityKey.RoleId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("aspnet_Roles_GetAll");
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

