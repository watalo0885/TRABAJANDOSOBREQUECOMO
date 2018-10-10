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

public partial class Clientes_Encuestas_EncuestasAdd : System.Web.UI.Page
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

    AlimentoBus _ComparaEstacional = new AlimentoBus();

public AlimentoBus ComparaEstacional
{
  get { return this._ComparaEstacional; }
  set { this._ComparaEstacional = value; }
}

    public void SiAlimentoEstacional(){
        
    }

    #region Load
    protected void Page_Load(object sender, EventArgs e)
    {
        ltrMensajeHeader.Text = "";
        cnt_general.Visible = false;

        if (Request["EncuestaNro"] == null)
            Response.Redirect("EncuestaList.aspx");
        else
        {
            //-- Verifico que el UserId sea el dueño de la ENCUESTA
            //--------------------------------------------------------
            filterEncuesta.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
            filterEncuesta.UserId = MyUsers.GetLoggedUserId();
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

        ((Literal)lvDetail.FindControl("ltrMensaje")).Visible = false;

        if (args.Item.ItemType == ListViewItemType.DataItem && args.Item != null)
        {
            //--------------------------------------------------------------
            //-- Creo el objeto que tiene los datos de la ROW del Listview
            //--------------------------------------------------------------
            ListViewDataItem dataItem = (ListViewDataItem)args.Item;
            DataRowView rowView = (DataRowView)dataItem.DataItem;

            if (bool.Parse(rowView["Nunca"].ToString()))
            {
                ((TextBox)dataItem.FindControl("txtVM")).Enabled = false;
                ((TextBox)dataItem.FindControl("txtVS")).Enabled = false;
                ((TextBox)dataItem.FindControl("txtVD")).Enabled = false;
            }
            else
            {
                ((TextBox)dataItem.FindControl("txtVM")).Enabled = true;
                ((TextBox)dataItem.FindControl("txtVS")).Enabled = true;
                ((TextBox)dataItem.FindControl("txtVD")).Enabled = true;
            }
        }
    }
    #endregion

    #region Save
    protected void Save(object sender, EventArgs e)
    {
        Page.Validate();

        if (IsValid)
        {
            decimal? cantidadAlimento = 0;
            keyEncAli.EncuestaNro = this.EncuestaNro;

            //----------------------------------------------------
            //-- GRABO EL HEADER
            //----------------------------------------------------
            SaveEncuestaHeader();

            //----------------------------------------------------
            //-- PROCESO DE ACTUALIZACION DE LA DIETA
            //----------------------------------------------------
            foreach (ListViewDataItem di in lvDetail.Items)
            {
                try
                {
                    updateEncAli.Clear();
                    nullEncAli.Clear();

                    keyEncAli.AlimentoId = int.Parse("0" + ((Label)di.FindControl("AlimentoId")).Text.Trim());

                    if (!((CheckBox)di.FindControl("chkNunca")).Checked)
                    {
                        updateEncAli.Nunca = false;
                        updateEncAli.VecesPorMes = int.Parse("0" + ((TextBox)di.FindControl("txtVM")).Text.Trim());
                        updateEncAli.VecesPorSemana = int.Parse("0" + ((TextBox)di.FindControl("txtVS")).Text.Trim());
                        updateEncAli.VecesPorDia = int.Parse("0" + ((TextBox)di.FindControl("txtVD")).Text.Trim());
                        updateEncAli.PorcionPequeña = ((CheckBox)di.FindControl("radioP")).Checked;
                        updateEncAli.PorcionMediana = ((CheckBox)di.FindControl("radioM")).Checked;
                        updateEncAli.PorcionGrande = ((CheckBox)di.FindControl("radioG")).Checked;

                        #region Cargo campo Tamaño Porcion segun corresponda P,M,G
                        if (((CheckBox)di.FindControl("radioP")).Checked)
                            updateEncAli.TamañoPorcion = decimal.Parse("0" + ((Label)di.FindControl("Pequeña")).Text.Trim());
                        if (((CheckBox)di.FindControl("radioM")).Checked)
                            updateEncAli.TamañoPorcion = decimal.Parse("0" + ((Label)di.FindControl("Mediana")).Text.Trim());
                        if (((CheckBox)di.FindControl("radioG")).Checked)
                            updateEncAli.TamañoPorcion = decimal.Parse("0" + ((Label)di.FindControl("Grande")).Text.Trim());
                        #endregion

                        if (updateEncAli.VecesPorMes != null && updateEncAli.VecesPorMes > 0)
                            //-- MES
                        //{
                        //    if ()
                          //  updateEncAli.Cantidad = ((updateEncAli.VecesPorMes * updateEncAli.VecesPorDia) * updateEncAli.TamañoPorcion) / 30;
                    //    }
                    //    else
                    //    {
                          updateEncAli.Cantidad = (((updateEncAli.VecesPorMes * updateEncAli.VecesPorDia) * updateEncAli.TamañoPorcion) / 30)/365 * 90;
                    //    }
                    //}
                        else if (updateEncAli.VecesPorSemana != null && updateEncAli.VecesPorSemana > 0)
                            //-- SEMANA
                        //{
                        //    if()
                         //   updateEncAli.Cantidad = ((updateEncAli.VecesPorSemana * updateEncAli.VecesPorDia) * updateEncAli.TamañoPorcion) / 7;
                        //}
                        //else
                        //{
                          updateEncAli.Cantidad = (((updateEncAli.VecesPorSemana * updateEncAli.VecesPorDia) * updateEncAli.TamañoPorcion) / 7)/365 * 90;
                        //}
                        else if (updateEncAli.VecesPorDia != null && updateEncAli.VecesPorDia > 0)
                            //-- DIA
                            updateEncAli.Cantidad = (updateEncAli.VecesPorDia * updateEncAli.TamañoPorcion);

                        cantidadAlimento = updateEncAli.Cantidad;

                        busEncAli.Update(keyEncAli, updateEncAli);

                        //-- PISO EN NULL LOS CAMPOS NUMERICOS QUE NO CARGO
                        //-----------------------------------------------------------------------
                        if (string.IsNullOrEmpty(((TextBox)di.FindControl("txtVM")).Text) && string.IsNullOrEmpty(((TextBox)di.FindControl("txtVS")).Text))
                            nullEncAli.FieldList = "VecesPorSemana, VecesPorMes";
                        if (!string.IsNullOrEmpty(((TextBox)di.FindControl("txtVM")).Text)) 
                            nullEncAli.FieldList = "VecesPorSemana";
                        else if (!string.IsNullOrEmpty(((TextBox)di.FindControl("txtVS")).Text)) 
                            nullEncAli.FieldList = "VecesPorMes";

                        if (!string.IsNullOrEmpty(nullEncAli.FieldList))
                            busEncAli.UpdateNull(keyEncAli, nullEncAli);


                        #region Actualizo NUTRIENTES
                        //-----------------------------------------------------------------------
                        //-- Actualizo cantidades de los nutrientes
                        //-----------------------------------------------------------------------
                        filterVAliNut.Clear();
                        filterVAliNut.OpeAlimentoId = Helpers.Operators.Operadores_Int.Igual;
                        filterVAliNut.AlimentoId = keyEncAli.AlimentoId;
                        DataTable dtNutrientes = busVAliNut.Search(filterVAliNut);
                        foreach (DataRow dr in dtNutrientes.Rows)
                        {
                            keyEncAliNut.EncuestaNro = EncuestaNro;
                            keyEncAliNut.AlimentoId = keyEncAli.AlimentoId;
                            keyEncAliNut.NutrienteId = int.Parse("0" + dr["NutrienteId"].ToString().Trim());
                            updateEncAliNut.Cantidad = (cantidadAlimento * decimal.Parse("0" + dr["AlimentoNutrienteCantidad"].ToString().Trim())) / 100;
                            busEncAliNut.Update(keyEncAliNut, updateEncAliNut);
                        }
                        dtNutrientes = null;
                        #endregion
                    }
                    else
                    {
                        //--- VACIAR REGISTRO
                        //--------------------------------------------
                        updateEncAli.Nunca = true;
                        updateEncAli.PorcionPequeña = false;
                        updateEncAli.PorcionMediana = false;
                        updateEncAli.PorcionGrande = false;
                        busEncAli.Update(keyEncAli, updateEncAli);

                        nullEncAli.FieldList = "VecesPorMes, VecesPorSemana, VecesPorDia, TamañoPorcion, Cantidad";
                        busEncAli.UpdateNull(keyEncAli, nullEncAli);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogErrorStatic(string.Format("Save - Error: {0}", ex.Message));
                }
            }

            FiltrarDetalle();

            Literal literal = ((Literal)lvDetail.FindControl("ltrMensaje"));
            literal.Visible = true;
            literal.Text = "<br /><br /><span style='color:green;font-size:12px;'><b>Alimentos grabados correctamente!!</b></span>";
        }
    }
    #endregion

    #region SaveEncuestaHeader
    private void SaveEncuestaHeader()
    {
        try
        {
            keyEncuesta.EncuestaNro = this.EncuestaNro;

            updateEncuesta.ApeNom = txtApeNom.Text;
            updateEncuesta.Direccion = txtDireccion.Text;
            updateEncuesta.Edad = short.Parse("0" + txtEdad.Text.Trim());
            updateEncuesta.Encuestador = txtEncuestador.Text;
            updateEncuesta.Fecha = DateTime.Now;
            updateEncuesta.IMC = decimal.Parse("0" + txtIMC.Text.Trim());
            updateEncuesta.Peso = decimal.Parse("0" + txtPeso.Text.Trim());
            updateEncuesta.Sexo = cboSexo.SelectedValue;
            updateEncuesta.Talla = decimal.Parse("0" + txtTalla.Text.Trim());
            updateEncuesta.Telefono = txtTelefono.Text;
            updateEncuesta.TipoDeDietaId = int.Parse("0" + cboTipoDeDieta.SelectedValue.Trim());

            busEncuesta.Update(keyEncuesta, updateEncuesta);
        }
        catch (Exception ex)
        {
            Logger.LogErrorStatic(string.Format("SaveEncuestaHeader - Error: {0}", ex.Message));
        }
    }
    #endregion

    protected void btnSaveCabecera_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (IsValid)
        {

            keyEncAli.EncuestaNro = this.EncuestaNro;

            //----------------------------------------------------
            //-- GRABO EL HEADER
            //----------------------------------------------------
            SaveEncuestaHeader();

            ltrMensajeHeader.Text = "<span style='color:green;font-size:12px;padding:4px 20px;'><b>Encuesta grabada correctamente!!</b></span>";
        }
    }
}
