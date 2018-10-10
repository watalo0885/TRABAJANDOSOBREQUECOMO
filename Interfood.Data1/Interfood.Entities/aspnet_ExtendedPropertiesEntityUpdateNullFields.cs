using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfood.Entities
{
    public class aspnet_ExtendedPropertiesEntityUpdateNullFields
    {
        private string _whereExtendido;
        private string _FieldList;

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

        public string FieldList
        {
            get
            {
                return this._FieldList;
            }
            set
            {
                this._FieldList = value;
            }
        }

        public aspnet_ExtendedPropertiesEntityUpdateNullFields()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.FieldList = (string)null;
        }
    }
}
