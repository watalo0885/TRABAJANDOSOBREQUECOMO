using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class AlimentoEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeAlimentoId;
        private int? _AlimentoId;
        private Operadores_VarChar _OpeCodigo;
        private string _Codigo;
        private Operadores_VarChar _OpeNombre;
        private string _Nombre;
        private Operadores_VarChar _OpeTipo;
        private string _Tipo;
        private Operadores_VarChar _OpeEstacional;
        private string _Estacional;
        private Operadores_Numeric _OpePequeña;
        private Decimal? _Pequeña;
        private Operadores_Numeric _OpeMediana;
        private Decimal? _Mediana;
        private Operadores_Numeric _OpeGrande;
        private Decimal? _Grande;
        private Operadores_VarChar _OpeEstado;
        private string _Estado;
        private Operadores_Int _OpeTipoDeAlimentoId;
        private int? _TipoDeAlimentoId;
        private Operadores_Int _OpeOrdenDeVisualizacion;
        private int? _OrdenDeVisualizacion;

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

        public Operadores_VarChar OpeEstacional
        {
            get { return this._OpeEstacional; }
            set { this._OpeEstacional = value; }
        }

        public string Estacional
        {
            get { return this._Estacional; }
            set { this._Estacional = value; }
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

        public AlimentoEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeAlimentoId = Operadores_Int.Vacio;
            this.AlimentoId = new int?();
            this.OpeCodigo = Operadores_VarChar.Vacio;
            this.Codigo = (string)null;
            this.OpeNombre = Operadores_VarChar.Vacio;
            this.Nombre = (string)null;
            this.OpeTipo = Operadores_VarChar.Vacio;
            this.Tipo = (string)null;
            this.OpeEstacional = Operadores_VarChar.Vacio;
            this.Estacional = (string)null;
            this.OpePequeña = Operadores_Numeric.Vacio;
            this.Pequeña = new Decimal?();
            this.OpeMediana = Operadores_Numeric.Vacio;
            this.Mediana = new Decimal?();
            this.OpeGrande = Operadores_Numeric.Vacio;
            this.Grande = new Decimal?();
            this.OpeEstado = Operadores_VarChar.Vacio;
            this.Estado = (string)null;
            this.OpeTipoDeAlimentoId = Operadores_Int.Vacio;
            this.TipoDeAlimentoId = new int?();
            this.OpeOrdenDeVisualizacion = Operadores_Int.Vacio;
            this.OrdenDeVisualizacion = new int?();
        }
    }
}
