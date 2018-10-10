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
    public class EncuestaAlimentariaBus
    {
        private string _nameConnection;

        public EncuestaAlimentariaBus()
        {
            this._nameConnection = string.Empty;
        }

        public EncuestaAlimentariaBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private EncuestaAlimentariaData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new EncuestaAlimentariaData();
                return new EncuestaAlimentariaData(this._nameConnection);
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

        public EncuestaAlimentariaEntityInfo.EncuestaAlimentariaEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            EncuestaAlimentariaEntityInfo[] pArray = new EncuestaAlimentariaEntityInfo[dt.Rows.Count];
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
            return new EncuestaAlimentariaEntityInfo.EncuestaAlimentariaEntityInfoList(pArray);
        }

        public EncuestaAlimentariaEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            EncuestaAlimentariaEntityInfo alimentariaEntityInfo = new EncuestaAlimentariaEntityInfo();
            try
            {
                alimentariaEntityInfo.EncuestaNro = (int)dr["EncuestaNro"];
                alimentariaEntityInfo.UserId = (Guid)dr["UserId"];
                alimentariaEntityInfo.HistoriaClinica = Convert.IsDBNull(dr["HistoriaClinica"]) ? (string)null : (string)dr["HistoriaClinica"];
                alimentariaEntityInfo.Encuestador = Convert.IsDBNull(dr["Encuestador"]) ? (string)null : (string)dr["Encuestador"];
                alimentariaEntityInfo.Fecha = Convert.IsDBNull(dr["Fecha"]) ? new DateTime?() : (DateTime?)dr["Fecha"];
                alimentariaEntityInfo.ApeNom = Convert.IsDBNull(dr["ApeNom"]) ? (string)null : (string)dr["ApeNom"];
                alimentariaEntityInfo.Direccion = Convert.IsDBNull(dr["Direccion"]) ? (string)null : (string)dr["Direccion"];
                alimentariaEntityInfo.Telefono = Convert.IsDBNull(dr["Telefono"]) ? (string)null : (string)dr["Telefono"];
                alimentariaEntityInfo.Sexo = Convert.IsDBNull(dr["Sexo"]) ? (string)null : (string)dr["Sexo"];
                alimentariaEntityInfo.Edad = Convert.IsDBNull(dr["Edad"]) ? new short?() : (short?)dr["Edad"];
                alimentariaEntityInfo.Peso = Convert.IsDBNull(dr["Peso"]) ? new Decimal?() : (Decimal?)dr["Peso"];
                alimentariaEntityInfo.Talla = Convert.IsDBNull(dr["Talla"]) ? new Decimal?() : (Decimal?)dr["Talla"];
                alimentariaEntityInfo.IMC = Convert.IsDBNull(dr["IMC"]) ? new Decimal?() : (Decimal?)dr["IMC"];
                alimentariaEntityInfo.TipoDeDietaId = Convert.IsDBNull(dr["TipoDeDietaId"]) ? new int?() : (int?)dr["TipoDeDietaId"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return alimentariaEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert_Return_Scalar(Guid UserId, string HistoriaClinica, string Encuestador, DateTime? Fecha, string ApeNom, string Direccion, string Telefono, string Sexo, short? Edad, Decimal? Peso, Decimal? Talla, Decimal? IMC, int? TipoDeDietaId)
        {
            try
            {
                return this.CreateDataAccess().Insert_Return_Scalar(UserId, HistoriaClinica, Encuestador, Fecha, ApeNom, Direccion, Telefono, Sexo, Edad, Peso, Talla, IMC, TipoDeDietaId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert_Return_Scalar(EncuestaAlimentariaEntityInsert EntityInsert)
        {
            try
            {
                if (!EntityInsert.Validate())
                    throw new Exception(EntityInsert.ErroresQueInvalidanLaEntidad);
                return this.CreateDataAccess().Insert_Return_Scalar(EntityInsert);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int InsertFromInfo(EncuestaAlimentariaEntityInfo EntityInfo)
        {
            try
            {
                EncuestaAlimentariaEntityInsert EntityInsert = new EncuestaAlimentariaEntityInsert();
                EntityInsert.LoadFromInfo(EntityInfo);
                return this.Insert_Return_Scalar(EntityInsert);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(int EncuestaNro)
        {
            try
            {
                return this.CreateDataAccess().Delete(EncuestaNro);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(EncuestaAlimentariaEntityKey EntityKey)
        {
            try
            {
                if (!EntityKey.Validate())
                    throw new Exception(EntityKey.ErroresQueInvalidanLaEntidad);
                return this.CreateDataAccess().Delete(EntityKey);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool DeleteWhereExtendido(string WhereEx)
        {
            try
            {
                return this.CreateDataAccess().DeleteWhereExtendido(WhereEx);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int EncuestaNro, Guid UserId, string HistoriaClinica, string Encuestador, DateTime? Fecha, string ApeNom, string Direccion, string Telefono, string Sexo, short? Edad, Decimal? Peso, Decimal? Talla, Decimal? IMC, int? TipoDeDietaId)
        {
            try
            {
                return this.CreateDataAccess().Update(new int?(EncuestaNro), new Guid?(UserId), HistoriaClinica, Encuestador, Fecha, ApeNom, Direccion, Telefono, Sexo, Edad, Peso, Talla, IMC, TipoDeDietaId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(EncuestaAlimentariaEntityKey EntityKey, EncuestaAlimentariaEntityUpdate EntityUpdate)
        {
            try
            {
                if (!EntityKey.Validate())
                    return false;
                return this.CreateDataAccess().Update(EntityKey, EntityUpdate);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateWhereExtendido(string WhereEx, EncuestaAlimentariaEntityUpdate EntityUpdate)
        {
            try
            {
                return this.CreateDataAccess().UpdateWhereExtendido(WhereEx, EntityUpdate);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateFromInfo(EncuestaAlimentariaEntityKey EntityKey, EncuestaAlimentariaEntityInfo EntityInfo)
        {
            try
            {
                EncuestaAlimentariaEntityUpdate EntityUpdate = new EncuestaAlimentariaEntityUpdate();
                EntityUpdate.LoadFromInfo(EntityInfo);
                return this.Update(EntityKey, EntityUpdate);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(int EncuestaNro, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(EncuestaNro, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(EncuestaAlimentariaEntityKey EntityKey, EncuestaAlimentariaEntityUpdateNullFields EntityUpdateNullFields)
        {
            try
            {
                if (!EntityKey.Validate())
                    return false;
                return this.CreateDataAccess().UpdateNull(EntityKey, EntityUpdateNullFields);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeHistoriaClinica, HistoriaClinica, OpeEncuestador, Encuestador, OpeFecha, FechaDesde, FechaHasta, OpeApeNom, ApeNom, OpeDireccion, Direccion, OpeTelefono, Telefono, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDietaId, TipoDeDietaId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(EncuestaAlimentariaEntityFilter EntityFilter)
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
        public void Search(EncuestaAlimentariaEntityFilter EntityFilter, out EncuestaAlimentariaEntityInfo.EncuestaAlimentariaEntityInfoList listaAGenerar)
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
        public EncuestaAlimentariaEntityInfo.EncuestaAlimentariaEntityInfoList Search(EncuestaAlimentariaEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeHistoriaClinica, HistoriaClinica, OpeEncuestador, Encuestador, OpeFecha, FechaDesde, FechaHasta, OpeApeNom, ApeNom, OpeDireccion, Direccion, OpeTelefono, Telefono, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDietaId, TipoDeDietaId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(EncuestaAlimentariaEntityPaged EntityPaged, EncuestaAlimentariaEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeHistoriaClinica, HistoriaClinica, OpeEncuestador, Encuestador, OpeFecha, FechaDesde, FechaHasta, OpeApeNom, ApeNom, OpeDireccion, Direccion, OpeTelefono, Telefono, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDietaId, TipoDeDietaId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(EncuestaAlimentariaEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeUserId, Guid? UserId, string OpeHistoriaClinica, string HistoriaClinica, string OpeEncuestador, string Encuestador, string OpeFecha, string FechaDesde, string FechaHasta, string OpeApeNom, string ApeNom, string OpeDireccion, string Direccion, string OpeTelefono, string Telefono, string OpeSexo, string Sexo, string OpeEdad, short? Edad, string OpePeso, Decimal? Peso, string OpeTalla, Decimal? Talla, string OpeIMC, Decimal? IMC, string OpeTipoDeDietaId, int? TipoDeDietaId)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeUserId, UserId, OpeHistoriaClinica, HistoriaClinica, OpeEncuestador, Encuestador, OpeFecha, FechaDesde, FechaHasta, OpeApeNom, ApeNom, OpeDireccion, Direccion, OpeTelefono, Telefono, OpeSexo, Sexo, OpeEdad, Edad, OpePeso, Peso, OpeTalla, Talla, OpeIMC, IMC, OpeTipoDeDietaId, TipoDeDietaId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(EncuestaAlimentariaEntityPaged EntityPaged, EncuestaAlimentariaEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeEncuestaNro, int EncuestaNro)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeEncuestaNro, EncuestaNro);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(EncuestaAlimentariaEntityKey EntityKey)
        {
            try
            {
                if (!EntityKey.Validate())
                    throw new Exception(EntityKey.ErroresQueInvalidanLaEntidad);
                return this.CreateDataAccess().SearchOne(EntityKey);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public EncuestaAlimentariaEntityInfo SearchOne(EncuestaAlimentariaEntityKey EntityKey, bool NoUtilizar)
        {
            try
            {
                if (!EntityKey.Validate())
                    throw new Exception(EntityKey.ErroresQueInvalidanLaEntidad);
                return this.DataRowToEntityInfo(this.CreateDataAccess().SearchOne(EntityKey).Rows[0]);
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
        public void GetAll(string OrdenDeRegistros, out EncuestaAlimentariaEntityInfo.EncuestaAlimentariaEntityInfoList listaAGenerar)
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
        public EncuestaAlimentariaEntityInfo.EncuestaAlimentariaEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
