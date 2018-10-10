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
    public class EncuestaAlimentoData
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

        public EncuestaAlimentoData()
        {
            this.DataBase = DatabaseFactory.CreateDatabase(InterfoodConfiguration.ConnectionStringNameInput);
        }

        public EncuestaAlimentoData(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        public void ChangeConnection(string NameNewConnection)
        {
            this._database = DatabaseFactory.CreateDatabase(NameNewConnection);
        }

        public void Insert(int EncuestaNro, int AlimentoId, bool? Nunca, int? VecesPorMes, int? VecesPorSemana, int? VecesPorDia, bool? PorcionPequeña, bool? PorcionMediana, bool? PorcionGrande, Decimal? TamañoPorcion, Decimal? Cantidad)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
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

        public void Insert(EncuestaAlimentoEntityInsert EntityInsert)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_Insert");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityInsert.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityInsert.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityInsert.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityInsert.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityInsert.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityInsert.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityInsert.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityInsert.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityInsert.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityInsert.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityInsert.Cantidad);
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

        public bool Delete(int EncuestaNro, int AlimentoId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
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

        public bool Delete(EncuestaAlimentoEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_Delete");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityKey.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_DeleteWhereExtendido");
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

        public bool Update(int? EncuestaNro, int? AlimentoId, bool? Nunca, int? VecesPorMes, int? VecesPorSemana, int? VecesPorDia, bool? PorcionPequeña, bool? PorcionMediana, bool? PorcionGrande, Decimal? TamañoPorcion, Decimal? Cantidad)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
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

        public bool Update(EncuestaAlimentoEntityKey EntityKey, EncuestaAlimentoEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_UpdateOptionalFields");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityKey.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityUpdate.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityUpdate.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityUpdate.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityUpdate.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityUpdate.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityUpdate.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityUpdate.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityUpdate.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityUpdate.Cantidad);
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

        public bool UpdateWhereExtendido(string WhereEx, EncuestaAlimentoEntityUpdate EntityUpdate)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_UpdateWhereExtendido");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereEx);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityUpdate.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityUpdate.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityUpdate.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityUpdate.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityUpdate.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityUpdate.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityUpdate.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityUpdate.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityUpdate.Cantidad);
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

        public bool UpdateNull(int EncuestaNro, int AlimentoId, string ListaDeCampos, string WhereExtendido)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
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

        public bool UpdateNull(EncuestaAlimentoEntityKey EntityKey, EncuestaAlimentoEntityUpdateNullFields EntityUpdateNullFields)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_UpdateNulls");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityKey.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
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

        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)OpeVecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)OpeVecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)OpeVecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)OpePorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)OpePorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)OpePorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)OpeTamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
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

        public DataTable Search(EncuestaAlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorMes));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityFilter.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorSemana));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityFilter.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorDia));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityFilter.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionPequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityFilter.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityFilter.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityFilter.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTamañoPorcion));
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityFilter.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
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

        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)OpeVecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)OpeVecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)OpeVecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)OpePorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)OpePorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)OpePorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)OpeTamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
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

        public DataTable SearchWithPagination(EncuestaAlimentoEntityPaged EntityPaged, EncuestaAlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_SearchWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorMes));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityFilter.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorSemana));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityFilter.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorDia));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityFilter.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionPequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityFilter.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityFilter.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityFilter.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTamañoPorcion));
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityFilter.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
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

        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)OrdenDeRegistros);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)OpeEncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)OpeVecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)OpeVecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)OpeVecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)OpePorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)OpePorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)OpePorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)OpeTamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
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

        public DataTable SearchCount(EncuestaAlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_SearchCount");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "WhereExtendido", DbType.String, (object)EntityFilter.WhereExtendido);
                    this.DataBase.AddInParameter(storedProcCommand, "OrdenDeRegistros", DbType.String, (object)EntityFilter.OrderBy);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeEncuestaNro));
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityFilter.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorMes));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityFilter.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorSemana));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityFilter.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorDia));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityFilter.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionPequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityFilter.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityFilter.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityFilter.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTamañoPorcion));
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityFilter.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
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

        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)OpeAlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)OpeNunca);
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)OpeVecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)OpeVecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)OpeVecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)OpePorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)OpePorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)OpePorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)OpeTamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)OpeCantidad);
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)Cantidad);
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

        public DataTable SearchCountWithPagination(EncuestaAlimentoEntityPaged EntityPaged, EncuestaAlimentoEntityFilter EntityFilter)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_SearchCountWithPagination");
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
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeAlimentoId));
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityFilter.AlimentoId);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeNunca", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeNunca));
                    this.DataBase.AddInParameter(storedProcCommand, "Nunca", DbType.Boolean, (object)EntityFilter.Nunca);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorMes", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorMes));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorMes", DbType.Int32, (object)EntityFilter.VecesPorMes);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorSemana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorSemana));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorSemana", DbType.Int32, (object)EntityFilter.VecesPorSemana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeVecesPorDia", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeVecesPorDia));
                    this.DataBase.AddInParameter(storedProcCommand, "VecesPorDia", DbType.Int32, (object)EntityFilter.VecesPorDia);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionPequeña", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionPequeña));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionPequeña", DbType.Boolean, (object)EntityFilter.PorcionPequeña);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionMediana", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionMediana));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionMediana", DbType.Boolean, (object)EntityFilter.PorcionMediana);
                    this.DataBase.AddInParameter(storedProcCommand, "OpePorcionGrande", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpePorcionGrande));
                    this.DataBase.AddInParameter(storedProcCommand, "PorcionGrande", DbType.Boolean, (object)EntityFilter.PorcionGrande);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeTamañoPorcion", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeTamañoPorcion));
                    this.DataBase.AddInParameter(storedProcCommand, "TamañoPorcion", DbType.Decimal, (object)EntityFilter.TamañoPorcion);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeCantidad", DbType.String, (object)ConvertirOperadores.ConvertirOperador(EntityFilter.OpeCantidad));
                    this.DataBase.AddInParameter(storedProcCommand, "Cantidad", DbType.Decimal, (object)EntityFilter.Cantidad);
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

        public DataTable SearchOne(string OpeEncuestaNro, int EncuestaNro, string OpeAlimentoId, int AlimentoId)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)AlimentoId);
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

        public DataTable SearchOne(EncuestaAlimentoEntityKey EntityKey)
        {
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_Search");
            try
            {
                using (storedProcCommand)
                {
                    this.DataBase.AddInParameter(storedProcCommand, "OpeEncuestaNro", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "EncuestaNro", DbType.Int32, (object)EntityKey.EncuestaNro);
                    this.DataBase.AddInParameter(storedProcCommand, "OpeAlimentoId", DbType.String, (object)"=");
                    this.DataBase.AddInParameter(storedProcCommand, "AlimentoId", DbType.Int32, (object)EntityKey.AlimentoId);
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
            DbCommand storedProcCommand = this.DataBase.GetStoredProcCommand("EncuestaAlimento_GetAll");
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
