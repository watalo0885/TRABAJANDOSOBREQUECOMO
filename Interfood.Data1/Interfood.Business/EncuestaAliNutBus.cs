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
    public class EncuestaAliNutBus
    {
        private string _nameConnection;

        public EncuestaAliNutBus()
        {
            this._nameConnection = string.Empty;
        }

        public EncuestaAliNutBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private EncuestaAliNutData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new EncuestaAliNutData();
                return new EncuestaAliNutData(this._nameConnection);
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

        public EncuestaAliNutEntityInfo.EncuestaAliNutEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            EncuestaAliNutEntityInfo[] pArray = new EncuestaAliNutEntityInfo[dt.Rows.Count];
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
            return new EncuestaAliNutEntityInfo.EncuestaAliNutEntityInfoList(pArray);
        }

        public EncuestaAliNutEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            EncuestaAliNutEntityInfo aliNutEntityInfo = new EncuestaAliNutEntityInfo();
            try
            {
                aliNutEntityInfo.EncuestaNro = (int)dr["EncuestaNro"];
                aliNutEntityInfo.AlimentoId = (int)dr["AlimentoId"];
                aliNutEntityInfo.NutrienteId = (int)dr["NutrienteId"];
                aliNutEntityInfo.Cantidad = Convert.IsDBNull(dr["Cantidad"]) ? new Decimal?() : (Decimal?)dr["Cantidad"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return aliNutEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(int EncuestaNro, int AlimentoId, int NutrienteId, Decimal? Cantidad)
        {
            try
            {
                this.CreateDataAccess().Insert(EncuestaNro, AlimentoId, NutrienteId, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(EncuestaAliNutEntityInsert EntityInsert)
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
        public void InsertFromInfo(EncuestaAliNutEntityInfo EntityInfo)
        {
            try
            {
                EncuestaAliNutEntityInsert EntityInsert = new EncuestaAliNutEntityInsert();
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
        public bool Delete(int EncuestaNro, int AlimentoId, int NutrienteId)
        {
            try
            {
                return this.CreateDataAccess().Delete(EncuestaNro, AlimentoId, NutrienteId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(EncuestaAliNutEntityKey EntityKey)
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
        public bool Update(int EncuestaNro, int AlimentoId, int NutrienteId, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().Update(new int?(EncuestaNro), new int?(AlimentoId), new int?(NutrienteId), Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(EncuestaAliNutEntityKey EntityKey, EncuestaAliNutEntityUpdate EntityUpdate)
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
        public bool UpdateWhereExtendido(string WhereEx, EncuestaAliNutEntityUpdate EntityUpdate)
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
        public bool UpdateFromInfo(EncuestaAliNutEntityKey EntityKey, EncuestaAliNutEntityInfo EntityInfo)
        {
            try
            {
                EncuestaAliNutEntityUpdate EntityUpdate = new EncuestaAliNutEntityUpdate();
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
        public bool UpdateNull(int EncuestaNro, int AlimentoId, int NutrienteId, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(EncuestaNro, AlimentoId, NutrienteId, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(EncuestaAliNutEntityKey EntityKey, EncuestaAliNutEntityUpdateNullFields EntityUpdateNullFields)
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
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(EncuestaAliNutEntityFilter EntityFilter)
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
        public void Search(EncuestaAliNutEntityFilter EntityFilter, out EncuestaAliNutEntityInfo.EncuestaAliNutEntityInfoList listaAGenerar)
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
        public EncuestaAliNutEntityInfo.EncuestaAliNutEntityInfoList Search(EncuestaAliNutEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(EncuestaAliNutEntityPaged EntityPaged, EncuestaAliNutEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(EncuestaAliNutEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNutrienteId, int? NutrienteId, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(EncuestaAliNutEntityPaged EntityPaged, EncuestaAliNutEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeEncuestaNro, int EncuestaNro, string OpeAlimentoId, int AlimentoId, string OpeNutrienteId, int NutrienteId)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNutrienteId, NutrienteId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(EncuestaAliNutEntityKey EntityKey)
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
        public EncuestaAliNutEntityInfo SearchOne(EncuestaAliNutEntityKey EntityKey, bool NoUtilizar)
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
        public void GetAll(string OrdenDeRegistros, out EncuestaAliNutEntityInfo.EncuestaAliNutEntityInfoList listaAGenerar)
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
        public EncuestaAliNutEntityInfo.EncuestaAliNutEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
