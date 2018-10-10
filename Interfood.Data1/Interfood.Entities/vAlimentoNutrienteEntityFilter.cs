using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class vAlimentoNutrienteEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeAlimentoId;
        private int? _AlimentoId;
        private Operadores_VarChar _OpeAlimentoCodigo;
        private string _AlimentoCodigo;
        private Operadores_VarChar _OpeAlimentoNombre;
        private string _AlimentoNombre;
        private Operadores_Int _OpeNutrienteId;
        private int? _NutrienteId;
        private Operadores_VarChar _OpeNutrienteNombre;
        private string _NutrienteNombre;
        private Operadores_Numeric _OpeAlimentoNutrienteCantidad;
        private Decimal? _AlimentoNutrienteCantidad;
        private Operadores_VarChar _OpeNutrienteUDMId;
        private string _NutrienteUDMId;
        private Operadores_Int _OpePerteneceA;
        private int? _PerteneceA;

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

        public Operadores_Int OpeAlimentoId
        {
            get
            {
                return this._OpeAlimentoId;
            }
            set
            {
                this._OpeAlimentoId = value;
            }
        }

        public int? AlimentoId
        {
            get
            {
                return this._AlimentoId;
            }
            set
            {
                this._AlimentoId = value;
            }
        }

        public Operadores_VarChar OpeAlimentoCodigo
        {
            get
            {
                return this._OpeAlimentoCodigo;
            }
            set
            {
                this._OpeAlimentoCodigo = value;
            }
        }

        public string AlimentoCodigo
        {
            get
            {
                return this._AlimentoCodigo;
            }
            set
            {
                this._AlimentoCodigo = value;
            }
        }

        public Operadores_VarChar OpeAlimentoNombre
        {
            get
            {
                return this._OpeAlimentoNombre;
            }
            set
            {
                this._OpeAlimentoNombre = value;
            }
        }

        public string AlimentoNombre
        {
            get
            {
                return this._AlimentoNombre;
            }
            set
            {
                this._AlimentoNombre = value;
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

        public Operadores_VarChar OpeNutrienteNombre
        {
            get
            {
                return this._OpeNutrienteNombre;
            }
            set
            {
                this._OpeNutrienteNombre = value;
            }
        }

        public string NutrienteNombre
        {
            get
            {
                return this._NutrienteNombre;
            }
            set
            {
                this._NutrienteNombre = value;
            }
        }

        public Operadores_Numeric OpeAlimentoNutrienteCantidad
        {
            get
            {
                return this._OpeAlimentoNutrienteCantidad;
            }
            set
            {
                this._OpeAlimentoNutrienteCantidad = value;
            }
        }

        public Decimal? AlimentoNutrienteCantidad
        {
            get
            {
                return this._AlimentoNutrienteCantidad;
            }
            set
            {
                this._AlimentoNutrienteCantidad = value;
            }
        }

        public Operadores_VarChar OpeNutrienteUDMId
        {
            get
            {
                return this._OpeNutrienteUDMId;
            }
            set
            {
                this._OpeNutrienteUDMId = value;
            }
        }

        public string NutrienteUDMId
        {
            get
            {
                return this._NutrienteUDMId;
            }
            set
            {
                this._NutrienteUDMId = value;
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

        public vAlimentoNutrienteEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeAlimentoId = Operadores_Int.Vacio;
            this.AlimentoId = new int?();
            this.OpeAlimentoCodigo = Operadores_VarChar.Vacio;
            this.AlimentoCodigo = (string)null;
            this.OpeAlimentoNombre = Operadores_VarChar.Vacio;
            this.AlimentoNombre = (string)null;
            this.OpeNutrienteId = Operadores_Int.Vacio;
            this.NutrienteId = new int?();
            this.OpeNutrienteNombre = Operadores_VarChar.Vacio;
            this.NutrienteNombre = (string)null;
            this.OpeAlimentoNutrienteCantidad = Operadores_Numeric.Vacio;
            this.AlimentoNutrienteCantidad = new Decimal?();
            this.OpeNutrienteUDMId = Operadores_VarChar.Vacio;
            this.NutrienteUDMId = (string)null;
            this.OpePerteneceA = Operadores_Int.Vacio;
            this.PerteneceA = new int?();
        }
    }
}

