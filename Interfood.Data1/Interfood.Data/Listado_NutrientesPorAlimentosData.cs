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
    public class Listado_NutrientesPorAlimentosData
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

        public Listado_NutrientesPorAlimentosData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public Listado_NutrientesPorAlimentosData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeAlimento, string Alimento, string OpeCantidadAlimento, Decimal? CantidadAlimento, string OpeNutriente, string Nutriente, string OpeCantidadNutriente, Decimal? CantidadNutriente, string OpeUserId, Guid? UserId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)OpeHistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)OpeFecha);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)FechaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)FechaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeSexo", DbType.String, (object)OpeSexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEdad", DbType.String, (object)OpeEdad);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePeso", DbType.String, (object)OpePeso);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTalla", DbType.String, (object)OpeTalla);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIMC", DbType.String, (object)OpeIMC);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimento", DbType.String, (object)OpeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "Alimento", DbType.AnsiString, (object)Alimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadAlimento", DbType.String, (object)OpeCantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadAlimento", DbType.Decimal, (object)CantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutriente", DbType.String, (object)OpeNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "Nutriente", DbType.AnsiString, (object)Nutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadNutriente", DbType.String, (object)OpeCantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadNutriente", DbType.Decimal, (object)CantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
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

        public DataTable Search(Listado_NutrientesPorAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeHistoriaClinica));
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityFilter.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFecha));
                    if (EntityFilter.FechaDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.FechaHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeSexo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeSexo));
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)EntityFilter.Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEdad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEdad));
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)EntityFilter.Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePeso", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePeso));
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)EntityFilter.Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTalla", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTalla));
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)EntityFilter.Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIMC", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIMC));
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)EntityFilter.IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "Alimento", DbType.AnsiString, (object)EntityFilter.Alimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidadAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadAlimento", DbType.Decimal, (object)EntityFilter.CantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutriente", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutriente));
                    this.DataBase.AddInParameter(storedProcCommand, "Nutriente", DbType.AnsiString, (object)EntityFilter.Nutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadNutriente", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidadNutriente));
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadNutriente", DbType.Decimal, (object)EntityFilter.CantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeAlimento, string Alimento, string OpeCantidadAlimento, Decimal? CantidadAlimento, string OpeNutriente, string Nutriente, string OpeCantidadNutriente, Decimal? CantidadNutriente, string OpeUserId, Guid? UserId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)OpeHistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)OpeFecha);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)FechaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)FechaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeSexo", DbType.String, (object)OpeSexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEdad", DbType.String, (object)OpeEdad);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePeso", DbType.String, (object)OpePeso);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTalla", DbType.String, (object)OpeTalla);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIMC", DbType.String, (object)OpeIMC);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimento", DbType.String, (object)OpeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "Alimento", DbType.AnsiString, (object)Alimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadAlimento", DbType.String, (object)OpeCantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadAlimento", DbType.Decimal, (object)CantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutriente", DbType.String, (object)OpeNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "Nutriente", DbType.AnsiString, (object)Nutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadNutriente", DbType.String, (object)OpeCantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadNutriente", DbType.Decimal, (object)CantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
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

        public DataTable SearchWithPagination(Listado_NutrientesPorAlimentosEntityPaged EntityPaged, Listado_NutrientesPorAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_SearchWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeHistoriaClinica));
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityFilter.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFecha));
                    if (EntityFilter.FechaDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.FechaHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeSexo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeSexo));
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)EntityFilter.Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEdad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEdad));
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)EntityFilter.Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePeso", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePeso));
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)EntityFilter.Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTalla", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTalla));
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)EntityFilter.Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIMC", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIMC));
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)EntityFilter.IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "Alimento", DbType.AnsiString, (object)EntityFilter.Alimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidadAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadAlimento", DbType.Decimal, (object)EntityFilter.CantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutriente", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutriente));
                    this.DataBase.AddInParameter(storedProcCommand, "Nutriente", DbType.AnsiString, (object)EntityFilter.Nutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadNutriente", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidadNutriente));
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadNutriente", DbType.Decimal, (object)EntityFilter.CantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeAlimento, string Alimento, string OpeCantidadAlimento, Decimal? CantidadAlimento, string OpeNutriente, string Nutriente, string OpeCantidadNutriente, Decimal? CantidadNutriente, string OpeUserId, Guid? UserId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)OpeHistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)OpeFecha);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)FechaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)FechaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeSexo", DbType.String, (object)OpeSexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEdad", DbType.String, (object)OpeEdad);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePeso", DbType.String, (object)OpePeso);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTalla", DbType.String, (object)OpeTalla);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIMC", DbType.String, (object)OpeIMC);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimento", DbType.String, (object)OpeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "Alimento", DbType.AnsiString, (object)Alimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadAlimento", DbType.String, (object)OpeCantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadAlimento", DbType.Decimal, (object)CantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutriente", DbType.String, (object)OpeNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "Nutriente", DbType.AnsiString, (object)Nutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadNutriente", DbType.String, (object)OpeCantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadNutriente", DbType.Decimal, (object)CantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
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

        public DataTable SearchCount(Listado_NutrientesPorAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeHistoriaClinica));
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityFilter.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFecha));
                    if (EntityFilter.FechaDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.FechaHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeSexo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeSexo));
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)EntityFilter.Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEdad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEdad));
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)EntityFilter.Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePeso", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePeso));
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)EntityFilter.Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTalla", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTalla));
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)EntityFilter.Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIMC", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIMC));
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)EntityFilter.IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "Alimento", DbType.AnsiString, (object)EntityFilter.Alimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidadAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadAlimento", DbType.Decimal, (object)EntityFilter.CantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutriente", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutriente));
                    this.DataBase.AddInParameter(storedProcCommand, "Nutriente", DbType.AnsiString, (object)EntityFilter.Nutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadNutriente", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidadNutriente));
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadNutriente", DbType.Decimal, (object)EntityFilter.CantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeAlimento, string Alimento, string OpeCantidadAlimento, Decimal? CantidadAlimento, string OpeNutriente, string Nutriente, string OpeCantidadNutriente, Decimal? CantidadNutriente, string OpeUserId, Guid? UserId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)OpeHistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)OpeFecha);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)FechaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)FechaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeSexo", DbType.String, (object)OpeSexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEdad", DbType.String, (object)OpeEdad);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePeso", DbType.String, (object)OpePeso);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTalla", DbType.String, (object)OpeTalla);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIMC", DbType.String, (object)OpeIMC);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimento", DbType.String, (object)OpeAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "Alimento", DbType.AnsiString, (object)Alimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadAlimento", DbType.String, (object)OpeCantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadAlimento", DbType.Decimal, (object)CantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutriente", DbType.String, (object)OpeNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "Nutriente", DbType.AnsiString, (object)Nutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadNutriente", DbType.String, (object)OpeCantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadNutriente", DbType.Decimal, (object)CantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
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

        public DataTable SearchCountWithPagination(Listado_NutrientesPorAlimentosEntityPaged EntityPaged, Listado_NutrientesPorAlimentosEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_SearchCountWithPagination");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "PageSize", DbType.Int32, (object)EntityPaged.pageSize);
                    this.DataBase.AddInParameter(storedProcCommand, "PageReturn", DbType.Int32, (object)EntityPaged.pageReturn);
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeHistoriaClinica));
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityFilter.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeFecha));
                    if (EntityFilter.FechaDesde.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaDesde.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)DBNull.Value);
                    if (EntityFilter.FechaHasta.HasValue)
                    {
                        DateTime dateTime = DateTime.Parse(EntityFilter.FechaHasta.ToString());
                        this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)DBNull.Value);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeSexo", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeSexo));
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)EntityFilter.Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEdad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEdad));
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)EntityFilter.Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePeso", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePeso));
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)EntityFilter.Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTalla", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTalla));
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)EntityFilter.Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeIMC", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeIMC));
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)EntityFilter.IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "Alimento", DbType.AnsiString, (object)EntityFilter.Alimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadAlimento", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidadAlimento));
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadAlimento", DbType.Decimal, (object)EntityFilter.CantidadAlimento);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNutriente", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNutriente));
                    this.DataBase.AddInParameter(storedProcCommand, "Nutriente", DbType.AnsiString, (object)EntityFilter.Nutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidadNutriente", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidadNutriente));
                    this.DataBase.AddInParameter(storedProcCommand, "CantidadNutriente", DbType.Decimal, (object)EntityFilter.CantidadNutriente);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("Listado_NutrientesPorAlimentos_GetAll");
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
