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
    public class NutrienteData
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

        public NutrienteData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public NutrienteData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public int Insert_Return_Scalar(string Nombre, string UDMId, int? PerteneceA, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
                    return (int)this.DataBase.ExecuteScalar(storedProcCommand);
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

        public int Insert_Return_Scalar(NutrienteEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityInsert.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)EntityInsert.UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityInsert.PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityInsert.Estado);
                    return (int)this.DataBase.ExecuteScalar(storedProcCommand);
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

        public bool Delete(int NutrienteId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
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

        public bool Delete(NutrienteEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityKey.NutrienteId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_DeleteWhereExtendido");
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

        public bool Update(int? NutrienteId, string Nombre, string UDMId, int? PerteneceA, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public bool Update(NutrienteEntityKey EntityKey, NutrienteEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityKey.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityUpdate.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)EntityUpdate.UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityUpdate.PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityUpdate.Estado);
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

        public bool UpdateWhereExtendido(string WhereEx, NutrienteEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityUpdate.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)EntityUpdate.UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityUpdate.PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityUpdate.Estado);
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

        public bool UpdateNull(int NutrienteId, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
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

        public bool UpdateNull(NutrienteEntityKey EntityKey, NutrienteEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityKey.NutrienteId);
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeNutrienteId, int? NutrienteId, string OpeNombre, string Nombre, string OpeUDMId, string UDMId, string OpePerteneceA, int? PerteneceA, string OpeEstado, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUDMId", DbType.String, (object)OpeUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)OpePerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable Search(NutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUDMId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUDMId));
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)EntityFilter.UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePerteneceA));
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityFilter.PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeNutrienteId, int? NutrienteId, string OpeNombre, string Nombre, string OpeUDMId, string UDMId, string OpePerteneceA, int? PerteneceA, string OpeEstado, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUDMId", DbType.String, (object)OpeUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)OpePerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable SearchWithPagination(NutrienteEntityPaged EntityPaged, NutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUDMId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUDMId));
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)EntityFilter.UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePerteneceA));
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityFilter.PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeNutrienteId, int? NutrienteId, string OpeNombre, string Nombre, string OpeUDMId, string UDMId, string OpePerteneceA, int? PerteneceA, string OpeEstado, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUDMId", DbType.String, (object)OpeUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)OpePerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable SearchCount(NutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUDMId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUDMId));
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)EntityFilter.UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePerteneceA));
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityFilter.PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeNutrienteId, int? NutrienteId, string OpeNombre, string Nombre, string OpeUDMId, string UDMId, string OpePerteneceA, int? PerteneceA, string OpeEstado, string Estado)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUDMId", DbType.String, (object)OpeUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)OpePerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)OpeEstado);
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)Estado);
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

        public DataTable SearchCountWithPagination(NutrienteEntityPaged EntityPaged, NutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUDMId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUDMId));
                    this.DataBase.AddInParameter(storedProcCommand, "UDMId", DbType.AnsiString, (object)EntityFilter.UDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePerteneceA));
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityFilter.PerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEstado", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEstado));
                    this.DataBase.AddInParameter(storedProcCommand, "Estado", DbType.AnsiString, (object)EntityFilter.Estado);
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

        public DataTable SearchOne(string OpeNutrienteId, int NutrienteId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
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

        public DataTable SearchOne(NutrienteEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityKey.NutrienteId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Nutriente_GetAll");
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

