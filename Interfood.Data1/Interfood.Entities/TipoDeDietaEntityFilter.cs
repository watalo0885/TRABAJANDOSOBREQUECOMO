using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class TipoDeDietaEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeTipoDeDietaId;
        private int? _TipoDeDietaId;
        private Operadores_VarChar _OpeTipoDeDieta;
        private string _TipoDeDieta;

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

        public Operadores_Int OpeTipoDeDietaId
        {
            get
            {
                return this._OpeTipoDeDietaId;
            }
            set
            {
                this._OpeTipoDeDietaId = value;
            }
        }

        public int? TipoDeDietaId
        {
            get
            {
                return this._TipoDeDietaId;
            }
            set
            {
                this._TipoDeDietaId = value;
            }
        }

        public Operadores_VarChar OpeTipoDeDieta
        {
            get
            {
                return this._OpeTipoDeDieta;
            }
            set
            {
                this._OpeTipoDeDieta = value;
            }
        }

        public string TipoDeDieta
        {
            get
            {
                return this._TipoDeDieta;
            }
            set
            {
                this._TipoDeDieta = value;
            }
        }

        public TipoDeDietaEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeTipoDeDietaId = Operadores_Int.Vacio;
            this.TipoDeDietaId = new int?();
            this.OpeTipoDeDieta = Operadores_VarChar.Vacio;
            this.TipoDeDieta = (string)null;
        }
    }
}
