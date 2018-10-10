using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Interfood.Entities

{
    public class UnidadMedidaEntityUpdate
    {
        private string _UDMId;
        private string _Nombre;

        public string UDMId
        {
            get
            {
                return this._UDMId;
            }
            set
            {
                this._UDMId = value;
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

        public UnidadMedidaEntityUpdate()
        {
            this.Clear();
        }

        public UnidadMedidaEntityUpdate(UnidadMedidaEntityInfo EntityInfo)
        {
            this.Clear();
            this.UDMId = EntityInfo.UDMId;
            this.Nombre = EntityInfo.Nombre;
        }

        public void LoadFromInfo(UnidadMedidaEntityInfo EntityInfo)
        {
            this.Clear();
            this.UDMId = EntityInfo.UDMId;
            this.Nombre = EntityInfo.Nombre;
        }

        public void Clear()
        {
            this.UDMId = (string)null;
            this.Nombre = (string)null;
        }
    }
}
