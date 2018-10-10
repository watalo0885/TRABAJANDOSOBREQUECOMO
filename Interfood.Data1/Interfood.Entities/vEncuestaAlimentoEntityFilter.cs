using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class vEncuestaAlimentoEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeEncuestaNro;
        private int? _EncuestaNro;
        private Operadores_Int _OpeAlimentoId;
        private int? _AlimentoId;
        private Operadores_VarChar _OpeCodigo;
        private string _Codigo;
        private Operadores_VarChar _OpeNombre;
        private string _Nombre;
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
        private Operadores_Numeric _OpePequeña;
        private Decimal? _Pequeña;
        private Operadores_Numeric _OpeMediana;
        private Decimal? _Mediana;
        private Operadores_Numeric _OpeGrande;
        private Decimal? _Grande;
        private Operadores_Int _OpeTipoDeAlimentoId;
        private int? _TipoDeAlimentoId;
        private Operadores_Int _OpeOrdenDeVisualizacion;
        private int? _OrdenDeVisualizacion;
        private Operadores_VarChar _OpeEstado;
        private string _Estado;
        private Operadores_VarChar _OpeTipo;
        private string _Tipo;

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

        public Operadores_VarChar OpeCodigo
        {
            get
            {
                return this._OpeCodigo;
            }
            set
            {
                this._OpeCodigo = value;
            }
        }

        public string Codigo
        {
            get
            {
                return this._Codigo;
            }
            set
            {
                this._Codigo = value;
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

        public Operadores_Numeric OpePequeña
        {
            get
            {
                return this._OpePequeña;
            }
            set
            {
                this._OpePequeña = value;
            }
        }

        public Decimal? Pequeña
        {
            get
            {
                return this._Pequeña;
            }
            set
            {
                this._Pequeña = value;
            }
        }

        public Operadores_Numeric OpeMediana
        {
            get
            {
                return this._OpeMediana;
            }
            set
            {
                this._OpeMediana = value;
            }
        }

        public Decimal? Mediana
        {
            get
            {
                return this._Mediana;
            }
            set
            {
                this._Mediana = value;
            }
        }

        public Operadores_Numeric OpeGrande
        {
            get
            {
                return this._OpeGrande;
            }
            set
            {
                this._OpeGrande = value;
            }
        }

        public Decimal? Grande
        {
            get
            {
                return this._Grande;
            }
            set
            {
                this._Grande = value;
            }
        }

        public Operadores_Int OpeTipoDeAlimentoId
        {
            get
            {
                return this._OpeTipoDeAlimentoId;
            }
            set
            {
                this._OpeTipoDeAlimentoId = value;
            }
        }

        public int? TipoDeAlimentoId
        {
            get
            {
                return this._TipoDeAlimentoId;
            }
            set
            {
                this._TipoDeAlimentoId = value;
            }
        }

        public Operadores_Int OpeOrdenDeVisualizacion
        {
            get
            {
                return this._OpeOrdenDeVisualizacion;
            }
            set
            {
                this._OpeOrdenDeVisualizacion = value;
            }
        }

        public int? OrdenDeVisualizacion
        {
            get
            {
                return this._OrdenDeVisualizacion;
            }
            set
            {
                this._OrdenDeVisualizacion = value;
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

        public Operadores_VarChar OpeTipo
        {
            get
            {
                return this._OpeTipo;
            }
            set
            {
                this._OpeTipo = value;
            }
        }

        public string Tipo
        {
            get
            {
                return this._Tipo;
            }
            set
            {
                this._Tipo = value;
            }
        }

        public vEncuestaAlimentoEntityFilter()
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
            this.OpeCodigo = Operadores_VarChar.Vacio;
            this.Codigo = (string)null;
            this.OpeNombre = Operadores_VarChar.Vacio;
            this.Nombre = (string)null;
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
            this.OpePequeña = Operadores_Numeric.Vacio;
            this.Pequeña = new Decimal?();
            this.OpeMediana = Operadores_Numeric.Vacio;
            this.Mediana = new Decimal?();
            this.OpeGrande = Operadores_Numeric.Vacio;
            this.Grande = new Decimal?();
            this.OpeTipoDeAlimentoId = Operadores_Int.Vacio;
            this.TipoDeAlimentoId = new int?();
            this.OpeOrdenDeVisualizacion = Operadores_Int.Vacio;
            this.OrdenDeVisualizacion = new int?();
            this.OpeEstado = Operadores_VarChar.Vacio;
            this.Estado = (string)null;
            this.OpeTipo = Operadores_VarChar.Vacio;
            this.Tipo = (string)null;
        }
    }
}

