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
using System.Web.Security;

public partial class GenerarXls : System.Web.UI.Page
{
    StreamWriter w;
    Int32 encuestaNro = 0;
    Int32 listado = 0;

    EncuestaAlimentariaBus busEncuesta = new EncuestaAlimentariaBus();
    EncuestaAlimentariaEntityFilter filterEncuesta = new EncuestaAlimentariaEntityFilter();

    protected void Page_Load(object sender, EventArgs e)
    {
        //-- Se puede exportar 
        //-- 1 - UNA SOLA ENCUENTAS
        //-- 2 - TODAS LAS ENCUESTAS => EncuestaNro = 0
        //------------------------------------------------
        if (Request["EncuestaNro"] == null || Request["Listado"] == null)
        {
            mensaje.Text = "<span style='color:red;font-size:12px;'>ATENCION: No hemos encontrado el Nro de Encuesta!!!</span>";
            return;
        }

        Int32.TryParse(Request["EncuestaNro"].ToString(), out encuestaNro);
        Int32.TryParse(Request["listado"].ToString(), out listado);

        bool isAdministrator = false;
        string[] aRolesUser = Roles.GetRolesForUser(MyUsers.GetLoggedUserName());
        foreach (string role in aRolesUser)
        {
            if (role.ToUpper() == "ADMINISTRADOR")
                isAdministrator = true;
        }

        //-- Si estoy exportando una verifico que el usuario 
        //-- logueado sea el DUEÑO.
        //--------------------------------------------------------
        if (encuestaNro > 0)
        {
            if (isAdministrator == false)
            {
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
            }
        }

        if (listado != 1 && listado != 2 && listado != 3)
        {
            mensaje.Text = "<span style='color:red;font-size:12px;'>ATENCION: Tipo de Reporte no válido. Contáctese con el Administrador!!!</span>";
            return;
        }

        FileStream MyFileStream;
        string nameFileEncuesta = string.Format("Encuesta-{0}.xls", encuestaNro.ToString().Trim());
        string fileName = string.Format("{0}.xls", Guid.NewGuid());

        string applicationPath = Server.MapPath(Request.ApplicationPath);
        if (!applicationPath.EndsWith(@"\"))
            applicationPath = applicationPath.Trim() + @"\";

        string fullNameFile = string.Format("{0}Excels\\{1}", applicationPath, fileName);
        //string fullNameFile = string.Format("{1}Excels\\{1}", applicationPath, fileName);

        if (listado == 1)
        {
            try
            {
                #region Listado 1
                Listado_AlimentosPorEncuestasBus bus = new Listado_AlimentosPorEncuestasBus();
                Listado_AlimentosPorEncuestasEntityFilter filter = new Listado_AlimentosPorEncuestasEntityFilter();
                if (encuestaNro > 0)
                {
                    filter.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
                    filter.EncuestaNro = encuestaNro;
                    
                }
                if (!isAdministrator)
                {
                    filter.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
                    filter.UserId = MyUsers.GetLoggedUserId();
                }
                filter.OrderBy = "EncuestaNro, Nombre";
                filter.OpeCantidad = Helpers.Operators.Operadores_Numeric.Igual;
                filter.Cantidad = 1;
                DataTable dtAlimentos = bus.Search(filter);
                if (dtAlimentos != null && dtAlimentos.Rows.Count > 0)
                {
                    FileStream fs = new FileStream(fullNameFile, FileMode.Create, FileAccess.ReadWrite);
                    w = new StreamWriter(fs);
                    EscribeCabeceraAlimento(dtAlimentos.Rows[0]);

                    int index = 1;
                    foreach (DataRow dr in dtAlimentos.Rows)
                    {
                        if (index == 1) index = 2;
                        else index = 1;
                        EscribeLineaAlimento(dr, index);
                    }
                    EscribePiePagina();
                    w.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                mensaje.Text = string.Format("<div style='padding:10px;background-color:Red;color:white;font-family:Arial;font-size:12px;'><b>{0}</b></div>", ex.Message);
                mensaje.Visible = true;
                if (w != null) w.Close();
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
                if (encuestaNro > 0)
                {
                    filterNutrientes.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
                    filterNutrientes.EncuestaNro = encuestaNro;
                }
                if (!isAdministrator)
                {
                    filterNutrientes.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
                    filterNutrientes.UserId = MyUsers.GetLoggedUserId();
                }
                filterNutrientes.OrderBy = "EncuestaNro, Nombre";
                DataTable dtAlimentos = busNutrientes.Search(filterNutrientes);
                if (dtAlimentos != null && dtAlimentos.Rows.Count > 0)
                {
                    FileStream fs = new FileStream(fullNameFile, FileMode.Create, FileAccess.ReadWrite);
                    w = new StreamWriter(fs);
                    EscribeCabeceraNutriente(dtAlimentos.Rows[0]);

                    int index = 1;
                    foreach (DataRow dr in dtAlimentos.Rows)
                    {
                        if (index == 1) index = 2;
                        else index = 1;
                        EscribeLineaNutriente(dr, index);
                    }
                    EscribePiePagina();
                    w.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                mensaje.Text = string.Format("<div style='padding:10px;background-color:Red;color:white;font-family:Arial;font-size:12px;'><b>{0}</b></div>", ex.Message);
                mensaje.Visible = true;
                if (w != null) w.Close();
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
                if (encuestaNro > 0)
                {
                    filterNutrientesPorAli.OpeEncuestaNro = Helpers.Operators.Operadores_Int.Igual;
                    filterNutrientesPorAli.EncuestaNro = encuestaNro;
                }
                if (!isAdministrator)
                {
                    filterNutrientesPorAli.OpeUserId = Helpers.Operators.Operadores_UniqueIdentifier.Igual;
                    filterNutrientesPorAli.UserId = MyUsers.GetLoggedUserId();
                }
                filterNutrientesPorAli.OrderBy = "EncuestaNro, Alimento, Nutriente";
                DataTable dtAlimentos = busNutrientesPorAli.Search(filterNutrientesPorAli);
                if (dtAlimentos != null && dtAlimentos.Rows.Count > 0)
                {
                    FileStream fs = new FileStream(fullNameFile, FileMode.Create, FileAccess.ReadWrite);
                    w = new StreamWriter(fs);
                    EscribeCabeceraNutrientePorAli(dtAlimentos.Rows[0]);

                    int index = 1;
                    foreach (DataRow dr in dtAlimentos.Rows)
                    {
                        if (index == 1) index = 2;
                        else index = 1;
                        EscribeLineaNutrientePorAli(dr, index);
                    }
                    EscribePiePagina();
                    w.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                mensaje.Text = string.Format("<div style='padding:10px;background-color:Red;color:white;font-family:Arial;font-size:12px;'><b>{0}</b></div>", ex.Message);
                mensaje.Visible = true;
                if (w != null) w.Close();
                Logger.LogExceptionStatic(ex);
            }
        }

        MyFileStream = new FileStream(fullNameFile, FileMode.Open);
        long FileSize = MyFileStream.Length;
        byte[] Buffer = new byte[(int)FileSize];
        MyFileStream.Read(Buffer, 0, (int)MyFileStream.Length);
        MyFileStream.Close();

        Response.Clear();
        Response.Buffer = false;
        Response.AppendHeader("Content-Type", "application/ms-excel");
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", nameFileEncuesta));
        Response.AppendHeader("Content-Transfer-Encoding", "binary");
        Response.BinaryWrite(Buffer);
        Response.End();

        File.Delete(fullNameFile);
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
        html.Append(string.Format("<td {0}'>Veces/Mes</td>", headerClass));
        html.Append(string.Format("<td {0}'>Veces/Semana</td>", headerClass));
        html.Append(string.Format("<td {0}'>Veces/Día</td>", headerClass));
        html.Append(string.Format("<td {0}'>Porción Pequeña</td>", headerClass));
        html.Append(string.Format("<td {0}'>Porción Mediana</td>", headerClass));
        html.Append(string.Format("<td {0}'>Porción Grande</td>", headerClass));
        html.Append(string.Format("<td {0}'>Tamaño Porción</td>", headerClass));
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
        html.Append(string.Format("<td {1}>{0}</td>", dr["VecesPorMes"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["VecesPorSemana"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["VecesPorDia"], valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["PorcionPequeña"].ToString().ToUpper() == "TRUE" ? "Si" : "", valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["PorcionMediana"].ToString().ToUpper() == "TRUE" ? "Si" : "", valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["PorcionGrande"].ToString().ToUpper() == "TRUE" ? "Si" : "", valueClass));
        html.Append(string.Format("<td {1}>{0}</td>", dr["TamañoPorcion"], valueClass));
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
