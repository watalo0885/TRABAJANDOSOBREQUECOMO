using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class NutrienteEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeNutrienteId;
        private int? _NutrienteId;
        private Operadores_VarChar _OpeNombre;
        private string _Nombre;
        private Operadores_VarChar _OpeUDMId;
        private string _UDMId;
        private Operadores_Int _OpePerteneceA;
        private int? _PerteneceA;
        private Operadores_VarChar _OpeEstado;
        private string _Estado;

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

        public Operadores_Int OpeNutrienteId
        {
            get
            {
                return this._OpeNutrienteId;
            }
            set
            {
                this._OpeNutrienteId = value;
            }
        }

        public int? NutrienteId
        {
            get
            {
                return this._NutrienteId;
            }
            set
            {
                this._NutrienteId = value;
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

        public Operadores_Int OpePerteneceA
        {
            get
            {
                return this._OpePerteneceA;
            }
            set
            {
                this._OpePerteneceA = value;
            }
        }

        public int? PerteneceA
        {
            get
            {
                return this._PerteneceA;
            }
            set
            {
                this._PerteneceA = value;
            }
        }

        public Operadores_VarChar OpeEstado
        {
            get
            {
                return this._OpeEstado;
            }
            set
            {
                this._OpeEstado = value;
            }
        }

        public string Estado
        {
            get
            {
                return this._Estado;
            }
            set
            {
                this._Estado = value;
            }
        }

        public NutrienteEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeNutrienteId = Operadores_Int.Vacio;
            this.NutrienteId = new int?();
            this.OpeNombre = Operadores_VarChar.Vacio;
            this.Nombre = (string)null;
            this.OpeUDMId = Operadores_VarChar.Vacio;
            this.UDMId = (string)null;
            this.OpePerteneceA = Operadores_Int.Vacio;
            this.PerteneceA = new int?();
            this.OpeEstado = Operadores_VarChar.Vacio;
            this.Estado = (string)null;
        }
    }
}
