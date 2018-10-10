using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class EncuestaAlimentoEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeEncuestaNro;
        private int? _EncuestaNro;
        private Operadores_Int _OpeAlimentoId;
        private int? _AlimentoId;
        private Operadores_Bit _OpeNunca;
        private bool? _Nunca;
        private Operadores_Int _OpeVecesPorMes;
        private int? _VecesPorMes;
        private Operadores_Int _OpeVecesPorSemana;
        private int? _VecesPorSemana;
        private Operadores_Int _OpeVecesPorDia;
        private int? _VecesPorDia;
        private Operadores_Bit _OpePorcionPequeña;
        private bool? _PorcionPequeña;
        private Operadores_Bit _OpePorcionMediana;
        private bool? _PorcionMediana;
        private Operadores_Bit _OpePorcionGrande;
        private bool? _PorcionGrande;
        private Operadores_Numeric _OpeTamañoPorcion;
        private Decimal? _TamañoPorcion;
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

        public Operadores_Bit OpeNunca
        {
            get
            {
                return this._OpeNunca;
            }
            set
            {
                this._OpeNunca = value;
            }
        }

        public bool? Nunca
        {
            get
            {
                return this._Nunca;
            }
            set
            {
                this._Nunca = value;
            }
        }

        public Operadores_Int OpeVecesPorMes
        {
            get
            {
                return this._OpeVecesPorMes;
            }
            set
            {
                this._OpeVecesPorMes = value;
            }
        }

        public int? VecesPorMes
        {
            get
            {
                return this._VecesPorMes;
            }
            set
            {
                this._VecesPorMes = value;
            }
        }

        public Operadores_Int OpeVecesPorSemana
        {
            get
            {
                return this._OpeVecesPorSemana;
            }
            set
            {
                this._OpeVecesPorSemana = value;
            }
        }

        public int? VecesPorSemana
        {
            get
            {
                return this._VecesPorSemana;
            }
            set
            {
                this._VecesPorSemana = value;
            }
        }

        public Operadores_Int OpeVecesPorDia
        {
            get
            {
                return this._OpeVecesPorDia;
            }
            set
            {
                this._OpeVecesPorDia = value;
            }
        }

        public int? VecesPorDia
        {
            get
            {
                return this._VecesPorDia;
            }
            set
            {
                this._VecesPorDia = value;
            }
        }

        public Operadores_Bit OpePorcionPequeña
        {
            get
            {
                return this._OpePorcionPequeña;
            }
            set
            {
                this._OpePorcionPequeña = value;
            }
        }

        public bool? PorcionPequeña
        {
            get
            {
                return this._PorcionPequeña;
            }
            set
            {
                this._PorcionPequeña = value;
            }
        }

        public Operadores_Bit OpePorcionMediana
        {
            get
            {
                return this._OpePorcionMediana;
            }
            set
            {
                this._OpePorcionMediana = value;
            }
        }

        public bool? PorcionMediana
        {
            get
            {
                return this._PorcionMediana;
            }
            set
            {
                this._PorcionMediana = value;
            }
        }

        public Operadores_Bit OpePorcionGrande
        {
            get
            {
                return this._OpePorcionGrande;
            }
            set
            {
                this._OpePorcionGrande = value;
            }
        }

        public bool? PorcionGrande
        {
            get
            {
                return this._PorcionGrande;
            }
            set
            {
                this._PorcionGrande = value;
            }
        }

        public Operadores_Numeric OpeTamañoPorcion
        {
            get
            {
                return this._OpeTamañoPorcion;
            }
            set
            {
                this._OpeTamañoPorcion = value;
            }
        }

        public Decimal? TamañoPorcion
        {
            get
            {
                return this._TamañoPorcion;
            }
            set
            {
                this._TamañoPorcion = value;
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

        public EncuestaAlimentoEntityFilter()
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
            this.OpeNunca = Operadores_Bit.Vacio;
            this.Nunca = new bool?();
            this.OpeVecesPorMes = Operadores_Int.Vacio;
            this.VecesPorMes = new int?();
            this.OpeVecesPorSemana = Operadores_Int.Vacio;
            this.VecesPorSemana = new int?();
            this.OpeVecesPorDia = Operadores_Int.Vacio;
            this.VecesPorDia = new int?();
            this.OpePorcionPequeña = Operadores_Bit.Vacio;
            this.PorcionPequeña = new bool?();
            this.OpePorcionMediana = Operadores_Bit.Vacio;
            this.PorcionMediana = new bool?();
            this.OpePorcionGrande = Operadores_Bit.Vacio;
            this.PorcionGrande = new bool?();
            this.OpeTamañoPorcion = Operadores_Numeric.Vacio;
            this.TamañoPorcion = new Decimal?();
            this.OpeCantidad = Operadores_Numeric.Vacio;
            this.Cantidad = new Decimal?();
        }
    }
}

