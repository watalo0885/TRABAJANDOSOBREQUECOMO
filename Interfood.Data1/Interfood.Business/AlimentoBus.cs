using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Interfood.Data;
using Interfood.Entities;

namespace Interfood.Business
{
    [DataObject]
    public class AlimentoBus
    {
        private string _nameConnection;

        public AlimentoBus()
        {
            this._nameConnection = string.Empty;
        }

        public AlimentoBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private AlimentoData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new AlimentoData();
                return new AlimentoData(this._nameConnection);
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

        public AlimentoEntityInfo.AlimentoEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            AlimentoEntityInfo[] pArray = new AlimentoEntityInfo[dt.Rows.Count];
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
            return new AlimentoEntityInfo.AlimentoEntityInfoList(pArray);
        }

        public AlimentoEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            AlimentoEntityInfo alimentoEntityInfo = new AlimentoEntityInfo();
            try
            {
                alimentoEntityInfo.AlimentoId = (int)dr["AlimentoId"];
                alimentoEntityInfo.Codigo = (string)dr["Codigo"];
                alimentoEntityInfo.Nombre = (string)dr["Nombre"];
                alimentoEntityInfo.Tipo = Convert.IsDBNull(dr["Tipo"]) ? (string)null : (string)dr["Tipo"];
                alimentoEntityInfo.Estacional = (string)dr["Estacional"];
                alimentoEntityInfo.Pequeña = (Decimal)dr["Pequeña"];
                alimentoEntityInfo.Mediana = (Decimal)dr["Mediana"];
                alimentoEntityInfo.Grande = (Decimal)dr["Grande"];
                alimentoEntityInfo.Estado = (string)dr["Estado"];
                alimentoEntityInfo.TipoDeAlimentoId = Convert.IsDBNull(dr["TipoDeAlimentoId"]) ? new int?() : (int?)dr["TipoDeAlimentoId"];
                alimentoEntityInfo.OrdenDeVisualizacion = Convert.IsDBNull(dr["OrdenDeVisualizacion"]) ? new int?() : (int?)dr["OrdenDeVisualizacion"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return alimentoEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert_Return_Scalar(string Codigo, string Nombre, string Tipo, string Estacional, Decimal Pequeña, Decimal Mediana, Decimal Grande, string Estado, int? TipoDeAlimentoId, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().Insert_Return_Scalar(Codigo, Nombre, Tipo, Estacional, Pequeña, Mediana, Grande, Estado, TipoDeAlimentoId, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert_Return_Scalar(AlimentoEntityInsert EntityInsert)
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
        public int InsertFromInfo(AlimentoEntityInfo EntityInfo)
        {
            try
            {
                AlimentoEntityInsert EntityInsert = new AlimentoEntityInsert();
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
        public bool Delete(int AlimentoId)
        {
            try
            {
                return this.CreateDataAccess().Delete(AlimentoId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(AlimentoEntityKey EntityKey)
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
        public bool Update(int AlimentoId, string Codigo, string Nombre, string Tipo, string Estacional, Decimal Pequeña, Decimal Mediana, Decimal Grande, string Estado, int? TipoDeAlimentoId, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().Update(new int?(AlimentoId), Codigo, Nombre, Tipo, Estacional, new Decimal?(Pequeña), new Decimal?(Mediana), new Decimal?(Grande), Estado, TipoDeAlimentoId, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(AlimentoEntityKey EntityKey, AlimentoEntityUpdate EntityUpdate)
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
        public bool UpdateWhereExtendido(string WhereEx, AlimentoEntityUpdate EntityUpdate)
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
        public bool UpdateFromInfo(AlimentoEntityKey EntityKey, AlimentoEntityInfo EntityInfo)
        {
            try
            {
                AlimentoEntityUpdate EntityUpdate = new AlimentoEntityUpdate();
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
        public bool UpdateNull(int AlimentoId, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(AlimentoId, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(AlimentoEntityKey EntityKey, AlimentoEntityUpdateNullFields EntityUpdateNullFields)
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
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipo, string Tipo, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeTipo, Tipo, OpeEstacional, Estacional, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeEstado, Estado, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeOrdenDeVisualizacion, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(AlimentoEntityFilter EntityFilter)
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
        public void Search(AlimentoEntityFilter EntityFilter, out AlimentoEntityInfo.AlimentoEntityInfoList listaAGenerar)
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
        public AlimentoEntityInfo.AlimentoEntityInfoList Search(AlimentoEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipo, string Tipo, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeTipo, Tipo, OpeEstacional, Estacional, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeEstado, Estado, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeOrdenDeVisualizacion, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(AlimentoEntityPaged EntityPaged, AlimentoEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipo, string Tipo, string OpeEstacional, string Estacional, string OpePequeña, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeTipo, Tipo, OpeEstacional, Estacional, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeEstado, Estado, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeOrdenDeVisualizacion, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(AlimentoEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeCodigo, string Codigo, string OpeNombre, string Nombre, string OpeTipo, string Tipo, string OpePequeña, string OpeEstacional, string Estacional, Decimal? Pequeña, string OpeMediana, Decimal? Mediana, string OpeGrande, Decimal? Grande, string OpeEstado, string Estado, string OpeTipoDeAlimentoId, int? TipoDeAlimentoId, string OpeOrdenDeVisualizacion, int? OrdenDeVisualizacion)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeCodigo, Codigo, OpeNombre, Nombre, OpeTipo, Tipo, OpeEstacional, Estacional, OpePequeña, Pequeña, OpeMediana, Mediana, OpeGrande, Grande, OpeEstado, Estado, OpeTipoDeAlimentoId, TipoDeAlimentoId, OpeOrdenDeVisualizacion, OrdenDeVisualizacion);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(AlimentoEntityPaged EntityPaged, AlimentoEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeAlimentoId, int AlimentoId)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeAlimentoId, AlimentoId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(AlimentoEntityKey EntityKey)
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
        public AlimentoEntityInfo SearchOne(AlimentoEntityKey EntityKey, bool NoUtilizar)
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
        public void GetAll(string OrdenDeRegistros, out AlimentoEntityInfo.AlimentoEntityInfoList listaAGenerar)
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
        public AlimentoEntityInfo.AlimentoEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
