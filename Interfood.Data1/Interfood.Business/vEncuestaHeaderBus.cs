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
    public class vEncuestaHeaderBus
    {
        private string _nameConnection;

        public vEncuestaHeaderBus()
        {
            this._nameConnection = string.Empty;
        }

        public vEncuestaHeaderBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private vEncuestaHeaderData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new vEncuestaHeaderData();
                return new vEncuestaHeaderData(this._nameConnection);
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

        public vEncuestaHeaderEntityInfo.vEncuestaHeaderEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            vEncuestaHeaderEntityInfo[] pArray = new vEncuestaHeaderEntityInfo[dt.Rows.Count];
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
            return new vEncuestaHeaderEntityInfo.vEncuestaHeaderEntityInfoList(pArray);
        }

        public vEncuestaHeaderEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            vEncuestaHeaderEntityInfo headerEntityInfo = new vEncuestaHeaderEntityInfo();
            try
            {
                headerEntityInfo.EncuestaNro = (int)dr["EncuestaNro"];
                headerEntityInfo.UserId = (Guid)dr["UserId"];
                headerEntityInfo.Apellido = (string)dr["Apellido"];
                headerEntityInfo.Nombres = (string)dr["Nombres"];
                headerEntityInfo.HistoriaClinica = Convert.IsDBNull(dr["HistoriaClinica"]) ? (string)null : (string)dr["HistoriaClinica"];
                headerEntityInfo.Encuestador = Convert.IsDBNull(dr["Encuestador"]) ? (string)null : (string)dr["Encuestador"];
                headerEntityInfo.Fecha = Convert.IsDBNull(dr["Fecha"]) ? new DateTime?() : (DateTime?)dr["Fecha"];
                headerEntityInfo.ApeNom = Convert.IsDBNull(dr["ApeNom"]) ? (string)null : (string)dr["ApeNom"];
                headerEntityInfo.Direccion = Convert.IsDBNull(dr["Direccion"]) ? (string)null : (string)dr["Direccion"];
                headerEntityInfo.Telefono = Convert.IsDBNull(dr["Telefono"]) ? (string)null : (string)dr["Telefono"];
                headerEntityInfo.Sexo = Convert.IsDBNull(dr["Sexo"]) ? (string)null : (string)dr["Sexo"];
                headerEntityInfo.Edad = Convert.IsDBNull(dr["Edad"]) ? new short?() : (short?)dr["Edad"];
                headerEntityInfo.Peso = Convert.IsDBNull(dr["Peso"]) ? new Decimal?() : (Decimal?)dr["Peso"];
                headerEntityInfo.Talla = Convert.IsDBNull(dr["Talla"]) ? new Decimal?() : (Decimal?)dr["Talla"];
                headerEntityInfo.IMC = Convert.IsDBNull(dr["IMC"]) ? new Decimal?() : (Decimal?)dr["IMC"];
                headerEntityInfo.TipoDeDietaId = Convert.IsDBNull(dr["TipoDeDietaId"]) ? new int?() : (int?)dr["TipoDeDietaId"];
                headerEntityInfo.TipoDeDieta = (string)dr["TipoDeDieta"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return headerEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeHistoriaClinica, HistoriaClinica, OpeEncuestador, Encuestador, OpeFecha, FechaDesde, FechaHasta, OpeApeNom, ApeNom, OpeDireccion, Direccion, OpeTelefono, Telefono, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDietaId, TipoDeDietaId, OpeTipoDeDieta, TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(vEncuestaHeaderEntityFilter EntityFilter)
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
        public void Search(vEncuestaHeaderEntityFilter EntityFilter, out vEncuestaHeaderEntityInfo.vEncuestaHeaderEntityInfoList listaAGenerar)
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
        public vEncuestaHeaderEntityInfo.vEncuestaHeaderEntityInfoList Search(vEncuestaHeaderEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeHistoriaClinica, HistoriaClinica, OpeEncuestador, Encuestador, OpeFecha, FechaDesde, FechaHasta, OpeApeNom, ApeNom, OpeDireccion, Direccion, OpeTelefono, Telefono, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDietaId, TipoDeDietaId, OpeTipoDeDieta, TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(vEncuestaHeaderEntityPaged EntityPaged, vEncuestaHeaderEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeHistoriaClinica, HistoriaClinica, OpeEncuestador, Encuestador, OpeFecha, FechaDesde, FechaHasta, OpeApeNom, ApeNom, OpeDireccion, Direccion, OpeTelefono, Telefono, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDietaId, TipoDeDietaId, OpeTipoDeDieta, TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(vEncuestaHeaderEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeApellido, string Apellido, string OpeNombres, string Nombres, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId, string OpeTipoDeDieta, string TipoDeDieta)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeApellido, Apellido, OpeNombres, Nombres, OpeHistoriaClinica, HistoriaClinica, OpeEncuestador, Encuestador, OpeFecha, FechaDesde, FechaHasta, OpeApeNom, ApeNom, OpeDireccion, Direccion, OpeTelefono, Telefono, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDietaId, TipoDeDietaId, OpeTipoDeDieta, TipoDeDieta);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(vEncuestaHeaderEntityPaged EntityPaged, vEncuestaHeaderEntityFilter EntityFilter)
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
        public void GetAll(string OrdenDeRegistros, out vEncuestaHeaderEntityInfo.vEncuestaHeaderEntityInfoList listaAGenerar)
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
        public vEncuestaHeaderEntityInfo.vEncuestaHeaderEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
