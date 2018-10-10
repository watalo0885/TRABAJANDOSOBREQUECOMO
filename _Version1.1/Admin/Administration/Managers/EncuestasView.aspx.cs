using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Helpers.Logger;
using Chenso.Utilities.Common;
using Interfood.Entities;
using Interfood.Business;
using System.Data;

public partial class Clientes_Encuestas_EncuestasView : System.Web.UI.Page
{
    public int TipoDeAlimentoIdSeleccionado
    {
        get
        {
            if (ViewState["TipoDeAlimentoIdSeleccionado"] == null)
                ViewState["TipoDeAlimentoIdSeleccionado"] = 0;

            return int.Parse("0" + ViewState["TipoDeAlimentoIdSeleccionado"].ToString().Trim());
        }
        set
        {
            ViewState["TipoDeAlimentoIdSeleccionado"] = value;
        }
    }

    Int32 EncuestaNro = 0;

    EncuestaAlimentoBus busEncAli = new EncuestaAlimentoBus();
    EncuestaAlimentoEntityUpdate updateEncAli = new EncuestaAlimentoEntityUpdate();
    EncuestaAlimentoEntityKey keyEncAli = new EncuestaAlimentoEntityKey();
    EncuestaAlimentoEntityUpdateNullFields nullEncAli = new EncuestaAlimentoEntityUpdateNullFields();

    EncuestaAlimentariaBus busEncuesta = new EncuestaAlimentariaBus();
    EncuestaAlimentariaEntityFilter filterEncuesta = new EncuestaAlimentariaEntityFilter();
    EncuestaAlimentariaEntityUpdate updateEncuesta = new EncuestaAlimentariaEntityUpdate();
    EncuestaAlimentariaEntityKey keyEncuesta = new EncuestaAlimentariaEntityKey();

    vEncuestaAlimentoBus busEncuestaAlimento = new vEncuestaAlimentoBus();
    vEncuestaAlimentoEntityFilter filterEncuestaAlimento = new vEncuestaAlimentoEntityFilter();

    TipoDeDietaEntityFilter filterTipoDieta = new TipoDeDietaEntityFilter();
    TipoDeAlimentosEntityFilter filterTipoDeAlimentos = new TipoDeAlimentosEntityFilter();

    vAlimentoNutrienteBus busVAliNut = new vAlimentoNutrienteBus();
    vAlimentoNutrienteEntityFilter filterVAliNut = new vAlimentoNutrienteEntityFilter();

    EncuestaAliNutBus busEncAliNut = new EncuestaAliNutBus();
    EncuestaAliNutEntityFilter filterEncAliNut = new EncuestaAliNutEntityFilter();
    EncuestaAliNutEntityInsert insertEncAliNut = new EncuestaAliNutEntityInsert();
    EncuestaAliNutEntityUpdate updateEncAliNut = new EncuestaAliNutEntityUpdate();
    EncuestaAliNutEntityKey keyEncAliNut = new EncuestaAliNutEntityKey();

    #region Load
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrMensajeHeader.Text = "";
        cnt_general.Visible = false;

        if (Request["EncuestaNro"] == null)
            Response.Redirect("EncuestaList.aspx");
        else
        {
            filterEncuesta.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
            filterEncuesta.EncuestaNro = int.Parse("0" + Request["EncuestaNro"]);
            DataTable dtEncuesta = busEncuesta.Search(filterEncuesta);
            if (dtEncuesta != null && dtEncuesta.Rows.Count > 0)
            {
                cnt_general.Visible = true;
                EncuestaNro = int.Parse("0" + Request["EncuestaNro"]);
                if (!IsPostBack) DataToControls(dtEncuesta.Rows[0]);
                ltrNroEncuesta.Text = EncuestaNro.ToString();
            }
            else
                mensaje.Text = "<span style='color:green;font-size:12px;'>ATENCION: No hemos encontrado el Nro de Encuesta!!!</span>";
        }

        filterTipoDeAlimentos.OrderBy = "OrdenDeVisualizacion";
        filterTipoDieta.OrderBy = "TipoDeDieta";
    }
    #endregion

    #region DataToControls
    private void DataToControls(DataRow dr)
    {
        txtApeNom.Text = dr["ApeNom"].ToString();
        txtDireccion.Text = dr["Direccion"].ToString();
        txtEdad.Text = dr["Edad"].ToString();
        txtEncuestador.Text = dr["Encuestador"].ToString();
        txtIMC.Text = dr["IMC"].ToString();
        txtPeso.Text = dr["Peso"].ToString();
        txtTalla.Text = dr["Talla"].ToString();
        txtTelefono.Text = dr["Telefono"].ToString();
        cboSexo.SelectedValue = dr["Sexo"].ToString();
        cboTipoDeDieta.SelectedValue = "1";
    }
    #endregion

    #region ODS
    protected void odsTipoDeDieta_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = filterTipoDieta;
    }

    protected void odsTipoDeAlimentos_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["EntityFilter"] = filterTipoDeAlimentos;
    }
    #endregion

    #region Selecciono Categoria de Alimentos
    protected void lvEncuesta_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName.Trim().ToUpper().Contains("SELECT"))
        {
            TipoDeAlimentoIdSeleccionado = int.Parse("0" + e.CommandArgument.ToString().Trim());
        }
    }
    #endregion

    #region DataBound Cabecera
    protected void lvEncuesta_DataBound(object sender, EventArgs e)
    {
        FiltrarDetalle();
    }
    #endregion

    #region FiltrarDetalle
    private void FiltrarDetalle()
    {
        //-- Filtro el detalle 
        //----------------------------------------------------------------
        filterEncuestaAlimento.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
        filterEncuestaAlimento.EncuestaNro = EncuestaNro;
        filterEncuestaAlimento.OpeTipoDeAlimentoId = Helpers.Operators.Operadores_Int.Igual;
        filterEncuestaAlimento.TipoDeAlimentoId = TipoDeAlimentoIdSeleccionado;
        filterEncuestaAlimento.OpeEstado = Helpers.Operators.Operadores_VarChar.Igual;
        filterEncuestaAlimento.Estado = "ACT";
        filterEncuestaAlimento.OrderBy = "OrdenDeVisualizacion";
        //-----------------------------------------------------------------
        DataTable dtDetail = busEncuestaAlimento.Search(filterEncuestaAlimento);
        lvDetail.DataSource = dtDetail;
        lvDetail.DataBind();
    }
    #endregion

    #region DataBound
    protected void lvDetail_DataBound(object sender, ListViewItemEventArgs args)
    {
        ListView listView = (ListView)sender;

        if (args.Item.ItemType == ListViewItemType.DataItem && args.Item != null)
        {
            //--------------------------------------------------------------
            //-- Creo el objeto que tiene los datos de la ROW del Listview
            //--------------------------------------------------------------
            ListViewDataItem dataItem = (ListViewDataItem)args.Item;
            DataRowView rowView = (DataRowView)dataItem.DataItem;

        }
    }
    #endregion

    

    protected void btnSaveCabecera_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (IsValid)
        {
            keyEncAli.EncuestaNro = this.EncuestaNro;
            ltrMensajeHeader.Text = "<span style='color:green;font-size:12px;padding:4px 20px;'><b>Encuesta grabada correctamente!!</b></span>";
        }
    }
}
