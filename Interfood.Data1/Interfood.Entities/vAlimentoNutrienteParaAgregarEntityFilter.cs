using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class vAlimentoNutrienteParaAgregarEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeAlimentoId;
        private int? _AlimentoId;
        private Operadores_Int _OpeNutrienteId;
        private int? _NutrienteId;
        private Operadores_VarChar _OpeNutrienteNombre;
        private string _NutrienteNombre;
        private Operadores_Int _OpeAlimentoNutrienteCantidad;
        private int? _AlimentoNutrienteCantidad;
        private Operadores_VarChar _OpeNutrienteUDMId;
        private string _NutrienteUDMId;

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

        public Operadores_Int OpeAlimentoNutrienteCantidad
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

        public int? AlimentoNutrienteCantidad
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

        public vAlimentoNutrienteParaAgregarEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeAlimentoId = Operadores_Int.Vacio;
            this.AlimentoId = new int?();
            this.OpeNutrienteId = Operadores_Int.Vacio;
            this.NutrienteId = new int?();
            this.OpeNutrienteNombre = Operadores_VarChar.Vacio;
            this.NutrienteNombre = (string)null;
            this.OpeAlimentoNutrienteCantidad = Operadores_Int.Vacio;
            this.AlimentoNutrienteCantidad = new int?();
            this.OpeNutrienteUDMId = Operadores_VarChar.Vacio;
            this.NutrienteUDMId = (string)null;
        }
    }
}

