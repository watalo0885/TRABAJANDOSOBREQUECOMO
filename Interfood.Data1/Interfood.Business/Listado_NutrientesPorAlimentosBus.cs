    using Interfood.Data;
    using Interfood.Entities;
    using System;
    using System.ComponentModel;
    using System.Data;

    namespace Interfood.Business
    {
        [DataObject]
        public class Listado_NutrientesPorAlimentosBus
        {
            private string _nameConnection;

            public Listado_NutrientesPorAlimentosBus()
            {
                this._nameConnection = string.Empty;
            }

            public Listado_NutrientesPorAlimentosBus(string NameConnection)
            {
                this.ChangeConnection(NameConnection);
            }

            private Listado_NutrientesPorAlimentosData CreateDataAccess()
            {
                try
                {
                    if (string.IsNullOrEmpty(this._nameConnection))
                        return new Listado_NutrientesPorAlimentosData();
                    return new Listado_NutrientesPorAlimentosData(this._nameConnection);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            public void ChangeConnection(string NameNewConnection)
            {
                this._nameConnection = NameNewConnection;
            }

            public Listado_NutrientesPorAlimentosEntityInfo.Listado_NutrientesPorAlimentosEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
            {
                Listado_NutrientesPorAlimentosEntityInfo[] pArray = new Listado_NutrientesPorAlimentosEntityInfo[dt.Rows.Count];
                try
                {
                    for (int index = 0; index < dt.Rows.Count; ++index)
                        pArray[index] = this.DataRowToEntityInfo(dt.Rows[index]);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
                return new Listado_NutrientesPorAlimentosEntityInfo.Listado_NutrientesPorAlimentosEntityInfoList(pArray);
            }

            public Listado_NutrientesPorAlimentosEntityInfo DataRowToEntityInfo(DataRow dr)
            {
                Listado_NutrientesPorAlimentosEntityInfo alimentosEntityInfo = new Listado_NutrientesPorAlimentosEntityInfo();
                try
                {
                    alimentosEntityInfo.EncuestaNro = (int)dr["EncuestaNro"];
                    alimentosEntityInfo.HistoriaClinica = Convert.IsDBNull(dr["HistoriaClinica"]) ? (string)null : (string)dr["HistoriaClinica"];
                    alimentosEntityInfo.Fecha = Convert.IsDBNull(dr["Fecha"]) ? new DateTime?() : (DateTime?)dr["Fecha"];
                    alimentosEntityInfo.Sexo = Convert.IsDBNull(dr["Sexo"]) ? (string)null : (string)dr["Sexo"];
                    alimentosEntityInfo.Edad = Convert.IsDBNull(dr["Edad"]) ? new short?() : (short?)dr["Edad"];
                    alimentosEntityInfo.Peso = Convert.IsDBNull(dr["Peso"]) ? new Decimal?() : (Decimal?)dr["Peso"];
                    alimentosEntityInfo.Talla = Convert.IsDBNull(dr["Talla"]) ? new Decimal?() : (Decimal?)dr["Talla"];
                    alimentosEntityInfo.IMC = Convert.IsDBNull(dr["IMC"]) ? new Decimal?() : (Decimal?)dr["IMC"];
                    alimentosEntityInfo.TipoDeDieta = (string)dr["TipoDeDieta"];
                    alimentosEntityInfo.Alimento = (string)dr["Alimento"];
                    alimentosEntityInfo.CantidadAlimento = Convert.IsDBNull(dr["CantidadAlimento"]) ? new Decimal?() : (Decimal?)dr["CantidadAlimento"];
                    alimentosEntityInfo.Nutriente = Convert.IsDBNull(dr["Nutriente"]) ? (string)null : (string)dr["Nutriente"];
                    alimentosEntityInfo.CantidadNutriente = Convert.IsDBNull(dr["CantidadNutriente"]) ? new Decimal?() : (Decimal?)dr["CantidadNutriente"];
                    alimentosEntityInfo.UserId = (Guid)dr["UserId"];
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
                return alimentosEntityInfo;
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeAlimento, string Alimento, string OpeCantidadAlimento, Decimal? CantidadAlimento, string OpeNutriente, string Nutriente, string OpeCantidadNutriente, Decimal? CantidadNutriente, string OpeUserId, Guid? UserId)
            {
                try
                {
                    return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeHistoriaClinica, HistoriaClinica, OpeFecha, FechaDesde, FechaHasta, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDieta, TipoDeDieta, OpeAlimento, Alimento, OpeCantidadAlimento, CantidadAlimento, OpeNutriente, Nutriente, OpeCantidadNutriente, CantidadNutriente, OpeUserId, UserId);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable Search(Listado_NutrientesPorAlimentosEntityFilter EntityFilter)
            {
                try
                {
                    return this.CreateDataAccess().Search(EntityFilter);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public void Search(Listado_NutrientesPorAlimentosEntityFilter EntityFilter, out Listado_NutrientesPorAlimentosEntityInfo.Listado_NutrientesPorAlimentosEntityInfoList listaAGenerar)
            {
                try
                {
                    listaAGenerar = this.DataTableToListOfEntityInfo(this.CreateDataAccess().Search(EntityFilter));
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public Listado_NutrientesPorAlimentosEntityInfo.Listado_NutrientesPorAlimentosEntityInfoList Search(Listado_NutrientesPorAlimentosEntityFilter EntityFilter, bool NoUtilizar)
            {
                try
                {
                    return this.DataTableToListOfEntityInfo(this.CreateDataAccess().Search(EntityFilter));
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeAlimento, string Alimento, string OpeCantidadAlimento, Decimal? CantidadAlimento, string OpeNutriente, string Nutriente, string OpeCantidadNutriente, Decimal? CantidadNutriente, string OpeUserId, Guid? UserId)
            {
                try
                {
                    return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeHistoriaClinica, HistoriaClinica, OpeFecha, FechaDesde, FechaHasta, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDieta, TipoDeDieta, OpeAlimento, Alimento, OpeCantidadAlimento, CantidadAlimento, OpeNutriente, Nutriente, OpeCantidadNutriente, CantidadNutriente, OpeUserId, UserId);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable SearchWithPagination(Listado_NutrientesPorAlimentosEntityPaged EntityPaged, Listado_NutrientesPorAlimentosEntityFilter EntityFilter)
            {
                try
                {
                    return this.CreateDataAccess().SearchWithPagination(EntityPaged, EntityFilter);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeAlimento, string Alimento, string OpeCantidadAlimento, Decimal? CantidadAlimento, string OpeNutriente, string Nutriente, string OpeCantidadNutriente, Decimal? CantidadNutriente, string OpeUserId, Guid? UserId)
            {
                try
                {
                    return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeHistoriaClinica, HistoriaClinica, OpeFecha, FechaDesde, FechaHasta, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDieta, TipoDeDieta, OpeAlimento, Alimento, OpeCantidadAlimento, CantidadAlimento, OpeNutriente, Nutriente, OpeCantidadNutriente, CantidadNutriente, OpeUserId, UserId);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable SearchCount(Listado_NutrientesPorAlimentosEntityFilter EntityFilter)
            {
                try
                {
                    return this.CreateDataAccess().SearchCount(EntityFilter);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeAlimento, string Alimento, string OpeCantidadAlimento, Decimal? CantidadAlimento, string OpeNutriente, string Nutriente, string OpeCantidadNutriente, Decimal? CantidadNutriente, string OpeUserId, Guid? UserId)
            {
                try
                {
                    return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeHistoriaClinica, HistoriaClinica, OpeFecha, FechaDesde, FechaHasta, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDieta, TipoDeDieta, OpeAlimento, Alimento, OpeCantidadAlimento, CantidadAlimento, OpeNutriente, Nutriente, OpeCantidadNutriente, CantidadNutriente, OpeUserId, UserId);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable SearchCountWithPagination(Listado_NutrientesPorAlimentosEntityPaged EntityPaged, Listado_NutrientesPorAlimentosEntityFilter EntityFilter)
            {
                try
                {
                    return this.CreateDataAccess().SearchCountWithPagination(EntityPaged, EntityFilter);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public DataTable GetAll(string OrdenDeRegistros)
            {
                try
                {
                    return this.CreateDataAccess().GetAll(OrdenDeRegistros);
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public void GetAll(string OrdenDeRegistros, out Listado_NutrientesPorAlimentosEntityInfo.Listado_NutrientesPorAlimentosEntityInfoList listaAGenerar)
            {
                try
                {
                    listaAGenerar = this.DataTableToListOfEntityInfo(this.CreateDataAccess().GetAll(OrdenDeRegistros));
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }

            [DataObjectMethod(DataObjectMethodType.Select)]
            public Listado_NutrientesPorAlimentosEntityInfo.Listado_NutrientesPorAlimentosEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
            {
                try
                {
                    return this.DataTableToListOfEntityInfo(this.CreateDataAccess().GetAll(OrdenDeRegistros));
                }
                catch (Exception ex)
                {
                    Helpers.Logger.Logger.LogExceptionStatic(ex);
                    throw ex;
                }
            }
        }
    }
