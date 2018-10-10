using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class vAlimentosDeEncuestasEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeOrden1;
        private int? _Orden1;
        private Operadores_Int _OpeOrden2;
        private int? _Orden2;
        private Operadores_VarChar _OpeTipoDeAlimento;
        private string _TipoDeAlimento;
        private Operadores_VarChar _OpeAlimentoCodigo;
        private string _AlimentoCodigo;
        private Operadores_VarChar _OpeNombre;
        private string _Nombre;
        private Operadores_Int _OpeNunca;
        private int? _Nunca;
        private Operadores_Int _OpeVM;
        private int? _VM;
        private Operadores_Int _OpeVS;
        private int? _VS;
        private Operadores_Int _OpeVD;
        private int? _VD;
        private Operadores_Int _OpeP;
        private int? _P;
        private Operadores_Int _OpeM;
        private int? _M;
        private Operadores_Int _OpeG;
        private int? _G;

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

        public Operadores_Int OpeOrden1
        {
            get
            {
                return this._OpeOrden1;
            }
            set
            {
                this._OpeOrden1 = value;
            }
        }

        public int? Orden1
        {
            get
            {
                return this._Orden1;
            }
            set
            {
                this._Orden1 = value;
            }
        }

        public Operadores_Int OpeOrden2
        {
            get
            {
                return this._OpeOrden2;
            }
            set
            {
                this._OpeOrden2 = value;
            }
        }

        public int? Orden2
        {
            get
            {
                return this._Orden2;
            }
            set
            {
                this._Orden2 = value;
            }
        }

        public Operadores_VarChar OpeTipoDeAlimento
        {
            get
            {
                return this._OpeTipoDeAlimento;
            }
            set
            {
                this._OpeTipoDeAlimento = value;
            }
        }

        public string TipoDeAlimento
        {
            get
            {
                return this._TipoDeAlimento;
            }
            set
            {
                this._TipoDeAlimento = value;
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

        public Operadores_Int OpeNunca
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

        public int? Nunca
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

        public Operadores_Int OpeVM
        {
            get
            {
                return this._OpeVM;
            }
            set
            {
                this._OpeVM = value;
            }
        }

        public int? VM
        {
            get
            {
                return this._VM;
            }
            set
            {
                this._VM = value;
            }
        }

        public Operadores_Int OpeVS
        {
            get
            {
                return this._OpeVS;
            }
            set
            {
                this._OpeVS = value;
            }
        }

        public int? VS
        {
            get
            {
                return this._VS;
            }
            set
            {
                this._VS = value;
            }
        }

        public Operadores_Int OpeVD
        {
            get
            {
                return this._OpeVD;
            }
            set
            {
                this._OpeVD = value;
            }
        }

        public int? VD
        {
            get
            {
                return this._VD;
            }
            set
            {
                this._VD = value;
            }
        }

        public Operadores_Int OpeP
        {
            get
            {
                return this._OpeP;
            }
            set
            {
                this._OpeP = value;
            }
        }

        public int? P
        {
            get
            {
                return this._P;
            }
            set
            {
                this._P = value;
            }
        }

        public Operadores_Int OpeM
        {
            get
            {
                return this._OpeM;
            }
            set
            {
                this._OpeM = value;
            }
        }

        public int? M
        {
            get
            {
                return this._M;
            }
            set
            {
                this._M = value;
            }
        }

        public Operadores_Int OpeG
        {
            get
            {
                return this._OpeG;
            }
            set
            {
                this._OpeG = value;
            }
        }

        public int? G
        {
            get
            {
                return this._G;
            }
            set
            {
                this._G = value;
            }
        }

        public vAlimentosDeEncuestasEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeOrden1 = Operadores_Int.Vacio;
            this.Orden1 = new int?();
            this.OpeOrden2 = Operadores_Int.Vacio;
            this.Orden2 = new int?();
            this.OpeTipoDeAlimento = Operadores_VarChar.Vacio;
            this.TipoDeAlimento = (string)null;
            this.OpeAlimentoCodigo = Operadores_VarChar.Vacio;
            this.AlimentoCodigo = (string)null;
            this.OpeNombre = Operadores_VarChar.Vacio;
            this.Nombre = (string)null;
            this.OpeNunca = Operadores_Int.Vacio;
            this.Nunca = new int?();
            this.OpeVM = Operadores_Int.Vacio;
            this.VM = new int?();
            this.OpeVS = Operadores_Int.Vacio;
            this.VS = new int?();
            this.OpeVD = Operadores_Int.Vacio;
            this.VD = new int?();
            this.OpeP = Operadores_Int.Vacio;
            this.P = new int?();
            this.OpeM = Operadores_Int.Vacio;
            this.M = new int?();
            this.OpeG = Operadores_Int.Vacio;
            this.G = new int?();
        }
    }
}

