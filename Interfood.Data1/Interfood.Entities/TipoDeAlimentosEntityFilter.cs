using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class TipoDeAlimentosEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeTipoDeAlimentoId;
        private int? _TipoDeAlimentoId;
        private Operadores_VarChar _OpeTipoDeAlimento;
        private string _TipoDeAlimento;
        private Operadores_Int _OpeOrdenDeVisualizacion;
        private int? _OrdenDeVisualizacion;
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

        public TipoDeAlimentosEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeTipoDeAlimentoId = Operadores_Int.Vacio;
            this.TipoDeAlimentoId = new int?();
            this.OpeTipoDeAlimento = Operadores_VarChar.Vacio;
            this.TipoDeAlimento = (string)null;
            this.OpeOrdenDeVisualizacion = Operadores_Int.Vacio;
            this.OrdenDeVisualizacion = new int?();
            this.OpeEstado = Operadores_VarChar.Vacio;
            this.Estado = (string)null;
        }
    }
}

