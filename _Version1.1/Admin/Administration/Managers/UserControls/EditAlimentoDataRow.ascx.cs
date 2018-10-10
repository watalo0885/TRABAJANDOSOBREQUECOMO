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

public partial class Admin_Administration_UserManager_UserControls_EditAlimentoDataRow : System.Web.UI.UserControl
{
    TipoDeAlimentosEntityFilter filterTipoDeAlimento = new TipoDeAlimentosEntityFilter();

    AlimentoBus busAlimento = new AlimentoBus();
    AlimentoEntityFilter filterAlimento = new AlimentoEntityFilter();
    AlimentoEntityInsert insertAlimento = new AlimentoEntityInsert();
    AlimentoEntityKey keyAlimento = new AlimentoEntityKey();
    AlimentoEntityUpdate updateAlimento = new AlimentoEntityUpdate();

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

        filterTipoDeAlimento.OrderBy = "TipoDeAlimento";
    }

    #region DataToControls
    private void DataToControls()
    {
        //-- Busco el ALIMENTO
        //------------------------------------
        filterAlimento.OpeAlimentoId = Helpers.Operators.Operadores_Int.Igual;
        filterAlimento.AlimentoId = int.Parse("0" + EntityId.Text);
        DataTable dtAlimento = busAlimento.Search(filterAlimento);

        if (dtAlimento != null && dtAlimento.Rows.Count > 0)
        {
            //-- Cargo los controles
            //---------------------------------------------------------
            txtCodigo.Text = dtAlimento.Rows[0]["Codigo"].ToString();
            txtGrande.Text = dtAlimento.Rows[0]["Grande"].ToString();
            txtMediana.Text = dtAlimento.Rows[0]["Mediana"].ToString();
            txtNombre.Text = dtAlimento.Rows[0]["Nombre"].ToString();
            txtPequeña.Text = dtAlimento.Rows[0]["Pequeña"].ToString();
            cboTipoDeAlimento.SelectedValue = dtAlimento.Rows[0]["TipoDeAlimentoId"].ToString();
            cboEstacional.SelectedValue = dtAlimento.Rows[0]["Estacional"].ToString();
            cboEstado.SelectedValue = dtAlimento.Rows[0]["Estado"].ToString();
            txtOrdenDeVisualizacion.Text = dtAlimento.Rows[0]["OrdenDeVisualizacion"].ToString();
        }
    }
    #endregion



    protected void ClearWind()
    {
        txtCodigo.Text = "";
        txtGrande.Text = "";
        txtMediana.Text = "";
        txtNombre.Text = "";
        txtPequeña.Text = "";
        cboTipoDeAlimento.SelectedIndex = 0;
        cboEstacional.SelectedIndex = 0;
        cboEstado.SelectedIndex = 0;
        txtOrdenDeVisualizacion.Text = "";
    }

    #region GrabarAlimento
    protected void GrabarAlimento(object sender, EventArgs e)
    {
        try
        {
            switch (Mode.Text.Trim().ToUpper())
            {
                case "INSERT":
                    InsertarAlimento();
                    break;
                case "UPDATE":
                    UpdateAlimento();
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

    #region InsertarAlimento
    protected void InsertarAlimento()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Inserto PROPIEDADES EXTENDIDAS
                //--------------------------------------------------------
                insertAlimento.Codigo = txtCodigo.Text.ToUpper();
                insertAlimento.Estado = cboEstado.SelectedValue;
                insertAlimento.Estacional = cboEstacional.SelectedValue;
                insertAlimento.Grande = decimal.Parse("0" + txtGrande.Text.Trim());
                insertAlimento.Mediana = decimal.Parse("0" + txtMediana.Text.Trim());
                insertAlimento.Nombre = txtNombre.Text;
                insertAlimento.Pequeña = decimal.Parse("0" + txtPequeña.Text.Trim());
                insertAlimento.TipoDeAlimentoId = int.Parse("0" + cboTipoDeAlimento.SelectedValue.Trim());
                insertAlimento.OrdenDeVisualizacion = int.Parse("0" + txtOrdenDeVisualizacion.Text);

                busAlimento.Insert_Return_Scalar(insertAlimento);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Alimento agregado correctamente!</span>";

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
            
        }
        ClearWind();
    }
    #endregion

    #region UpdateAlimento
    protected void UpdateAlimento()
    {
        Page.Validate();

        if (Page.IsValid)
        {
            try
            {
                //-- Cargo entidad KEY
                //--------------------------------------------------------
                keyAlimento.AlimentoId = int.Parse(EntityId.Text);

                //-- Cargo entidad UPDATE
                //--------------------------------------------------------
                updateAlimento.Codigo = txtCodigo.Text.ToUpper();
                updateAlimento.Estado = cboEstado.SelectedValue;
                updateAlimento.Estacional = cboEstacional.SelectedValue;
                updateAlimento.Grande = decimal.Parse("0" + txtGrande.Text.Trim());
                updateAlimento.Mediana = decimal.Parse("0" + txtMediana.Text.Trim());
                updateAlimento.Nombre = txtNombre.Text;
                updateAlimento.Pequeña = decimal.Parse("0" + txtPequeña.Text.Trim());
                updateAlimento.TipoDeAlimentoId = int.Parse("0" + cboTipoDeAlimento.SelectedValue);
                updateAlimento.OrdenDeVisualizacion = int.Parse("0" + txtOrdenDeVisualizacion.Text);

                //-- GRABO PROPIEDADES EXTENDIDAS
                //--------------------------------------------------------
                busAlimento.Update(keyAlimento, updateAlimento);

                ltrMessage.Text = "<span style='color:green;font-size:11px;'>Alimento modificado correctamente!</span>";

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ltrMessage.Visible = true;
        }
      //  lvGeneric.DataBind();
        ClearWind();
            
 
    }
    #endregion

    #region Validaciones personalizadas
    protected void ValidarCodigo(object source, ServerValidateEventArgs args)
    {
        filterAlimento.Clear();
        filterAlimento.OpeCodigo = Helpers.Operators.Operadores_VarChar.Igual;
        filterAlimento.Codigo = txtCodigo.Text.Trim();
        if (Mode.Text.Trim().ToUpper() == "UPDATE")
        {
            filterAlimento.OpeAlimentoId = Helpers.Operators.Operadores_Int.DistintoDe;
            filterAlimento.AlimentoId = int.Parse("0" + EntityId.Text.Trim());
        }
        DataTable dtAlimento = busAlimento.Search(filterAlimento);
        if (dtAlimento != null && dtAlimento.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    protected void ValidarNombre(object source, ServerValidateEventArgs args)
    {
        filterAlimento.Clear();
        filterAlimento.OpeNombre = Helpers.Operators.Operadores_VarChar.Igual;
        filterAlimento.Nombre = txtNombre.Text.Trim();
        if (Mode.Text.Trim().ToUpper() == "UPDATE")
        {
            filterAlimento.OpeAlimentoId = Helpers.Operators.Operadores_Int.DistintoDe;
            filterAlimento.AlimentoId = int.Parse("0" + EntityId.Text.Trim());
        }
        DataTable dtAlimento = busAlimento.Search(filterAlimento);
        if (dtAlimento != null && dtAlimento.Rows.Count > 0)
            args.IsValid = false;
        else
            args.IsValid = true;
    }

    #endregion

    #region ODS
    protected void odsTipoDeAlimentos_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = filterTipoDeAlimento;
    }   
    #endregion
}
