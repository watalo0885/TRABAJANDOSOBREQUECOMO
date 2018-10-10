using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfood.Entities
{
    public class FuenteEntityUpdate
    {
         private string _FntID;
        private string _Nombre;

        public string FntID
        {
            get
            {
                return this._FntID;
            }
            set
            {
                this._FntID = value;
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

        public FuenteEntityUpdate()
        {
            this.Clear();
        }

        public FuenteEntityUpdate(FuenteEntityUpdate EntityInfo)
        {
            this.Clear();
            this.FntID = EntityInfo.FntID;
            this.Nombre = EntityInfo.Nombre;
        }

        public void LoadFromInfo(FuenteEntityUpdate EntityInfo)
        {
            this.Clear();
            this.FntID = EntityInfo.FntID;
            this.Nombre = EntityInfo.Nombre;
        }

        public void Clear()
        {
            this.FntID = (string)null;
            this.Nombre = (string)null;
        }

        public void LoadFromInfo(FuenteEntityInfo EntityInfo)
        {
            throw new NotImplementedException();
        }
    }
}
