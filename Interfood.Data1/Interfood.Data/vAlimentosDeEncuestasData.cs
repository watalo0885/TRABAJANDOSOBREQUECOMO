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
    public class vAlimentosDeEncuestasData
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

        public vAlimentosDeEncuestasData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public vAlimentosDeEncuestasData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeOrden1, int? Orden1, string OpeOrden2, int? Orden2, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeNombre, string Nombre, string OpeNunca, int? Nunca, string OpeVM, int? VM, string OpeVS, int? VS, string OpeVD, int? VD, string OpeP, int? P, string OpeM, int? M, string OpeG, int? G)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden1", DbType.String, (object)OpeOrden1);
                    this.DataBase.AddInParameter(storedProcCommand, "Orden1", DbType.Int32, (object)Orden1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden2", DbType.String, (object)OpeOrden2);
                    this.DataBase.AddInParameter(storedProcCommand, "Orden2", DbType.Int32, (object)Orden2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)OpeAlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Int32, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVM", DbType.String, (object)OpeVM);
                    this.DataBase.AddInParameter(storedProcCommand, "VM", DbType.Int32, (object)VM);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVS", DbType.String, (object)OpeVS);
                    this.DataBase.AddInParameter(storedProcCommand, "VS", DbType.Int32, (object)VS);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVD", DbType.String, (object)OpeVD);
                    this.DataBase.AddInParameter(storedProcCommand, "VD", DbType.Int32, (object)VD);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeP", DbType.String, (object)OpeP);
                    this.DataBase.AddInParameter(storedProcCommand, "P", DbType.Int32, (object)P);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeM", DbType.String, (object)OpeM);
                    this.DataBase.AddInParameter(storedProcCommand, "M", DbType.Int32, (object)M);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeG", DbType.String, (object)OpeG);
                    this.DataBase.AddInParameter(storedProcCommand, "G", DbType.Int32, (object)G);
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

        public DataTable Search(vAlimentosDeEncuestasEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden1", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrden1));
                    this.DataBase.AddInParameter(storedProcCommand, "Orden1", DbType.Int32, (object)EntityFilter.Orden1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden2", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrden2));
                    this.DataBase.AddInParameter(storedProcCommand, "Orden2", DbType.Int32, (object)EntityFilter.Orden2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)EntityFilter.AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Int32, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVM", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVM));
                    this.DataBase.AddInParameter(storedProcCommand, "VM", DbType.Int32, (object)EntityFilter.VM);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVS", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVS));
                    this.DataBase.AddInParameter(storedProcCommand, "VS", DbType.Int32, (object)EntityFilter.VS);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVD", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVD));
                    this.DataBase.AddInParameter(storedProcCommand, "VD", DbType.Int32, (object)EntityFilter.VD);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeP", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeP));
                    this.DataBase.AddInParameter(storedProcCommand, "P", DbType.Int32, (object)EntityFilter.P);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeM", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeM));
                    this.DataBase.AddInParameter(storedProcCommand, "M", DbType.Int32, (object)EntityFilter.M);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeG", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeG));
                    this.DataBase.AddInParameter(storedProcCommand, "G", DbType.Int32, (object)EntityFilter.G);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeOrden1, int? Orden1, string OpeOrden2, int? Orden2, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeNombre, string Nombre, string OpeNunca, int? Nunca, string OpeVM, int? VM, string OpeVS, int? VS, string OpeVD, int? VD, string OpeP, int? P, string OpeM, int? M, string OpeG, int? G)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden1", DbType.String, (object)OpeOrden1);
                    this.DataBase.AddInParameter(storedProcCommand, "Orden1", DbType.Int32, (object)Orden1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden2", DbType.String, (object)OpeOrden2);
                    this.DataBase.AddInParameter(storedProcCommand, "Orden2", DbType.Int32, (object)Orden2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)OpeAlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Int32, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVM", DbType.String, (object)OpeVM);
                    this.DataBase.AddInParameter(storedProcCommand, "VM", DbType.Int32, (object)VM);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVS", DbType.String, (object)OpeVS);
                    this.DataBase.AddInParameter(storedProcCommand, "VS", DbType.Int32, (object)VS);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVD", DbType.String, (object)OpeVD);
                    this.DataBase.AddInParameter(storedProcCommand, "VD", DbType.Int32, (object)VD);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeP", DbType.String, (object)OpeP);
                    this.DataBase.AddInParameter(storedProcCommand, "P", DbType.Int32, (object)P);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeM", DbType.String, (object)OpeM);
                    this.DataBase.AddInParameter(storedProcCommand, "M", DbType.Int32, (object)M);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeG", DbType.String, (object)OpeG);
                    this.DataBase.AddInParameter(storedProcCommand, "G", DbType.Int32, (object)G);
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

        public DataTable SearchWithPagination(vAlimentosDeEncuestasEntityPaged EntityPaged, vAlimentosDeEncuestasEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden1", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrden1));
                    this.DataBase.AddInParameter(storedProcCommand, "Orden1", DbType.Int32, (object)EntityFilter.Orden1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden2", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrden2));
                    this.DataBase.AddInParameter(storedProcCommand, "Orden2", DbType.Int32, (object)EntityFilter.Orden2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)EntityFilter.AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Int32, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVM", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVM));
                    this.DataBase.AddInParameter(storedProcCommand, "VM", DbType.Int32, (object)EntityFilter.VM);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVS", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVS));
                    this.DataBase.AddInParameter(storedProcCommand, "VS", DbType.Int32, (object)EntityFilter.VS);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVD", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVD));
                    this.DataBase.AddInParameter(storedProcCommand, "VD", DbType.Int32, (object)EntityFilter.VD);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeP", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeP));
                    this.DataBase.AddInParameter(storedProcCommand, "P", DbType.Int32, (object)EntityFilter.P);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeM", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeM));
                    this.DataBase.AddInParameter(storedProcCommand, "M", DbType.Int32, (object)EntityFilter.M);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeG", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeG));
                    this.DataBase.AddInParameter(storedProcCommand, "G", DbType.Int32, (object)EntityFilter.G);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeOrden1, int? Orden1, string OpeOrden2, int? Orden2, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeNombre, string Nombre, string OpeNunca, int? Nunca, string OpeVM, int? VM, string OpeVS, int? VS, string OpeVD, int? VD, string OpeP, int? P, string OpeM, int? M, string OpeG, int? G)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden1", DbType.String, (object)OpeOrden1);
                    this.DataBase.AddInParameter(storedProcCommand, "Orden1", DbType.Int32, (object)Orden1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden2", DbType.String, (object)OpeOrden2);
                    this.DataBase.AddInParameter(storedProcCommand, "Orden2", DbType.Int32, (object)Orden2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)OpeAlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Int32, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVM", DbType.String, (object)OpeVM);
                    this.DataBase.AddInParameter(storedProcCommand, "VM", DbType.Int32, (object)VM);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVS", DbType.String, (object)OpeVS);
                    this.DataBase.AddInParameter(storedProcCommand, "VS", DbType.Int32, (object)VS);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVD", DbType.String, (object)OpeVD);
                    this.DataBase.AddInParameter(storedProcCommand, "VD", DbType.Int32, (object)VD);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeP", DbType.String, (object)OpeP);
                    this.DataBase.AddInParameter(storedProcCommand, "P", DbType.Int32, (object)P);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeM", DbType.String, (object)OpeM);
                    this.DataBase.AddInParameter(storedProcCommand, "M", DbType.Int32, (object)M);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeG", DbType.String, (object)OpeG);
                    this.DataBase.AddInParameter(storedProcCommand, "G", DbType.Int32, (object)G);
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

        public DataTable SearchCount(vAlimentosDeEncuestasEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden1", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrden1));
                    this.DataBase.AddInParameter(storedProcCommand, "Orden1", DbType.Int32, (object)EntityFilter.Orden1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden2", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrden2));
                    this.DataBase.AddInParameter(storedProcCommand, "Orden2", DbType.Int32, (object)EntityFilter.Orden2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)EntityFilter.AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Int32, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVM", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVM));
                    this.DataBase.AddInParameter(storedProcCommand, "VM", DbType.Int32, (object)EntityFilter.VM);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVS", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVS));
                    this.DataBase.AddInParameter(storedProcCommand, "VS", DbType.Int32, (object)EntityFilter.VS);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVD", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVD));
                    this.DataBase.AddInParameter(storedProcCommand, "VD", DbType.Int32, (object)EntityFilter.VD);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeP", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeP));
                    this.DataBase.AddInParameter(storedProcCommand, "P", DbType.Int32, (object)EntityFilter.P);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeM", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeM));
                    this.DataBase.AddInParameter(storedProcCommand, "M", DbType.Int32, (object)EntityFilter.M);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeG", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeG));
                    this.DataBase.AddInParameter(storedProcCommand, "G", DbType.Int32, (object)EntityFilter.G);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeOrden1, int? Orden1, string OpeOrden2, int? Orden2, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeNombre, string Nombre, string OpeNunca, int? Nunca, string OpeVM, int? VM, string OpeVS, int? VS, string OpeVD, int? VD, string OpeP, int? P, string OpeM, int? M, string OpeG, int? G)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden1", DbType.String, (object)OpeOrden1);
                    this.DataBase.AddInParameter(storedProcCommand, "Orden1", DbType.Int32, (object)Orden1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden2", DbType.String, (object)OpeOrden2);
                    this.DataBase.AddInParameter(storedProcCommand, "Orden2", DbType.Int32, (object)Orden2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)OpeTipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)OpeAlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)OpeNombre);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Int32, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVM", DbType.String, (object)OpeVM);
                    this.DataBase.AddInParameter(storedProcCommand, "VM", DbType.Int32, (object)VM);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVS", DbType.String, (object)OpeVS);
                    this.DataBase.AddInParameter(storedProcCommand, "VS", DbType.Int32, (object)VS);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVD", DbType.String, (object)OpeVD);
                    this.DataBase.AddInParameter(storedProcCommand, "VD", DbType.Int32, (object)VD);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeP", DbType.String, (object)OpeP);
                    this.DataBase.AddInParameter(storedProcCommand, "P", DbType.Int32, (object)P);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeM", DbType.String, (object)OpeM);
                    this.DataBase.AddInParameter(storedProcCommand, "M", DbType.Int32, (object)M);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeG", DbType.String, (object)OpeG);
                    this.DataBase.AddInParameter(storedProcCommand, "G", DbType.Int32, (object)G);
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

        public DataTable SearchCountWithPagination(vAlimentosDeEncuestasEntityPaged EntityPaged, vAlimentosDeEncuestasEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden1", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrden1));
                    this.DataBase.AddInParameter(storedProcCommand, "Orden1", DbType.Int32, (object)EntityFilter.Orden1);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeOrden2", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeOrden2));
                    this.DataBase.AddInParameter(storedProcCommand, "Orden2", DbType.Int32, (object)EntityFilter.Orden2);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeAlimento", DbType.AnsiString, (object)EntityFilter.TipoDeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoCodigo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoCodigo));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoCodigo", DbType.AnsiString, (object)EntityFilter.AlimentoCodigo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombre", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombre));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombre", DbType.AnsiString, (object)EntityFilter.Nombre);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Int32, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVM", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVM));
                    this.DataBase.AddInParameter(storedProcCommand, "VM", DbType.Int32, (object)EntityFilter.VM);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVS", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVS));
                    this.DataBase.AddInParameter(storedProcCommand, "VS", DbType.Int32, (object)EntityFilter.VS);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVD", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVD));
                    this.DataBase.AddInParameter(storedProcCommand, "VD", DbType.Int32, (object)EntityFilter.VD);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeP", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeP));
                    this.DataBase.AddInParameter(storedProcCommand, "P", DbType.Int32, (object)EntityFilter.P);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeM", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeM));
                    this.DataBase.AddInParameter(storedProcCommand, "M", DbType.Int32, (object)EntityFilter.M);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeG", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeG));
                    this.DataBase.AddInParameter(storedProcCommand, "G", DbType.Int32, (object)EntityFilter.G);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vAlimentosDeEncuestas_GetAll");
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
