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
    public class EncuestaAlimentoBus
    {
        private string _nameConnection;

        public EncuestaAlimentoBus()
        {
            this._nameConnection = string.Empty;
        }

        public EncuestaAlimentoBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private EncuestaAlimentoData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new EncuestaAlimentoData();
                return new EncuestaAlimentoData(this._nameConnection);
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

        public EncuestaAlimentoEntityInfo.EncuestaAlimentoEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            EncuestaAlimentoEntityInfo[] pArray = new EncuestaAlimentoEntityInfo[dt.Rows.Count];
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
            return new EncuestaAlimentoEntityInfo.EncuestaAlimentoEntityInfoList(pArray);
        }

        public EncuestaAlimentoEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            EncuestaAlimentoEntityInfo alimentoEntityInfo = new EncuestaAlimentoEntityInfo();
            try
            {
                alimentoEntityInfo.EncuestaNro = (int)dr["EncuestaNro"];
                alimentoEntityInfo.AlimentoId = (int)dr["AlimentoId"];
                alimentoEntityInfo.Nunca = Convert.IsDBNull(dr["Nunca"]) ? new bool?() : (bool?)dr["Nunca"];
                alimentoEntityInfo.VecesPorMes = Convert.IsDBNull(dr["VecesPorMes"]) ? new int?() : (int?)dr["VecesPorMes"];
                alimentoEntityInfo.VecesPorSemana = Convert.IsDBNull(dr["VecesPorSemana"]) ? new int?() : (int?)dr["VecesPorSemana"];
                alimentoEntityInfo.VecesPorDia = Convert.IsDBNull(dr["VecesPorDia"]) ? new int?() : (int?)dr["VecesPorDia"];
                alimentoEntityInfo.PorcionPequeña = Convert.IsDBNull(dr["PorcionPequeña"]) ? new bool?() : (bool?)dr["PorcionPequeña"];
                alimentoEntityInfo.PorcionMediana = Convert.IsDBNull(dr["PorcionMediana"]) ? new bool?() : (bool?)dr["PorcionMediana"];
                alimentoEntityInfo.PorcionGrande = Convert.IsDBNull(dr["PorcionGrande"]) ? new bool?() : (bool?)dr["PorcionGrande"];
                alimentoEntityInfo.TamañoPorcion = Convert.IsDBNull(dr["TamañoPorcion"]) ? new Decimal?() : (Decimal?)dr["TamañoPorcion"];
                alimentoEntityInfo.Cantidad = Convert.IsDBNull(dr["Cantidad"]) ? new Decimal?() : (Decimal?)dr["Cantidad"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return alimentoEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(int EncuestaNro, int AlimentoId, bool? Nunca, int? VecesPorMes, int? VecesPorSemana, int? VecesPorDia, bool? PorcionPequeña, bool? PorcionMediana, bool? PorcionGrande, Decimal? TamañoPorcion, Decimal? Cantidad)
        {
            try
            {
                this.CreateDataAccess().Insert(EncuestaNro, AlimentoId, Nunca, VecesPorMes, VecesPorSemana, VecesPorDia, PorcionPequeña, PorcionMediana, PorcionGrande, TamañoPorcion, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Insert(EncuestaAlimentoEntityInsert EntityInsert)
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
        public void InsertFromInfo(EncuestaAlimentoEntityInfo EntityInfo)
        {
            try
            {
                EncuestaAlimentoEntityInsert EntityInsert = new EncuestaAlimentoEntityInsert();
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
        public bool Delete(int EncuestaNro, int AlimentoId)
        {
            try
            {
                return this.CreateDataAccess().Delete(EncuestaNro, AlimentoId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public bool Delete(EncuestaAlimentoEntityKey EntityKey)
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
        public bool Update(int EncuestaNro, int AlimentoId, bool? Nunca, int? VecesPorMes, int? VecesPorSemana, int? VecesPorDia, bool? PorcionPequeña, bool? PorcionMediana, bool? PorcionGrande, Decimal? TamañoPorcion, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().Update(new int?(EncuestaNro), new int?(AlimentoId), Nunca, VecesPorMes, VecesPorSemana, VecesPorDia, PorcionPequeña, PorcionMediana, PorcionGrande, TamañoPorcion, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(EncuestaAlimentoEntityKey EntityKey, EncuestaAlimentoEntityUpdate EntityUpdate)
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
        public bool UpdateWhereExtendido(string WhereEx, EncuestaAlimentoEntityUpdate EntityUpdate)
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
        public bool UpdateFromInfo(EncuestaAlimentoEntityKey EntityKey, EncuestaAlimentoEntityInfo EntityInfo)
        {
            try
            {
                EncuestaAlimentoEntityUpdate EntityUpdate = new EncuestaAlimentoEntityUpdate();
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
        public bool UpdateNull(int EncuestaNro, int AlimentoId, string ListaDeCampos, string WhereExtendido)
        {
            try
            {
                return this.CreateDataAccess().UpdateNull(EncuestaNro, AlimentoId, ListaDeCampos, WhereExtendido);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool UpdateNull(EncuestaAlimentoEntityKey EntityKey, EncuestaAlimentoEntityUpdateNullFields EntityUpdateNullFields)
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
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNunca, Nunca, OpeVecesPorMes, VecesPorMes, OpeVecesPorSemana, VecesPorSemana, OpeVecesPorDia, VecesPorDia, OpePorcionPequeña, PorcionPequeña, OpePorcionMediana, PorcionMediana, OpePorcionGrande, PorcionGrande, OpeTamañoPorcion, TamañoPorcion, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(EncuestaAlimentoEntityFilter EntityFilter)
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
        public void Search(EncuestaAlimentoEntityFilter EntityFilter, out EncuestaAlimentoEntityInfo.EncuestaAlimentoEntityInfoList listaAGenerar)
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
        public EncuestaAlimentoEntityInfo.EncuestaAlimentoEntityInfoList Search(EncuestaAlimentoEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNunca, Nunca, OpeVecesPorMes, VecesPorMes, OpeVecesPorSemana, VecesPorSemana, OpeVecesPorDia, VecesPorDia, OpePorcionPequeña, PorcionPequeña, OpePorcionMediana, PorcionMediana, OpePorcionGrande, PorcionGrande, OpeTamañoPorcion, TamañoPorcion, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(EncuestaAlimentoEntityPaged EntityPaged, EncuestaAlimentoEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNunca, Nunca, OpeVecesPorMes, VecesPorMes, OpeVecesPorSemana, VecesPorSemana, OpeVecesPorDia, VecesPorDia, OpePorcionPequeña, PorcionPequeña, OpePorcionMediana, PorcionMediana, OpePorcionGrande, PorcionGrande, OpeTamañoPorcion, TamañoPorcion, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(EncuestaAlimentoEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeEncuestaNro, int? EncuestaNro, string OpeAlimentoId, int? AlimentoId, string OpeNunca, bool? Nunca, string OpeVecesPorMes, int? VecesPorMes, string OpeVecesPorSemana, int? VecesPorSemana, string OpeVecesPorDia, int? VecesPorDia, string OpePorcionPequeña, bool? PorcionPequeña, string OpePorcionMediana, bool? PorcionMediana, string OpePorcionGrande, bool? PorcionGrande, string OpeTamañoPorcion, Decimal? TamañoPorcion, string OpeCantidad, Decimal? Cantidad)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId, OpeNunca, Nunca, OpeVecesPorMes, VecesPorMes, OpeVecesPorSemana, VecesPorSemana, OpeVecesPorDia, VecesPorDia, OpePorcionPequeña, PorcionPequeña, OpePorcionMediana, PorcionMediana, OpePorcionGrande, PorcionGrande, OpeTamañoPorcion, TamañoPorcion, OpeCantidad, Cantidad);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(EncuestaAlimentoEntityPaged EntityPaged, EncuestaAlimentoEntityFilter EntityFilter)
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
        public DataTable SearchOne(string OpeEncuestaNro, int EncuestaNro, string OpeAlimentoId, int AlimentoId)
        {
            try
            {
                return this.CreateDataAccess().SearchOne(OpeEncuestaNro, EncuestaNro, OpeAlimentoId, AlimentoId);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchOne(EncuestaAlimentoEntityKey EntityKey)
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
        public EncuestaAlimentoEntityInfo SearchOne(EncuestaAlimentoEntityKey EntityKey, bool NoUtilizar)
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
        public void GetAll(string OrdenDeRegistros, out EncuestaAlimentoEntityInfo.EncuestaAlimentoEntityInfoList listaAGenerar)
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
        public EncuestaAlimentoEntityInfo.EncuestaAlimentoEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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
