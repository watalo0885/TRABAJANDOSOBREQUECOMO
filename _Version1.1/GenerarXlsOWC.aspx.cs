using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfood.Business;
using Interfood.Entities;
using Chenso.Utilities.Common;
using System.Data;
using System.IO;
using Helpers.Logger;
using System.Text;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Owc11;

public partial class GenerarXlsOWC : System.Web.UI.Page
{
    StreamWriter w;
    Int32 encuestaNro = 0;
    Int32 listado = 0;
    bool exportAll = false;

    EncuestaAlimentariaBus busEncuesta = new EncuestaAlimentariaBus();
    EncuestaAlimentariaEntityFilter filterEncuesta = new EncuestaAlimentariaEntityFilter();

    protected void Page_Load(object sender, EventArgs e)
    {
        //-- Se puede exportar 
        //-- 1 - UNA SOLA ENCUENTAS
        //-- 2 - TODAS LAS ENCUESTAS
        //---------------------------------------------
        if (Request.QueryString.Count == 0)
        {
            //-- Exporto TODAS
            //------------------------
            exportAll = true;
        }
        else
            if (Request["EncuestaNro"] == null || Request["Listado"] == null)
            {
                //-- Exporto UNA UNICA
                //------------------------
                exportAll = false;
                mensaje.Text = "<span style='color:red;font-size:12px;'>ATENCION: Paso de parámetros incorrectos!!!</span>";
                return;
            }


        //-- Si estoy exportando una verifico que el usuario 
        //-- logueado sea el DUEÑO.
        //--------------------------------------------------------
        if (exportAll == false)
        {
            Int32.TryParse(Request["EncuestaNro"].ToString(), out encuestaNro);
            Int32.TryParse(Request["listado"].ToString(), out listado);

            //-- Verifico que el UserId sea el dueño de la ENCUESTA
            //--------------------------------------------------------
            filterEncuesta.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
            filterEncuesta.UserId = MyUsers.GetLoggedUserId();
            filterEncuesta.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
            filterEncuesta.EncuestaNro = encuestaNro;
            DataTable dtEncuesta = busEncuesta.Search(filterEncuesta);
            if ((dtEncuesta != null && dtEncuesta.Rows.Count == 0) || listado == 0)
            {
                mensaje.Text = "<span style='color:red;font-size:12px;'>ATENCION: No hemos encontrado el Nro de Encuesta!!!</span>";
                return;
            }

            if (listado != 1 && listado != 2 && listado != 3)
            {
                mensaje.Text = "<span style='color:red;font-size:12px;'>ATENCION: Tipo de Reporte no válido. Contáctese con el Administrador!!!</span>";
                return;
            }
        }

        if (listado == 1)
        {
            try
            {
                #region Listado 1
                Listado_AlimentosPorEncuestasBus bus = new Listado_AlimentosPorEncuestasBus();
                Listado_AlimentosPorEncuestasEntityFilter filter = new Listado_AlimentosPorEncuestasEntityFilter();
                filter.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
                filter.EncuestaNro = encuestaNro;
                filter.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
                filter.UserId = MyUsers.GetLoggedUserId();
                filter.OrderBy = "nombre";
                DataTable dtAlimentos = bus.Search(filter);
                if (dtAlimentos != null && dtAlimentos.Rows.Count > 0)
                {
                    ExportToExcel(dtAlimentos, 1);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.LogExceptionStatic(ex);
            }
        }
        else if (listado == 2)
        {
            try
            {
                #region Listado 2
                Listado_NutrientesPorEncuestasBus busNutrientes = new Listado_NutrientesPorEncuestasBus();
                Listado_NutrientesPorEncuestasEntityFilter filterNutrientes = new Listado_NutrientesPorEncuestasEntityFilter();
                filterNutrientes.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
                filterNutrientes.EncuestaNro = encuestaNro;
                filterNutrientes.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
                filterNutrientes.UserId = MyUsers.GetLoggedUserId();
                filterNutrientes.OrderBy = "EncuestaNro, Nombre";
                DataTable dtAlimentos = busNutrientes.Search(filterNutrientes);
                if (dtAlimentos != null && dtAlimentos.Rows.Count > 0)
                {
                    ExportToExcel(dtAlimentos, 2);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.LogExceptionStatic(ex);
            }
        }
        else if (listado == 3)
        {
            try
            {
                #region Listado 3
                Listado_NutrientesPorAlimentosBus busNutrientesPorAli = new Listado_NutrientesPorAlimentosBus();
                Listado_NutrientesPorAlimentosEntityFilter filterNutrientesPorAli = new Listado_NutrientesPorAlimentosEntityFilter();
                filterNutrientesPorAli.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
                filterNutrientesPorAli.EncuestaNro = encuestaNro;
                filterNutrientesPorAli.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
                filterNutrientesPorAli.UserId = MyUsers.GetLoggedUserId();
                filterNutrientesPorAli.OrderBy = "EncuestaNro, Alimento, Nutriente";
                DataTable dtAlimentos = busNutrientesPorAli.Search(filterNutrientesPorAli);
                if (dtAlimentos != null && dtAlimentos.Rows.Count > 0)
                {
                    ExportToExcel(dtAlimentos, 3);
                }
                #endregion
            }
            catch (Exception ex)
            {
                if (w != null) w.Close();
                Logger.LogExceptionStatic(ex);
            }
        }
    }

    private void ExportToExcel(DataTable dt, Int32 listado)
    {
        SpreadsheetClass xlsheet = new SpreadsheetClass();

        Int32 row = 1;

        //-- TITULOS GENERICOS
        //--------------------------------
        xlsheet.ActiveSheet.Cells[row, 1] = "Encuesta Nro";
        xlsheet.ActiveSheet.Cells[row, 2] = "Historia Clínica";
        xlsheet.ActiveSheet.Cells[row, 3] = "Fecha";
        xlsheet.ActiveSheet.Cells[row, 4] = "Sexo";
        xlsheet.ActiveSheet.Cells[row, 5] = "Edad";
        xlsheet.ActiveSheet.Cells[row, 6] = "Peso";
        xlsheet.ActiveSheet.Cells[row, 7] = "Talla";
        xlsheet.ActiveSheet.Cells[row, 8] = "IMC";
        xlsheet.ActiveSheet.Cells[row, 9] = "Dieta Habitual";
        
        switch (listado)
        {
            case 1:
                //------------------------------------------------
                //-- LISTADO 1
                //------------------------------------------------
                xlsheet.ActiveSheet.Cells[row, 10] = "Alimento";
                xlsheet.ActiveSheet.Cells[row, 11] = "Cantidad";

                row++;
                foreach (DataRow dr in dt.Rows)
                {
                    xlsheet.ActiveSheet.Cells[row, 1] = dr["EncuestaNro"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 2] = dr["HistoriaClinica"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 3] = dr["Fecha"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 4] = dr["Sexo"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 5] = dr["Edad"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 6] = dr["Peso"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 7] = dr["Talla"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 8] = dr["IMC"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 9] = dr["TipoDeDieta"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 10] = dr["Nombre"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 11] = dr["Cantidad"].ToString();
                    row++;
                }
                break;
            case 2:
                //------------------------------------------------
                //-- LISTADO 2
                //------------------------------------------------
                xlsheet.ActiveSheet.Cells[row, 10] = "Nutriente";
                xlsheet.ActiveSheet.Cells[row, 11] = "Cantidad";

                row++;
                foreach (DataRow dr in dt.Rows)
                {
                    xlsheet.ActiveSheet.Cells[row, 1] = dr["EncuestaNro"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 2] = dr["HistoriaClinica"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 3] = dr["Fecha"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 4] = dr["Sexo"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 5] = dr["Edad"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 6] = dr["Peso"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 7] = dr["Talla"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 8] = dr["IMC"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 9] = dr["TipoDeDieta"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 10] = dr["Nombre"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 11] = dr["CantidadNutriente"].ToString();
                    row++;
                }
                break;
            case 3:
                //------------------------------------------------
                //-- LISTADO 3
                //------------------------------------------------
                xlsheet.ActiveSheet.Cells[row, 10] = "Alimento";
                xlsheet.ActiveSheet.Cells[row, 11] = "Cantidad";
                xlsheet.ActiveSheet.Cells[row, 12] = "Nutriente";
                xlsheet.ActiveSheet.Cells[row, 13] = "Cantidad";

                row++;
                foreach (DataRow dr in dt.Rows)
                {
                    xlsheet.ActiveSheet.Cells[row, 1] = dr["EncuestaNro"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 2] = dr["HistoriaClinica"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 3] = dr["Fecha"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 4] = dr["Sexo"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 5] = dr["Edad"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 6] = dr["Peso"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 7] = dr["Talla"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 8] = dr["IMC"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 9] = dr["TipoDeDieta"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 10] = dr["Alimento"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 11] = dr["CantidadAlimento"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 12] = dr["Nutriente"].ToString();
                    xlsheet.ActiveSheet.Cells[row, 13] = dr["CantidadNutriente"].ToString();
                    row++;
                }
                break;
            default:
                break;
        }

        string fileName = string.Format("{0}.xls", Guid.NewGuid());
        string fullNameFile = string.Format("{0}\\Excels\\{1}", Server.MapPath(Request.ApplicationPath), fileName);

        // save it off to the filesystem...
        xlsheet.Export(fullNameFile, SheetExportActionEnum.ssExportActionNone, SheetExportFormat.ssExportHTML);

        FileStream MyFileStream = new FileStream(fullNameFile, FileMode.Open);
        long FileSize = MyFileStream.Length;
        byte[] Buffer = new byte[(int)FileSize];
        MyFileStream.Read(Buffer, 0, (int)MyFileStream.Length);
        MyFileStream.Close();

        // set content header so browser knows you'r sending Excel workbook...
        Response.Clear();
        Response.ContentType = "application/x-msexcel";
        Response.Buffer = false;
        //Response.AppendHeader("Content-Type", "application/ms-excel");
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename=Encuesta-{0}", fileName));
        Response.AppendHeader("Content-Transfer-Encoding", "binary");
        Response.BinaryWrite(Buffer);
        Response.End();

        // clean up old files...
        File.Delete(fullNameFile);
    }

    private void ViewInExcel_Click(object sender, System.EventArgs e)
    {
        
    }

    #region EscribeCabeceraAlimento
    public void EscribeCabeceraAlimento(DataRow dr)
    {
        StringBuilder html = new StringBuilder();
        html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
        html.Append("<html>");
        html.Append("  <head>");
        html.Append("<title>Alimentos de Encuesta</title>");
        html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
        html.Append("</head>");
        html.Append("<body>");
        html.Append("<table>");
        //------------------------------------------------------------------------------- HEADER
        string headerClass = "style='background:#E2E2E2;color:#7F7F7F;'";
        html.Append("<tr>"); 
        html.Append(string.Format("<td {0}>Encuesta Nro</td>", headerClass));
        html.Append(string.Format("<td {0}>Historia Clínica</td>", headerClass));
        html.Append(string.Format("<td {0}>Fecha</td>", headerClass));
        html.Append(string.Format("<td {0}>Sexo</td>", headerClass));
        html.Append(string.Format("<td {0}'>Edad</td>", headerClass));
        html.Append(string.Format("<td {0}'>Peso</td>", headerClass));
        html.Append(string.Format("<td {0}'>Talla</td>", headerClass));
        html.Append(string.Format("<td {0}'>IMC</td>", headerClass));
        html.Append(string.Format("<td {0}'>Dieta Habitual</td>", headerClass));
        html.Append(string.Format("<td {0}'>Alimento</td>", headerClass));
        html.Append(string.Format("<td {0}'>Cantidad</td>", headerClass));
        html.Append("</tr>");
        w.Write(html.ToString());
    }
    #endregion

    #region EscribeCabeceraNutriente
    public void EscribeCabeceraNutriente(DataRow dr)
    {
        StringBuilder html = new StringBuilder();
        html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
        html.Append("<html>");
        html.Append("  <head>");
        html.Append("<title>Alimentos de Encuesta</title>");
        html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
        html.Append("</head>");
        html.Append("<body>");
        html.Append("<table>");
        //------------------------------------------------------------------------------- HEADER
        string headerClass = "style='background:#E2E2E2;color:#7F7F7F;'";
        html.Append("<tr>");
        html.Append(string.Format("<td {0}>Encuesta Nro</td>", headerClass));
        html.Append(string.Format("<td {0}>Historia Clínica</td>", headerClass));
        html.Append(string.Format("<td {0}>Fecha</td>", headerClass));
        html.Append(string.Format("<td {0}>Sexo</td>", headerClass));
        html.Append(string.Format("<td {0}'>Edad</td>", headerClass));
        html.Append(string.Format("<td {0}'>Peso</td>", headerClass));
        html.Append(string.Format("<td {0}'>Talla</td>", headerClass));
        html.Append(string.Format("<td {0}'>IMC</td>", headerClass));
        html.Append(string.Format("<td {0}'>Dieta Habitual</td>", headerClass));
        html.Append(string.Format("<td {0}'>Nutriente</td>", headerClass));
        html.Append(string.Format("<td {0}'>Cantidad</td>", headerClass));
        html.Append("</tr>");
        w.Write(html.ToString());
    }
    #endregion

    #region EscribeCabeceraNutrientePorAli
    public void EscribeCabeceraNutrientePorAli(DataRow dr)
    {
        StringBuilder html = new StringBuilder();
        html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
        html.Append("<html>");
        html.Append("  <head>");
        html.Append("<title>Alimentos de Encuesta</title>");
        html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
        html.Append("</head>");
        html.Append("<body>");
        html.Append("<table>");
        //------------------------------------------------------------------------------- HEADER
        string headerClass = "style='background:#E2E2E2;color:#7F7F7F;'";
        html.Append("<tr>");
        html.Append(string.Format("<td {0}>Encuesta Nro</td>", headerClass));
        html.Append(string.Format("<td {0}>Historia Clínica</td>", headerClass));
        html.Append(string.Format("<td {0}>Fecha</td>", headerClass));
        html.Append(string.Format("<td {0}>Sexo</td>", headerClass));
        html.Append(string.Format("<td {0}'>Edad</td>", headerClass));
        html.Append(string.Format("<td {0}'>Peso</td>", headerClass));
        html.Append(string.Format("<td {0}'>Talla</td>", headerClass));
        html.Append(string.Format("<td {0}'>IMC</td>", headerClass));
        html.Append(string.Format("<td {0}'>Dieta Habitual</td>", headerClass));
        html.Append(string.Format("<td {0}'>Alimento</td>", headerClass));
        html.Append(string.Format("<td {0}'>Cantidad</td>", headerClass));
        html.Append(string.Format("<td {0}'>Nutriente</td>", headerClass));
        html.Append(string.Format("<td {0}'>Cantidad</td>", headerClass));
        html.Append("</tr>");
        w.Write(html.ToString());
    }
    #endregion

    #region EscribeLineaAlimento
    public void EscribeLineaAlimento(DataRow dr, int index)
    {
        string bgColor = "", fontColor = "";
        if (index == 1)
        {
            bgColor = " bgcolor=\"#CFE1F4\" ";  //-- celeste
            fontColor = " style=\"font-size: 12px;color: #7A7A7A;\" ";
        }
        else
        {
            bgColor = " bgcolor=\"white\" ";
            fontColor = " style=\"font-size: 12px;color: #7A7A7A;\" ";
        }

        decimal cantidad;
        decimal.TryParse(dr["Cantidad"].ToString(), out cantidad);
        string valueClass = bgColor + fontColor;

        StringBuilder html = new StringBuilder();
        html.Append("<tr>");
        html.Append(string.Format("<td {1}>{0}</td>", dr["EncuestaNro"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["HistoriaClinica"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Fecha"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Sexo"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Edad"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Peso"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Talla"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["IMC"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["TipoDeDieta"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Nombre"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", cantidad, valueClass));
        html.Append("</tr>");
        w.Write(html.ToString());
    }
    #endregion

    #region EscribeLineaNutriente
    public void EscribeLineaNutriente(DataRow dr, int index)
    {
        string bgColor = "", fontColor = "";
        if (index == 1)
        {
            bgColor = " bgcolor=\"#CFE1F4\" ";  //-- celeste
            fontColor = " style=\"font-size: 12px;color: #7A7A7A;\" ";
        }
        else
        {
            bgColor = " bgcolor=\"white\" ";
            fontColor = " style=\"font-size: 12px;color: #7A7A7A;\" ";
        }

        decimal cantidad;
        decimal.TryParse(dr["CantidadNutriente"].ToString(), out cantidad);
        string valueClass = bgColor + fontColor;

        StringBuilder html = new StringBuilder();
        html.Append("<tr>");
        html.Append(string.Format("<td {1}>{0}</td>", dr["EncuestaNro"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["HistoriaClinica"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Fecha"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Sexo"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Edad"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Peso"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Talla"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["IMC"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["TipoDeDieta"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Nombre"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", cantidad, valueClass));
        html.Append("</tr>");
        w.Write(html.ToString());
    }
    #endregion

    #region EscribeLineaNutrientePorAli
    public void EscribeLineaNutrientePorAli(DataRow dr, int index)
    {
        string bgColor = "", fontColor = "";
        if (index == 1)
        {
            bgColor = " bgcolor=\"#CFE1F4\" ";  //-- celeste
            fontColor = " style=\"font-size: 12px;color: #7A7A7A;\" ";
        }
        else
        {
            bgColor = " bgcolor=\"white\" ";
            fontColor = " style=\"font-size: 12px;color: #7A7A7A;\" ";
        }

        decimal cantidadNutriente;
        decimal.TryParse(dr["CantidadNutriente"].ToString(), out cantidadNutriente);

        decimal cantidadAlimento;
        decimal.TryParse(dr["cantidadAlimento"].ToString(), out cantidadAlimento);

        string valueClass = bgColor + fontColor;


        StringBuilder html = new StringBuilder();
        html.Append("<tr>");
        html.Append(string.Format("<td {1}>{0}</td>", dr["EncuestaNro"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["HistoriaClinica"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Fecha"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Sexo"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Edad"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Peso"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Talla"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["IMC"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["TipoDeDieta"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Alimento"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", cantidadAlimento, valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["Nutriente"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", cantidadNutriente, valueClass));
        html.Append("</tr>");
        w.Write(html.ToString());
    }
    #endregion

    #region EscribePiePagina
    public void EscribePiePagina()
    {
        StringBuilder html = new StringBuilder();
        html.Append("</table>");
        html.Append("</body>");
        html.Append("</html>");
        w.Write(html.ToString());
    }
    #endregion
}
