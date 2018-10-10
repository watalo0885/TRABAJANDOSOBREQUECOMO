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
    public class vAlimentosDeEncuestasBus
    {
        private string _nameConnection;

        public vAlimentosDeEncuestasBus()
        {
            this._nameConnection = string.Empty;
        }

        public vAlimentosDeEncuestasBus(string NameConnection)
        {
            this.ChangeConnection(NameConnection);
        }

        private vAlimentosDeEncuestasData CreateDataAccess()
        {
            try
            {
                if (string.IsNullOrEmpty(this._nameConnection))
                    return new vAlimentosDeEncuestasData();
                return new vAlimentosDeEncuestasData(this._nameConnection);
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

        public vAlimentosDeEncuestasEntityInfo.vAlimentosDeEncuestasEntityInfoList DataTableToListOfEntityInfo(DataTable dt)
        {
            vAlimentosDeEncuestasEntityInfo[] pArray = new vAlimentosDeEncuestasEntityInfo[dt.Rows.Count];
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
            return new vAlimentosDeEncuestasEntityInfo.vAlimentosDeEncuestasEntityInfoList(pArray);
        }

        public vAlimentosDeEncuestasEntityInfo DataRowToEntityInfo(DataRow dr)
        {
            vAlimentosDeEncuestasEntityInfo encuestasEntityInfo = new vAlimentosDeEncuestasEntityInfo();
            try
            {
                encuestasEntityInfo.Orden1 = (int)dr["Orden1"];
                encuestasEntityInfo.Orden2 = Convert.IsDBNull(dr["Orden2"]) ? new int?() : (int?)dr["Orden2"];
                encuestasEntityInfo.TipoDeAlimento = (string)dr["TipoDeAlimento"];
                encuestasEntityInfo.AlimentoCodigo = (string)dr["AlimentoCodigo"];
                encuestasEntityInfo.Nombre = (string)dr["Nombre"];
                encuestasEntityInfo.Nunca = (int)dr["Nunca"];
                encuestasEntityInfo.VM = (int)dr["VM"];
                encuestasEntityInfo.VS = (int)dr["VS"];
                encuestasEntityInfo.VD = (int)dr["VD"];
                encuestasEntityInfo.P = (int)dr["P"];
                encuestasEntityInfo.M = (int)dr["M"];
                encuestasEntityInfo.G = (int)dr["G"];
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            return encuestasEntityInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(string WhereExtendido, string OrdenDeRegistros, string OpeOrden1, int? Orden1, string OpeOrden2, int? Orden2, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeNombre, string Nombre, string OpeNunca, int? Nunca, string OpeVM, int? VM, string OpeVS, int? VS, string OpeVD, int? VD, string OpeP, int? P, string OpeM, int? M, string OpeG, int? G)
        {
            try
            {
                return this.CreateDataAccess().Search(WhereExtendido, OrdenDeRegistros, OpeOrden1, Orden1, OpeOrden2, Orden2, OpeTipoDeAlimento, TipoDeAlimento, OpeAlimentoCodigo, AlimentoCodigo, OpeNombre, Nombre, OpeNunca, Nunca, OpeVM, VM, OpeVS, VS, OpeVD, VD, OpeP, P, OpeM, M, OpeG, G);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable Search(vAlimentosDeEncuestasEntityFilter EntityFilter)
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
        public void Search(vAlimentosDeEncuestasEntityFilter EntityFilter, out vAlimentosDeEncuestasEntityInfo.vAlimentosDeEncuestasEntityInfoList listaAGenerar)
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
        public vAlimentosDeEncuestasEntityInfo.vAlimentosDeEncuestasEntityInfoList Search(vAlimentosDeEncuestasEntityFilter EntityFilter, bool NoUtilizar)
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
        public DataTable SearchWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeOrden1, int? Orden1, string OpeOrden2, int? Orden2, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeNombre, string Nombre, string OpeNunca, int? Nunca, string OpeVM, int? VM, string OpeVS, int? VS, string OpeVD, int? VD, string OpeP, int? P, string OpeM, int? M, string OpeG, int? G)
        {
            try
            {
                return this.CreateDataAccess().SearchWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeOrden1, Orden1, OpeOrden2, Orden2, OpeTipoDeAlimento, TipoDeAlimento, OpeAlimentoCodigo, AlimentoCodigo, OpeNombre, Nombre, OpeNunca, Nunca, OpeVM, VM, OpeVS, VS, OpeVD, VD, OpeP, P, OpeM, M, OpeG, G);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchWithPagination(vAlimentosDeEncuestasEntityPaged EntityPaged, vAlimentosDeEncuestasEntityFilter EntityFilter)
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
        public DataTable SearchCount(string WhereExtendido, string OrdenDeRegistros, string OpeOrden1, int? Orden1, string OpeOrden2, int? Orden2, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeNombre, string Nombre, string OpeNunca, int? Nunca, string OpeVM, int? VM, string OpeVS, int? VS, string OpeVD, int? VD, string OpeP, int? P, string OpeM, int? M, string OpeG, int? G)
        {
            try
            {
                return this.CreateDataAccess().SearchCount(WhereExtendido, OrdenDeRegistros, OpeOrden1, Orden1, OpeOrden2, Orden2, OpeTipoDeAlimento, TipoDeAlimento, OpeAlimentoCodigo, AlimentoCodigo, OpeNombre, Nombre, OpeNunca, Nunca, OpeVM, VM, OpeVS, VS, OpeVD, VD, OpeP, P, OpeM, M, OpeG, G);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCount(vAlimentosDeEncuestasEntityFilter EntityFilter)
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
        public DataTable SearchCountWithPagination(int PageSize, int PageReturn, string WhereExtendido, string OrdenDeRegistros, string OpeOrden1, int? Orden1, string OpeOrden2, int? Orden2, string OpeTipoDeAlimento, string TipoDeAlimento, string OpeAlimentoCodigo, string AlimentoCodigo, string OpeNombre, string Nombre, string OpeNunca, int? Nunca, string OpeVM, int? VM, string OpeVS, int? VS, string OpeVD, int? VD, string OpeP, int? P, string OpeM, int? M, string OpeG, int? G)
        {
            try
            {
                return this.CreateDataAccess().SearchCountWithPagination(PageSize, PageReturn, WhereExtendido, OrdenDeRegistros, OpeOrden1, Orden1, OpeOrden2, Orden2, OpeTipoDeAlimento, TipoDeAlimento, OpeAlimentoCodigo, AlimentoCodigo, OpeNombre, Nombre, OpeNunca, Nunca, OpeVM, VM, OpeVS, VS, OpeVD, VD, OpeP, P, OpeM, M, OpeG, G);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public DataTable SearchCountWithPagination(vAlimentosDeEncuestasEntityPaged EntityPaged, vAlimentosDeEncuestasEntityFilter EntityFilter)
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
        public void GetAll(string OrdenDeRegistros, out vAlimentosDeEncuestasEntityInfo.vAlimentosDeEncuestasEntityInfoList listaAGenerar)
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
        public vAlimentosDeEncuestasEntityInfo.vAlimentosDeEncuestasEntityInfoList GetAll(string OrdenDeRegistros, bool NoUtilizar)
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

