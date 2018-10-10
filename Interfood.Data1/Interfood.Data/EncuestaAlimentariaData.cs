using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using Interfood.Configuration;
using Interfood.Entities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;


namespace Interfood.Data
{
    public class EncuestaAlimentariaData
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

        public EncuestaAlimentariaData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public EncuestaAlimentariaData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public int Insert_Return_Scalar(Guid UserId, string HistoriaClinica, string Encuestador, DateTime? Fecha, string ApeNom, string Direccion, string Telefono, string Sexo, short? Edad, Decimal? Peso, Decimal? Talla, Decimal? IMC, int? TipoDeDietaId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)Encuestador);
                    if (Fecha.HasValue)
                    {
                        DateTime dateTime = Convert.ToDateTime((object)Fecha);
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.DateTime, (object)null);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)Telefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
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

        public int Insert_Return_Scalar(EncuestaAlimentariaEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_Insert_Return_Scalar");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityInsert.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityInsert.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)EntityInsert.Encuestador);
                    if (EntityInsert.Fecha.HasValue)
                    {
                        DateTime dateTime = Convert.ToDateTime((object)EntityInsert.Fecha);
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.DateTime, (object)null);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)EntityInsert.ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)EntityInsert.Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)EntityInsert.Telefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)EntityInsert.Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)EntityInsert.Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)EntityInsert.Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)EntityInsert.Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)EntityInsert.IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityInsert.TipoDeDietaId);
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

        public bool Delete(int EncuestaNro)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
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

        public bool Delete(EncuestaAlimentariaEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityKey.EncuestaNro);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_DeleteWhereExtendido");
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

        public bool Update(int? EncuestaNro, Guid? UserId, string HistoriaClinica, string Encuestador, DateTime? Fecha, string ApeNom, string Direccion, string Telefono, string Sexo, short? Edad, Decimal? Peso, Decimal? Talla, Decimal? IMC, int? TipoDeDietaId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)Encuestador);
                    if (Fecha.HasValue)
                    {
                        DateTime dateTime = Convert.ToDateTime((object)Fecha);
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.DateTime, (object)null);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)Telefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)TipoDeDietaId);
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

        public bool Update(EncuestaAlimentariaEntityKey EntityKey, EncuestaAlimentariaEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityKey.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityUpdate.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityUpdate.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)EntityUpdate.Encuestador);
                    if (EntityUpdate.Fecha.HasValue)
                    {
                        DateTime dateTime = Convert.ToDateTime((object)EntityUpdate.Fecha);
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.DateTime, (object)null);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)EntityUpdate.ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)EntityUpdate.Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)EntityUpdate.Telefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)EntityUpdate.Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)EntityUpdate.Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)EntityUpdate.Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)EntityUpdate.Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)EntityUpdate.IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityUpdate.TipoDeDietaId);
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

        public bool UpdateWhereExtendido(string WhereEx, EncuestaAlimentariaEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "UserId", DbType.Guid, (object)EntityUpdate.UserId);
                    this.DataBase.AddInParameter(storedProcCommand, "HistoriaClinica", DbType.AnsiString, (object)EntityUpdate.HistoriaClinica);
                    this.DataBase.AddInParameter(storedProcCommand, "Encuestador", DbType.AnsiString, (object)EntityUpdate.Encuestador);
                    if (EntityUpdate.Fecha.HasValue)
                    {
                        DateTime dateTime = Convert.ToDateTime((object)EntityUpdate.Fecha);
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.String, (object)dateTime.ToString("yyyyMMdd' 'HH':'mm':'ss"));
                    }
                    else
                        this.DataBase.AddInParameter(storedProcCommand, "Fecha", DbType.DateTime, (object)null);
                    this.DataBase.AddInParameter(storedProcCommand, "ApeNom", DbType.AnsiString, (object)EntityUpdate.ApeNom);
                    this.DataBase.AddInParameter(storedProcCommand, "Direccion", DbType.AnsiString, (object)EntityUpdate.Direccion);
                    this.DataBase.AddInParameter(storedProcCommand, "Telefono", DbType.AnsiString, (object)EntityUpdate.Telefono);
                    this.DataBase.AddInParameter(storedProcCommand, "Sexo", DbType.AnsiString, (object)EntityUpdate.Sexo);
                    this.DataBase.AddInParameter(storedProcCommand, "Edad", DbType.Int16, (object)EntityUpdate.Edad);
                    this.DataBase.AddInParameter(storedProcCommand, "Peso", DbType.Decimal, (object)EntityUpdate.Peso);
                    this.DataBase.AddInParameter(storedProcCommand, "Talla", DbType.Decimal, (object)EntityUpdate.Talla);
                    this.DataBase.AddInParameter(storedProcCommand, "IMC", DbType.Decimal, (object)EntityUpdate.IMC);
                    this.DataBase.AddInParameter(storedProcCommand, "TipoDeDietaId", DbType.Int32, (object)EntityUpdate.TipoDeDietaId);
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

        public bool UpdateNull(int EncuestaNro, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
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

        public bool UpdateNull(EncuestaAlimentariaEntityKey EntityKey, EncuestaAlimentariaEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityKey.EncuestaNro);
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_Search");
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

        public DataTable Search(EncuestaAlimentariaEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_Search");
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_SearchWithPagination");
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

        public DataTable SearchWithPagination(EncuestaAlimentariaEntityPaged EntityPaged, EncuestaAlimentariaEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_SearchWithPagination");
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_SearchCount");
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

        public DataTable SearchCount(EncuestaAlimentariaEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_SearchCount");
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_SearchCountWithPagination");
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

        public DataTable SearchCountWithPagination(EncuestaAlimentariaEntityPaged EntityPaged, EncuestaAlimentariaEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_SearchCountWithPagination");
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

        public DataTable SearchOne(string OpeEncuestaNro, int EncuestaNro)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
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

        public DataTable SearchOne(EncuestaAlimentariaEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityKey.EncuestaNro);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimentaria_GetAll");
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
