using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class EncuestaAliNutEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeEncuestaNro;
        private int? _EncuestaNro;
        private Operadores_Int _OpeAlimentoId;
        private int? _AlimentoId;
        private Operadores_Int _OpeNutrienteId;
        private int? _NutrienteId;
        private Operadores_Numeric _OpeCantidad;
        private Decimal? _Cantidad;

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

        public Operadores_Int OpeEncuestaNro
        {
            get
            {
                return this._OpeEncuestaNro;
            }
            set
            {
                this._OpeEncuestaNro = value;
            }
        }

        public int? EncuestaNro
        {
            get
            {
                return this._EncuestaNro;
            }
            set
            {
                this._EncuestaNro = value;
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

        public Operadores_Numeric OpeCantidad
        {
            get
            {
                return this._OpeCantidad;
            }
            set
            {
                this._OpeCantidad = value;
            }
        }

        public Decimal? Cantidad
        {
            get
            {
                return this._Cantidad;
            }
            set
            {
                this._Cantidad = value;
            }
        }

        public EncuestaAliNutEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeEncuestaNro = Operadores_Int.Vacio;
            this.EncuestaNro = new int?();
            this.OpeAlimentoId = Operadores_Int.Vacio;
            this.AlimentoId = new int?();
            this.OpeNutrienteId = Operadores_Int.Vacio;
            this.NutrienteId = new int?();
            this.OpeCantidad = Operadores_Numeric.Vacio;
            this.Cantidad = new Decimal?();
        }
    }
}

