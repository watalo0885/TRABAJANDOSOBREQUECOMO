using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace Interfood.Entities
{
    public class AlimentoEntityUpdate
    {
        private int? _AlimentoId;
        private string _Codigo;
        private string _Nombre;
        private string _Tipo;
        private string _Estacional;
        private Decimal? _Pequeña;
        private Decimal? _Mediana;
        private Decimal? _Grande;
        private string _Estado;
        private int? _TipoDeAlimentoId;
        private int? _OrdenDeVisualizacion;

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

        public string Estacional
        {
            get { return this._Estacional; }
            set { this._Estacional = value; }
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

        public AlimentoEntityUpdate()
        {
            this.Clear();
        }

        public AlimentoEntityUpdate(AlimentoEntityInfo EntityInfo)
        {
            this.Clear();
            this.Codigo = EntityInfo.Codigo;
            this.Nombre = EntityInfo.Nombre;
            this.Tipo = EntityInfo.Tipo;
            this.Estacional = EntityInfo.Estacional;
            this.Pequeña = new Decimal?(EntityInfo.Pequeña);
            this.Mediana = new Decimal?(EntityInfo.Mediana);
            this.Grande = new Decimal?(EntityInfo.Grande);
            this.Estado = EntityInfo.Estado;
            this.TipoDeAlimentoId = EntityInfo.TipoDeAlimentoId;
            this.OrdenDeVisualizacion = EntityInfo.OrdenDeVisualizacion;
        }

        public void LoadFromInfo(AlimentoEntityInfo EntityInfo)
        {
            this.Clear();
            this.Codigo = EntityInfo.Codigo;
            this.Nombre = EntityInfo.Nombre;
            this.Tipo = EntityInfo.Tipo;
            this.Estacional = EntityInfo.Estacional;
            this.Pequeña = new Decimal?(EntityInfo.Pequeña);
            this.Mediana = new Decimal?(EntityInfo.Mediana);
            this.Grande = new Decimal?(EntityInfo.Grande);
            this.Estado = EntityInfo.Estado;
            this.TipoDeAlimentoId = EntityInfo.TipoDeAlimentoId;
            this.OrdenDeVisualizacion = EntityInfo.OrdenDeVisualizacion;
        }

        public void Clear()
        {
            this.AlimentoId = new int?();
            this.Codigo = (string)null;
            this.Nombre = (string)null;
            this.Tipo = (string)null;
            this.Estacional = (string)null;
            this.Pequeña = new Decimal?();
            this.Mediana = new Decimal?();
            this.Grande = new Decimal?();
            this.Estado = (string)null;
            this.TipoDeAlimentoId = new int?();
            this.OrdenDeVisualizacion = new int?();
        }
    }
}

