using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;

namespace Interfood.Entities
{
    [Serializable]
    public class FuenteEntityFilter
    {

        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_VarChar _OpeFntID;
        private string _FntID;
        private Operadores_VarChar _OpeNombre;
        private string _Nombre;


        public string WhereExtendido
        {
            get { return _whereExtendido; }
            set { _whereExtendido = value; }
        }

        public string OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }

        public Operadores_VarChar OpeFntID
        {
            get { return _OpeFntID; }
            set { _OpeFntID = value; }
        }

        public string FntID
        {
            get { return _FntID; }
            set { _FntID = value; }
        }

        public Operadores_VarChar OpeNombre
        {
            get { return _OpeNombre; }
            set { _OpeNombre = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public FuenteEntityFilter()
        {
            this.Clear();
        }

        public void Clear() {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeFntID = Operadores_VarChar.Vacio;
            this.FntID = (string)null;
            this.OpeNombre = Operadores_VarChar.Vacio;
            this.Nombre = (string)null;
        }


    }
}
