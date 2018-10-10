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
    TipoDeDietaBus bus = new TipoDeDietaBus();
    TipoDeDietaEntityFilter filter = new TipoDeDietaEntityFilter();
    TipoDeDietaEntityInsert insert = new TipoDeDietaEntityInsert();
    TipoDeDietaEntityKey key = new TipoDeDietaEntityKey();
    TipoDeDietaEntityUpdate update = new TipoDeDietaEntityUpdate();

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
        filter.OpeTipoDeDietaId = Helpers.Operators.Operadores_Int.Igual;
        filter.TipoDeDietaId = int.Parse("0" + EntityId.Text);
        DataTable dtSearch = bus.Search(filter);

        if (dtSearch != null && dtSearch.Rows.Count > 0)
        {
            //-- Cargo los controles
            //---------------------------------------------------------
            txtTipoDeDieta.Text = dtSearch.Rows[0]["TipoDeDieta"].ToString();
        }
    }
    #endregion

    #region GrabarTipoDeDieta
    protected void GrabarTipoDeDieta(object sender, EventArgs e)
    {
        try
        {
            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    InsertarTipoDeDieta();
                    break;
                case "UPDATE":
                    UpdateTipoDeDieta();
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

    #region InsertarTipoDeDieta
    protected void InsertarTipoDeDieta()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {


                //-- Inserto 
                //--------------------------------------------------------
                insert.TipoDeDieta = txtTipoDeDieta.Text;
                bus.Insert_Return_Scalar(insert);
                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Tipo de Dieta agregada correctamente!</span>";
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
    }
    #endregion

    #region UpdateTipoDeDieta
    protected void UpdateTipoDeDieta()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Cargo entidad KEY
                //--------------------------------------------------------
                key.TipoDeDietaId = int.Parse(EntityId.Text);

                //-- Cargo entidad UPDATE
                //--------------------------------------------------------
                update.TipoDeDieta = txtTipoDeDieta.Text;

                //-- GRABO informacion
                //--------------------------------------------------------
                bus.Update(key, update);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Tipo de Dieta modificada correctamente!</span>";

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
        filter.OpeTipoDeDieta = Helpers.Operators.Operadores_VarChar.Igual;
        filter.TipoDeDieta = txtTipoDeDieta.Text.Trim();
        if (Mode.Text.Trim().ToUpper() == "UPDATE")
        {
            filter.OpeTipoDeDietaId = Helpers.Operators.Operadores_Int.DistintoDe;
            filter.TipoDeDietaId = int.Parse("0" + EntityId.Text.Trim());
        }
        DataTable dtControl = bus.Search(filter);
        if (dtControl != null && dtControl.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;
    }
    #endregion
}
