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
    TipoDeAlimentosBus bus = new TipoDeAlimentosBus();
    TipoDeAlimentosEntityFilter filter = new TipoDeAlimentosEntityFilter();
    TipoDeAlimentosEntityInsert insert = new TipoDeAlimentosEntityInsert();
    TipoDeAlimentosEntityKey key = new TipoDeAlimentosEntityKey();
    TipoDeAlimentosEntityUpdate update = new TipoDeAlimentosEntityUpdate();

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
        //-- Busco el Tipo de Alimento
        //------------------------------------
        filter.OpeTipoDeAlimentoId = Helpers.Operators.Operadores_Int.Igual;
        filter.TipoDeAlimentoId = int.Parse("0" + EntityId.Text);
        DataTable dtTipoDeAlimento = bus.Search(filter);

        if (dtTipoDeAlimento != null && dtTipoDeAlimento.Rows.Count > 0)
        {
            //-- Cargo los controles
            //---------------------------------------------------------
            txtTipoDeAlimento.Text = dtTipoDeAlimento.Rows[0]["TipoDeAlimento"].ToString();
            txtOrdenDeVisualizacion.Text = dtTipoDeAlimento.Rows[0]["OrdenDeVisualizacion"].ToString();
            cboEstado.SelectedValue = dtTipoDeAlimento.Rows[0]["Estado"].ToString();
        }
    }
    #endregion

    #region GrabarTipoDeAlimento
    protected void GrabarTipoDeAlimento(object sender, EventArgs e)
    {
        try
        {
            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    InsertarTipoDeAlimento();
                    break;
                case "UPDATE":
                    UpdateTipoDeAlimento();
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

    #region InsertarTipoDeAlimento
    protected void InsertarTipoDeAlimento()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Inserto 
                //--------------------------------------------------------
                insert.Estado = cboEstado.SelectedValue;
                insert.OrdenDeVisualizacion = int.Parse("0" + txtOrdenDeVisualizacion.Text.Trim());
                insert.TipoDeAlimento = txtTipoDeAlimento.Text;

                bus.Insert_Return_Scalar(insert);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Tipo de Alimento agregado correctamente!</span>";

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region UpdateTipoDeAlimento
    protected void UpdateTipoDeAlimento()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Cargo entidad KEY
                //--------------------------------------------------------
                key.TipoDeAlimentoId = int.Parse(EntityId.Text);

                //-- Cargo entidad UPDATE
                //--------------------------------------------------------
                update.OrdenDeVisualizacion = int.Parse("0" + txtOrdenDeVisualizacion.Text);
                update.TipoDeAlimento = txtTipoDeAlimento.Text;
                update.Estado = cboEstado.SelectedValue;

                //-- GRABO informacion
                //--------------------------------------------------------
                bus.Update(key, update);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Tipo de Alimento modificado correctamente!</span>";

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
        filter.OpeTipoDeAlimento = Helpers.Operators.Operadores_VarChar.Igual;
        filter.TipoDeAlimento = txtTipoDeAlimento.Text.Trim();
        if (Mode.Text.Trim().ToUpper() == "UPDATE")
        {
            filter.OpeTipoDeAlimentoId = Helpers.Operators.Operadores_Int.DistintoDe;
            filter.TipoDeAlimentoId = int.Parse("0" + EntityId.Text.Trim());
        }
        DataTable dtControl = bus.Search(filter);
        if (dtControl != null && dtControl.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    #endregion
}
