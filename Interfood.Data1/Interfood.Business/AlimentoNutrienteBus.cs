using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using Interfood.Data;
using Interfood.Entities;

namespace Interfood.Business
{
    [DataObject]
    public class AlimentoNutrienteBus
    {
        private string _nameConnection;

        public AlimentoNutrienteBus()
        {
            this._nameConnection = string.Empty;
        }

        public AlimentoNutrienteBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private AlimentoNutrienteData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new AlimentoNutrienteData();
                return new AlimentoNutrienteData(this._nameConnection);
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

        public AlimentoNutrienteEntityInfo.AlimentoNutrienteEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            AlimentoNutrienteEntityInfo[] pArray = new AlimentoNutrienteEntityInfo[dt.Rows.Count];
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
            return new AlimentoNutrienteEntityInfo.AlimentoNutrienteEntityInfoList(pArray);
        }

        public AlimentoNutrienteEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            AlimentoNutrienteEntityInfo nutrienteEntityInfo = new AlimentoNutrienteEntityInfo();
            try
            {
                nutrienteEntityInfo.AlimentoId = (int)dr["AlimentoId"];
                nutrienteEntityInfo.NutrienteId = (int)dr["NutrienteId"];
                nutrienteEntityInfo.Cantidad = Convert.IsDBNull(dr["Cantidad"]) ? new Decimal?() : (Decimal?)dr["Cantidad"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return nutrienteEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(int AlimentoId, int NutrienteId, Decimal? Cantidad, string FntID)
        {
            try
            {
                this.CreateDataAccess().Insert(AlimentoId, NutrienteId, Cantidad, FntID);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(AlimentoNutrienteEntityInsert EntityInsert)
        {
            try
            {
                if (!EntityInsert.Validate())
                    throw new Exception(EntityInsert.ErroresQueInvalidanLaEntidad);
                this.CreateDataAccess().Insert(EntityInsert);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void InsertFromInfo(AlimentoNutrienteEntityInfo EntityInfo)
        {
            try
            {
                AlimentoNutrienteEntityInsert EntityInsert = new AlimentoNutrienteEntityInsert();
                EntityInsert.LoadFromInfo(EntityInfo);
                this.Insert(EntityInsert);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(int AlimentoId, int NutrienteId)
        {
            try
            {
                return this.CreateDataAccess().Delete(AlimentoId, NutrienteId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(AlimentoNutrienteEntityKey EntityKey)
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
        public bool Update(int AlimentoId, int NutrienteId, Decimal? Cantidad, string FntID)
        {
            try
            {
                return this.CreateDataAccess().Update(new int?(AlimentoId), new int?(NutrienteId), Cantidad, FntID);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(AlimentoNutrienteEntityKey EntityKey, AlimentoNutrienteEntityUpdate EntityUpdate)
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
        public bool UpdateWhereExtendido(string WhereEx, AlimentoNutrienteEntityUpdate EntityUpdate)
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
        public bool UpdateFromInfo(AlimentoNutrienteEntityKey EntityKey, AlimentoNutrienteEntityInfo EntityInfo)
        {
            try
            {
                AlimentoNutrienteEntityUpdate EntityUpdate = new AlimentoNutrienteEntityUpdate();
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
        public bool UpdateNull(int AlimentoId, int NutrienteId, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(AlimentoId, NutrienteId, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(AlimentoNutrienteEntityKey EntityKey, AlimentoNutrienteEntityUpdateNullFields EntityUpdateNullFields)
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
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad, string OpeFntID, string FntID)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeCantidad, Cantidad, OpeFntID, FntID);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(AlimentoNutrienteEntityFilter EntityFilter)
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
        public void Search(AlimentoNutrienteEntityFilter EntityFilter, out AlimentoNutrienteEntityInfo.AlimentoNutrienteEntityInfoList listaAGenerar)
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
        public AlimentoNutrienteEntityInfo.AlimentoNutrienteEntityInfoList Search(AlimentoNutrienteEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad, string OpeFntID, string FntID)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeCantidad, Cantidad, OpeFntID, FntID);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(AlimentoNutrienteEntityPaged EntityPaged, AlimentoNutrienteEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad, string OpeFntID, string FntID)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeCantidad, Cantidad, OpeFntID, FntID);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(AlimentoNutrienteEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad, string OpeFntID, string FntID)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeCantidad, Cantidad, OpeFntID, FntID);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(AlimentoNutrienteEntityPaged EntityPaged, AlimentoNutrienteEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeAlimentoId, int AlimentoId, string OpeNutrienteId, int NutrienteId)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(AlimentoNutrienteEntityKey EntityKey)
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
        public AlimentoNutrienteEntityInfo SearchOne(AlimentoNutrienteEntityKey EntityKey, bool NoUtilizar)
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
        public void GetAll(string OrdenDeRegistros, out AlimentoNutrienteEntityInfo.AlimentoNutrienteEntityInfoList listaAGenerar)
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
        public AlimentoNutrienteEntityInfo.AlimentoNutrienteEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
