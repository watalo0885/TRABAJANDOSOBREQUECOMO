﻿using System;
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
    public class vEncuestaHeaderData
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

        public vEncuestaHeaderData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public vEncuestaHeaderData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)OpeApellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)OpeNombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)OpeHistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestador", DbType.String, (object)OpeEncuestador);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)Encuestador);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)OpeFecha);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)FechaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)FechaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApeNom", DbType.String, (object)OpeApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDireccion", DbType.String, (object)OpeDireccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefono", DbType.String, (object)OpeTelefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)Telefono);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)OpeTipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
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

        public DataTable Search(vEncuestaHeaderEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApellido));
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityFilter.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombres));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityFilter.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeHistoriaClinica));
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityFilter.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestador", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestador));
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)EntityFilter.Encuestador);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApeNom", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApeNom));
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)EntityFilter.ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDireccion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeDireccion));
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)EntityFilter.Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefono", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefono));
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)EntityFilter.Telefono);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDietaId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityFilter.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)OpeApellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)OpeNombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)OpeHistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestador", DbType.String, (object)OpeEncuestador);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)Encuestador);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)OpeFecha);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)FechaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)FechaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApeNom", DbType.String, (object)OpeApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDireccion", DbType.String, (object)OpeDireccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefono", DbType.String, (object)OpeTelefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)Telefono);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)OpeTipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
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

        public DataTable SearchWithPagination(vEncuestaHeaderEntityPaged EntityPaged, vEncuestaHeaderEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApellido));
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityFilter.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombres));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityFilter.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeHistoriaClinica));
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityFilter.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestador", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestador));
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)EntityFilter.Encuestador);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApeNom", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApeNom));
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)EntityFilter.ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDireccion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeDireccion));
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)EntityFilter.Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefono", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefono));
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)EntityFilter.Telefono);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDietaId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityFilter.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)OpeApellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)OpeNombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)OpeHistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestador", DbType.String, (object)OpeEncuestador);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)Encuestador);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)OpeFecha);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)FechaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)FechaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApeNom", DbType.String, (object)OpeApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDireccion", DbType.String, (object)OpeDireccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefono", DbType.String, (object)OpeTelefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)Telefono);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)OpeTipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
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

        public DataTable SearchCount(vEncuestaHeaderEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApellido));
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityFilter.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombres));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityFilter.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeHistoriaClinica));
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityFilter.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestador", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestador));
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)EntityFilter.Encuestador);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApeNom", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApeNom));
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)EntityFilter.ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDireccion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeDireccion));
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)EntityFilter.Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefono", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefono));
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)EntityFilter.Telefono);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDietaId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityFilter.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)OpeUserId);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)OpeApellido);
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)OpeNombres);
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)OpeHistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestador", DbType.String, (object)OpeEncuestador);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)Encuestador);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeFecha", DbType.String, (object)OpeFecha);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaDesde", DbType.String, (object)FechaDesde);
                    this.DataBase.AddInParameter(storedProcCommand, "FechaHasta", DbType.String, (object)FechaHasta);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApeNom", DbType.String, (object)OpeApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDireccion", DbType.String, (object)OpeDireccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefono", DbType.String, (object)OpeTelefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)Telefono);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)OpeTipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)OpeTipoDeDieta);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)TipoDeDieta);
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

        public DataTable SearchCountWithPagination(vEncuestaHeaderEntityPaged EntityPaged, vEncuestaHeaderEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeUserId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeUserId));
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityFilter.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApellido", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApellido));
                    this.DataBase.AddInParameter(storedProcCommand, "Apellido", DbType.AnsiString, (object)EntityFilter.Apellido);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNombres", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNombres));
                    this.DataBase.AddInParameter(storedProcCommand, "Nombres", DbType.AnsiString, (object)EntityFilter.Nombres);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeHistoriaClinica", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeHistoriaClinica));
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityFilter.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestador", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestador));
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)EntityFilter.Encuestador);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeApeNom", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeApeNom));
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)EntityFilter.ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeDireccion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeDireccion));
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)EntityFilter.Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTelefono", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTelefono));
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)EntityFilter.Telefono);
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDietaId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDietaId));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityFilter.TipoDeDietaId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTipoDeDieta", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTipoDeDieta));
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDieta", DbType.AnsiString, (object)EntityFilter.TipoDeDieta);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("vEncuestaHeader_GetAll");
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
