using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interfood.Data;
using Interfood.Entities;
using System;
using System.ComponentModel;
using System.Data;

namespace Interfood.Business
{
    [DataObject]
    public class Listado_AlimentosPorEncuestasBus
    {
        private string _nameConnection;

        public Listado_AlimentosPorEncuestasBus()
        {
            this._nameConnection = string.Empty;
        }

        public Listado_AlimentosPorEncuestasBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private Listado_AlimentosPorEncuestasData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new Listado_AlimentosPorEncuestasData();
                return new Listado_AlimentosPorEncuestasData(this._nameConnection);
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

        public Listado_AlimentosPorEncuestasEntityInfo.Listado_AlimentosPorEncuestasEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            Listado_AlimentosPorEncuestasEntityInfo[] pArray = new Listado_AlimentosPorEncuestasEntityInfo[dt.Rows.Count];
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
            return new Listado_AlimentosPorEncuestasEntityInfo.Listado_AlimentosPorEncuestasEntityInfoList(pArray);
        }

        public Listado_AlimentosPorEncuestasEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            Listado_AlimentosPorEncuestasEntityInfo encuestasEntityInfo = new Listado_AlimentosPorEncuestasEntityInfo();
            try
            {
                encuestasEntityInfo.EncuestaNro = (int)dr["EncuestaNro"];
                encuestasEntityInfo.UserId = (Guid)dr["UserId"];
                encuestasEntityInfo.Apellido = (string)dr["Apellido"];
                encuestasEntityInfo.Nombres = (string)dr["Nombres"];
                encuestasEntityInfo.Empresa = Convert.IsDBNull(dr["Empresa"]) ? (string)null : (string)dr["Empresa"];
                encuestasEntityInfo.HistoriaClinica = Convert.IsDBNull(dr["HistoriaClinica"]) ? (string)null : (string)dr["HistoriaClinica"];
                encuestasEntityInfo.Fecha = Convert.IsDBNull(dr["Fecha"]) ? new DateTime?() : (DateTime?)dr["Fecha"];
                encuestasEntityInfo.Sexo = Convert.IsDBNull(dr["Sexo"]) ? (string)null : (string)dr["Sexo"];
                encuestasEntityInfo.Edad = Convert.IsDBNull(dr["Edad"]) ? new short?() : (short?)dr["Edad"];
                encuestasEntityInfo.Peso = Convert.IsDBNull(dr["Peso"]) ? new Decimal?() : (Decimal?)dr["Peso"];
                encuestasEntityInfo.Talla = Convert.IsDBNull(dr["Talla"]) ? new Decimal?() : (Decimal?)dr["Talla"];
                encuestasEntityInfo.IMC = Convert.IsDBNull(dr["IMC"]) ? new Decimal?() : (Decimal?)dr["IMC"];
                encuestasEntityInfo.TipoDeDieta = (string)dr["TipoDeDieta"];
                encuestasEntityInfo.Nombre = (string)dr["Nombre"];
                encuestasEntityInfo.Cantidad = Convert.IsDBNull(dr["Cantidad"]) ? new Decimal?() : (Decimal?)dr["Cantidad"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return encuestasEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeNombre, string Nombre, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeHistoriaClinica, HistoriaClinica, OpeFecha, FechaDesde, FechaHasta, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDieta, TipoDeDieta, OpeNombre, Nombre, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(Listado_AlimentosPorEncuestasEntityFilter EntityFilter)
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
        public void Search(Listado_AlimentosPorEncuestasEntityFilter EntityFilter, out Listado_AlimentosPorEncuestasEntityInfo.Listado_AlimentosPorEncuestasEntityInfoList listaAGenerar)
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
        public Listado_AlimentosPorEncuestasEntityInfo.Listado_AlimentosPorEncuestasEntityInfoList Search(Listado_AlimentosPorEncuestasEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeNombre, string Nombre, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeHistoriaClinica, HistoriaClinica, OpeFecha, FechaDesde, FechaHasta, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDieta, TipoDeDieta, OpeNombre, Nombre, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(Listado_AlimentosPorEncuestasEntityPaged EntityPaged, Listado_AlimentosPorEncuestasEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeNombre, string Nombre, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeHistoriaClinica, HistoriaClinica, OpeFecha, FechaDesde, FechaHasta, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDieta, TipoDeDieta, OpeNombre, Nombre, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(Listado_AlimentosPorEncuestasEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeEmpresa, string Empresa, string OpeHistoriaClinica, string HistoriaClinica, string OpeFecha, string FechaDesde, string FechaHasta, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDieta, string TipoDeDieta, string OpeNombre, string Nombre, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeEmpresa, Empresa, OpeHistoriaClinica, HistoriaClinica, OpeFecha, FechaDesde, FechaHasta, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDieta, TipoDeDieta, OpeNombre, Nombre, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(Listado_AlimentosPorEncuestasEntityPaged EntityPaged, Listado_AlimentosPorEncuestasEntityFilter EntityFilter)
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
        public void GetAll(string OrdenDeRegistros, out Listado_AlimentosPorEncuestasEntityInfo.Listado_AlimentosPorEncuestasEntityInfoList listaAGenerar)
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
        public Listado_AlimentosPorEncuestasEntityInfo.Listado_AlimentosPorEncuestasEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
