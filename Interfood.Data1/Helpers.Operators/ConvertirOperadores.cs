using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.Operators
{
    public static class ConvertirOperadores
    {
        public static string GetEnumFromOperatorValue(string value)
        {
            string str = "";
            if (string.IsNullOrEmpty(value))
                str = "Vacio";
            else if (value == "=")
                str = "Igual";
            else if (value == "<>")
                str = "DistintoDe";
            else if (value == ">")
                str = "Mayor";
            else if (value == ">=")
                str = "MayorIgual";
            else if (value == "<")
                str = "Menor";
            else if (value == "<=")
                str = "MenorIgual";
            else if (value == "%%")
                str = "QueContengaA";
            else if (value == "_%")
                str = "QueComienceCon";
            else if (value == "%_")
                str = "QueTermineCon";
            else if (value == "[]")
                str = "Entre";
            return str;
        }

        public static string ConvertirOperador(Operadores_BigInt ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Char ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Decimal ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Float ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Int ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Money ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_NChar ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_NText ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_NVarChar ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Real ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_SmallDateTime ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_SmallInt ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_SmallMoney ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_TinyInt ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_VarChar ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_DateTime ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Numeric ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_String ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Text ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_UniqueIdentifier ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        public static string ConvertirOperador(Operadores_Bit ope)
        {
            return ConvertirOperadores.ReturnValue(ope.ToString());
        }

        private static string ReturnValue(string ope)
        {
            switch (ope.Trim().ToUpper())
            {
                case "VACIO":
                    return "";
                case "IGUAL":
                    return "=";
                case "MAYOR":
                    return ">";
                case "MAYORIGUAL":
                    return ">=";
                case "MENOR":
                    return "<";
                case "MENORIGUAL":
                    return "<=";
                case "DISTINTODE":
                    return "<>";
                case "ENTRE":
                    return "[]";
                case "QUECOMIENCECON":
                    return "_%";
                case "QUETERMINECON":
                    return "%_";
                case "QUECONTENGAA":
                    return "%%";
                case "NOTNULL":
                    return "IS NOT NULL";
                default:
                    return "";
            }
        }
    }
}
