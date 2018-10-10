using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Interfood.Entities;
using Interfood.Business;
using System.Web.Security;
using Helpers.Logger;
using System.Data;


public partial class EditFuentesDataRow : System.Web.UI.UserControl
{
    FuenteBus bus = new FuenteBus();
    FuenteEntityFilter filter = new FuenteEntityFilter();
    FuenteEntityInsert insert = new FuenteEntityInsert();
    FuenteEntityKey key = new FuenteEntityKey();
    FuenteEntityUpdate update = new FuenteEntityUpdate();

    protected void Page_Load(object sender, EventArgs e)
    {
        ltrMessage.Visible = false;

        if (!IsPostBack)
        {
            if (Request["Mode"] != null)
                Mode.Text = Request["Mode"].Trim().ToUpper();

            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    TitleInsert.Visible = true;
                    btnSaveNewRecord.Visible = true;
                    btnCancel.Visible = true;
                    break;
                case "UPDATE":
                    TitleUpdate.Visible = true;
                    btnCancel.Visible = true;
                    btnSaveNewRecord.Visible = true;
                    EntityId.Text = Request["Id"].ToString();
                    DataToControls();
                    txtCodigo.ReadOnly = true;
                    txtCodigo.Style.Add("border", "none");
                    break;

                default:
                    TitleInsert.Visible = true;
                    btnSaveNewRecord.Visible = true;
                    btnCancel.Visible = true;
                    break;
            }
        }
    }

    protected void ClearWind()
    {
 
    }

    #region DataToControls
    private void DataToControls()
    {
        //-- Busco el Tipo de Alimento
        //------------------------------------
        filter.OpeFntID = Helpers.Operators.Operadores_VarChar.Igual;
        filter.FntID = EntityId.Text;
        DataTable dtSearch = bus.Search(filter);

        if (dtSearch != null && dtSearch.Rows.Count > 0)
        {
            //-- Cargo los controles
            //---------------------------------------------------------
            txtCodigo.Text = dtSearch.Rows[0]["FntId"].ToString();
            txtFuente.Text = dtSearch.Rows[0]["Nombre"].ToString();
        }
    }
    #endregion

    #region GrabarFuente
    protected void GrabarFuente(object sender, EventArgs e)
    {
        try
        {
            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    InsertarFuente();
                    break;
                case "UPDATE":
                    UpdateFuente();
                    break;
            }
        }
        catch (Exception ex)
        {
            Logger.LogExceptionStatic(ex);
            ltrMessage.Text = string.Format("<span style='color:red;'>Oooops, ocurrió un error. Descripción: {0}</span>", ex.Message);
            ltrMessage.Visible = true;
        }

    }
    #endregion

    #region InsertarUnidadDeMedida
    protected void InsertarFuente()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Inserto 
                //--------------------------------------------------------
                insert.FntID = txtCodigo.Text.Trim();
                insert.Nombre = txtFuente.Text;
                bus.Insert(insert);
                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Fuente agregada correctamente!</span>";

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region UpdateFuente
    protected void UpdateFuente()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Cargo entidad KEY
                //--------------------------------------------------------
                key.FntID = EntityId.Text;

                //-- Cargo entidad UPDATE
                //--------------------------------------------------------
                update.Nombre = txtFuente.Text;

                //-- GRABO informacion
                //--------------------------------------------------------
                bus.Update(key, update);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Fuente modificada correctamente!</span>";

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region Validaciones personalizadas
    protected void ValidarNombre(object source, ServerValidateEventArgs args)
    {
        filter.Clear();
        filter.OpeNombre = Helpers.Operators.Operadores_VarChar.Igual;
        filter.Nombre = txtFuente.Text.Trim();
        if (Mode.Text.Trim().ToUpper() == "UPDATE")
        {
            filter.OpeFntID = Helpers.Operators.Operadores_VarChar.DistintoDe;
            filter.FntID = txtCodigo.Text.Trim();
        }
        DataTable dtControl = bus.Search(filter);
        if (dtControl != null && dtControl.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    #endregion

    #region Validaciones personalizadas
    protected void ValidarCodigo(object source, ServerValidateEventArgs args)
    {
        if (Mode.Text.Trim().ToUpper() == "INSERT")
        {
            filter.Clear();
            filter.OpeFntID = Helpers.Operators.Operadores_VarChar.Igual;
            filter.FntID = txtCodigo.Text.Trim();
            DataTable dtControl = bus.Search(filter);
            if (dtControl != null && dtControl.Rows.Count > 0)
                args.IsValid = false;
            else
                args.IsValid = true;
        }
        else
            args.IsValid = true;
    }
    #endregion
}