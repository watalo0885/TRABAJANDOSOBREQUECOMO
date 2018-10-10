using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class UnidadMedidaEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_VarChar _OpeUDMId;
        private string _UDMId;
        private Operadores_VarChar _OpeNombre;
        private string _Nombre;

        public string WhereExtendido
        {
            get
            {
                return this._whereExtendido;
            }
            set
            {
                this._whereExtendido = value;
            }
        }

        public string OrderBy
        {
            get
            {
                return this._OrderBy;
            }
            set
            {
                this._OrderBy = value;
            }
        }

        public Operadores_VarChar OpeUDMId
        {
            get
            {
                return this._OpeUDMId;
            }
            set
            {
                this._OpeUDMId = value;
            }
        }

        public string UDMId
        {
            get
            {
                return this._UDMId;
            }
            set
            {
                this._UDMId = value;
            }
        }

        public Operadores_VarChar OpeNombre
        {
            get
            {
                return this._OpeNombre;
            }
            set
            {
                this._OpeNombre = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._Nombre;
            }
            set
            {
                this._Nombre = value;
            }
        }

        public UnidadMedidaEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeUDMId = Operadores_VarChar.Vacio;
            this.UDMId = (string)null;
            this.OpeNombre = Operadores_VarChar.Vacio;
            this.Nombre = (string)null;
        }
    }
}

