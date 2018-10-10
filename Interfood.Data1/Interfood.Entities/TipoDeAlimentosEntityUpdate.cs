using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Interfood.Entities
{
    public class TipoDeAlimentosEntityUpdate
    {
        private int? _TipoDeAlimentoId;
        private string _TipoDeAlimento;
        private int? _OrdenDeVisualizacion;
        private string _Estado;

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

        public TipoDeAlimentosEntityUpdate()
        {
            this.Clear();
        }

        public TipoDeAlimentosEntityUpdate(TipoDeAlimentosEntityInfo EntityInfo)
        {
            this.Clear();
            this.TipoDeAlimento = EntityInfo.TipoDeAlimento;
            this.OrdenDeVisualizacion = new int?(EntityInfo.OrdenDeVisualizacion);
            this.Estado = EntityInfo.Estado;
        }

        public void LoadFromInfo(TipoDeAlimentosEntityInfo EntityInfo)
        {
            this.Clear();
            this.TipoDeAlimento = EntityInfo.TipoDeAlimento;
            this.OrdenDeVisualizacion = new int?(EntityInfo.OrdenDeVisualizacion);
            this.Estado = EntityInfo.Estado;
        }

        public void Clear()
        {
            this.TipoDeAlimentoId = new int?();
            this.TipoDeAlimento = (string)null;
            this.OrdenDeVisualizacion = new int?();
            this.Estado = (string)null;
        }
    }
}
