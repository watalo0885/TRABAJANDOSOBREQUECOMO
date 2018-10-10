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

public partial class EditTipoDeDietaDataRow : System.Web.UI.UserControl
{
    UnidadMedidaBus bus = new UnidadMedidaBus();
    UnidadMedidaEntityFilter filter = new UnidadMedidaEntityFilter();
    UnidadMedidaEntityInsert insert = new UnidadMedidaEntityInsert();
    UnidadMedidaEntityKey key = new UnidadMedidaEntityKey();
    UnidadMedidaEntityUpdate update = new UnidadMedidaEntityUpdate();

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

    #region DataToControls
    private void DataToControls()
    {
        //-- Busco el Tipo de Alimento
        //------------------------------------
        filter.OpeUDMId = Helpers.Operators.Operadores_VarChar.Igual;
        filter.UDMId = EntityId.Text;
        DataTable dtSearch = bus.Search(filter);

        if (dtSearch != null && dtSearch.Rows.Count > 0)
        {
            //-- Cargo los controles
            //---------------------------------------------------------
            txtCodigo.Text = dtSearch.Rows[0]["UDMid"].ToString();
            txtUnidadDeMedida.Text = dtSearch.Rows[0]["Nombre"].ToString();
        }
    }
    #endregion

    #region GrabarUnidadDeMedida
    protected void GrabarUnidadDeMedida(object sender, EventArgs e)
    {
        try
        {
            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    InsertarUnidadDeMedida();
                    break;
                case "UPDATE":
                    UpdateUnidadDeMedida();
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
    protected void InsertarUnidadDeMedida()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Inserto 
                //--------------------------------------------------------
                insert.UDMId = txtCodigo.Text.Trim();
                insert.Nombre = txtUnidadDeMedida.Text;
                bus.Insert(insert);
                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Unidad de medida agregada correctamente!</span>";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region UpdateUnidadDeMedida
    protected void UpdateUnidadDeMedida()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Cargo entidad KEY
                //--------------------------------------------------------
                key.UDMId = EntityId.Text;

                //-- Cargo entidad UPDATE
                //--------------------------------------------------------
                update.Nombre = txtUnidadDeMedida.Text;

                //-- GRABO informacion
                //--------------------------------------------------------
                bus.Update(key, update);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Unidad de Medida modificada correctamente!</span>";

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
        filter.Nombre = txtUnidadDeMedida.Text.Trim();
        if (Mode.Text.Trim().ToUpper() == "UPDATE")
        {
            filter.OpeUDMId = Helpers.Operators.Operadores_VarChar.DistintoDe; 
            filter.UDMId = txtCodigo.Text.Trim();
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
            filter.OpeUDMId = Helpers.Operators.Operadores_VarChar.Igual;
            filter.UDMId = txtCodigo.Text.Trim();
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
