using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Interfood.Entities
{
    public class NutrienteEntityUpdate
    {
        private int? _NutrienteId;
        private string _Nombre;
        private string _UDMId;
        private int? _PerteneceA;
        private string _Estado;

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

        public int? PerteneceA
        {
            get
            {
                return this._PerteneceA;
            }
            set
            {
                this._PerteneceA = value;
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

        public NutrienteEntityUpdate()
        {
            this.Clear();
        }

        public NutrienteEntityUpdate(NutrienteEntityInfo EntityInfo)
        {
            this.Clear();
            this.Nombre = EntityInfo.Nombre;
            this.UDMId = EntityInfo.UDMId;
            this.PerteneceA = EntityInfo.PerteneceA;
            this.Estado = EntityInfo.Estado;
        }

        public void LoadFromInfo(NutrienteEntityInfo EntityInfo)
        {
            this.Clear();
            this.Nombre = EntityInfo.Nombre;
            this.UDMId = EntityInfo.UDMId;
            this.PerteneceA = EntityInfo.PerteneceA;
            this.Estado = EntityInfo.Estado;
        }

        public void Clear()
        {
            this.NutrienteId = new int?();
            this.Nombre = (string)null;
            this.UDMId = (string)null;
            this.PerteneceA = new int?();
            this.Estado = (string)null;
        }
    }
}

