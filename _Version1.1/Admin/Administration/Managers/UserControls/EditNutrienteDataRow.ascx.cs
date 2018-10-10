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

public partial class EditNutrienteDataRow : System.Web.UI.UserControl
{
    NutrienteBus busNutriente = new NutrienteBus();
    NutrienteEntityFilter filterNutriente = new NutrienteEntityFilter();
    NutrienteEntityInsert insertNutriente = new NutrienteEntityInsert();
    NutrienteEntityKey keyNutriente = new NutrienteEntityKey();
    NutrienteEntityUpdate updateNutriente = new NutrienteEntityUpdate();

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
        //-- Busco el Nutriente
        //------------------------------------
        filterNutriente.OpeNutrienteId = Helpers.Operators.Operadores_Int.Igual;
        filterNutriente.NutrienteId = int.Parse("0" + EntityId.Text);
        DataTable dtNutriente = busNutriente.Search(filterNutriente);

        if (dtNutriente != null && dtNutriente.Rows.Count > 0)
        {
            //-- Cargo los controles
            //---------------------------------------------------------
            txtNombre.Text = dtNutriente.Rows[0]["Nombre"].ToString();
            cboUDMid.SelectedValue = dtNutriente.Rows[0]["UDMid"].ToString();
            cboEstado.SelectedValue = dtNutriente.Rows[0]["Estado"].ToString();
        }
    }
    #endregion

    #region GrabarNutriente
    protected void GrabarNutriente(object sender, EventArgs e)
    {
        try
        {
            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    InsertarNutriente();
                    break;
                case "UPDATE":
                    UpdateNutriente();
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

    #region InsertarNutriente
    protected void InsertarNutriente()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Inserto PROPIEDADES EXTENDIDAS
                //--------------------------------------------------------
                insertNutriente.UDMId = cboUDMid.SelectedValue;
                insertNutriente.Estado = cboEstado.SelectedValue;
                insertNutriente.Nombre = txtNombre.Text;

                busNutriente.Insert_Return_Scalar(insertNutriente);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Nutriente agregado correctamente!</span>";

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region UpdateNutriente
    protected void UpdateNutriente()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Cargo entidad KEY
                //--------------------------------------------------------
                keyNutriente.NutrienteId = int.Parse(EntityId.Text);

                //-- Cargo entidad UPDATE
                //--------------------------------------------------------
                updateNutriente.UDMId = cboUDMid.SelectedValue;
                updateNutriente.Estado = cboEstado.SelectedValue;
                updateNutriente.Nombre = txtNombre.Text;

                //-- GRABO PROPIEDADES EXTENDIDAS
                //--------------------------------------------------------
                busNutriente.Update(keyNutriente, updateNutriente);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Nutriente modificado correctamente!</span>";

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
        filterNutriente.Clear();
        filterNutriente.OpeNombre = Helpers.Operators.Operadores_VarChar.Igual;
        filterNutriente.Nombre = txtNombre.Text.Trim();
        if (Mode.Text.Trim().ToUpper() == "UPDATE")
        {
            filterNutriente.OpeNutrienteId = Helpers.Operators.Operadores_Int.DistintoDe;
            filterNutriente.NutrienteId = int.Parse("0" + EntityId.Text.Trim());
        }
        DataTable dtNutriente = busNutriente.Search(filterNutriente);
        if (dtNutriente != null && dtNutriente.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    #endregion
}
