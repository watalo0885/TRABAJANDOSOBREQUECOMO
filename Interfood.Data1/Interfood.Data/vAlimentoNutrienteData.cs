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
    public class vAlimentoNutrienteData
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

        public vAlimentoNutrienteData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public vAlimentoNutrienteData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeAlimentoNombre, string AlimentoNombre, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, Decimal? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId, string OpePerteneceA, int? PerteneceA)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)OpeAlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNombre", DbType.String, (object)OpeAlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNombre", DbType.AnsiString, (object)AlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteNombre", DbType.String, (object)OpeNutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteNombre", DbType.AnsiString, (object)NutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNutrienteCantidad", DbType.String, (object)OpeAlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNutrienteCantidad", DbType.Decimal, (object)AlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteUDMId", DbType.String, (object)OpeNutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteUDMId", DbType.AnsiString, (object)NutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)OpePerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
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

        public DataTable Search(vAlimentoNutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)EntityFilter.AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNombre", DbType.AnsiString, (object)EntityFilter.AlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteNombre", DbType.AnsiString, (object)EntityFilter.NutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNutrienteCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoNutrienteCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNutrienteCantidad", DbType.Decimal, (object)EntityFilter.AlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteUDMId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteUDMId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteUDMId", DbType.AnsiString, (object)EntityFilter.NutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePerteneceA));
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityFilter.PerteneceA);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeAlimentoNombre, string AlimentoNombre, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, Decimal? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId, string OpePerteneceA, int? PerteneceA)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)OpeAlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNombre", DbType.String, (object)OpeAlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNombre", DbType.AnsiString, (object)AlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteNombre", DbType.String, (object)OpeNutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteNombre", DbType.AnsiString, (object)NutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNutrienteCantidad", DbType.String, (object)OpeAlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNutrienteCantidad", DbType.Decimal, (object)AlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteUDMId", DbType.String, (object)OpeNutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteUDMId", DbType.AnsiString, (object)NutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)OpePerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
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

        public DataTable SearchWithPagination(vAlimentoNutrienteEntityPaged EntityPaged, vAlimentoNutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)EntityFilter.AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNombre", DbType.AnsiString, (object)EntityFilter.AlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteNombre", DbType.AnsiString, (object)EntityFilter.NutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNutrienteCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoNutrienteCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNutrienteCantidad", DbType.Decimal, (object)EntityFilter.AlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteUDMId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteUDMId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteUDMId", DbType.AnsiString, (object)EntityFilter.NutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePerteneceA));
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityFilter.PerteneceA);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeAlimentoNombre, string AlimentoNombre, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, Decimal? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId, string OpePerteneceA, int? PerteneceA)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)OpeAlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNombre", DbType.String, (object)OpeAlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNombre", DbType.AnsiString, (object)AlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteNombre", DbType.String, (object)OpeNutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteNombre", DbType.AnsiString, (object)NutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNutrienteCantidad", DbType.String, (object)OpeAlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNutrienteCantidad", DbType.Decimal, (object)AlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteUDMId", DbType.String, (object)OpeNutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteUDMId", DbType.AnsiString, (object)NutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)OpePerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
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

        public DataTable SearchCount(vAlimentoNutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)EntityFilter.AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNombre", DbType.AnsiString, (object)EntityFilter.AlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteNombre", DbType.AnsiString, (object)EntityFilter.NutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNutrienteCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoNutrienteCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNutrienteCantidad", DbType.Decimal, (object)EntityFilter.AlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteUDMId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteUDMId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteUDMId", DbType.AnsiString, (object)EntityFilter.NutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePerteneceA));
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityFilter.PerteneceA);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeAlimentoNombre, string AlimentoNombre, string OpeNutrienteId, int? NutrienteId, string OpeNutrienteNombre, string NutrienteNombre, string OpeAlimentoNutrienteCantidad, Decimal? AlimentoNutrienteCantidad, string OpeNutrienteUDMId, string NutrienteUDMId, string OpePerteneceA, int? PerteneceA)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)OpeAlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNombre", DbType.String, (object)OpeAlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNombre", DbType.AnsiString, (object)AlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)OpeNutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteNombre", DbType.String, (object)OpeNutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteNombre", DbType.AnsiString, (object)NutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNutrienteCantidad", DbType.String, (object)OpeAlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNutrienteCantidad", DbType.Decimal, (object)AlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteUDMId", DbType.String, (object)OpeNutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteUDMId", DbType.AnsiString, (object)NutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)OpePerteneceA);
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)PerteneceA);
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

        public DataTable SearchCountWithPagination(vAlimentoNutrienteEntityPaged EntityPaged, vAlimentoNutrienteEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)EntityFilter.AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNombre", DbType.AnsiString, (object)EntityFilter.AlimentoNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteId", DbType.Int32, (object)EntityFilter.NutrienteId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteNombre", DbType.AnsiString, (object)EntityFilter.NutrienteNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoNutrienteCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoNutrienteCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoNutrienteCantidad", DbType.Decimal, (object)EntityFilter.AlimentoNutrienteCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutrienteUDMId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutrienteUDMId));
                    this.DataBase.AddInParameter(storedProcCommand, "NutrienteUDMId", DbType.AnsiString, (object)EntityFilter.NutrienteUDMId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePerteneceA", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePerteneceA));
                    this.DataBase.AddInParameter(storedProcCommand, "PerteneceA", DbType.Int32, (object)EntityFilter.PerteneceA);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentoNutriente_GetAll");
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

