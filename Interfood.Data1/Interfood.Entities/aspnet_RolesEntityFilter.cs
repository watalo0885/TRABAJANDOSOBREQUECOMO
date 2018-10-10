using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class aspnet_RolesEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_UniqueIdentifier _OpeApplicationId;
        private Guid? _ApplicationId;
        private Operadores_UniqueIdentifier _OpeRoleId;
        private Guid? _RoleId;
        private Operadores_NVarChar _OpeRoleName;
        private string _RoleName;
        private Operadores_NVarChar _OpeLoweredRoleName;
        private string _LoweredRoleName;
        private Operadores_NVarChar _OpeDescription;
        private string _Description;
        private Operadores_VarChar _OpeLongDescription;
        private string _LongDescription;

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

        public Operadores_UniqueIdentifier OpeApplicationId
        {
            get
            {
                return this._OpeApplicationId;
            }
            set
            {
                this._OpeApplicationId = value;
            }
        }

        public Guid? ApplicationId
        {
            get
            {
                return this._ApplicationId;
            }
            set
            {
                this._ApplicationId = value;
            }
        }

        public Operadores_UniqueIdentifier OpeRoleId
        {
            get
            {
                return this._OpeRoleId;
            }
            set
            {
                this._OpeRoleId = value;
            }
        }

        public Guid? RoleId
        {
            get
            {
                return this._RoleId;
            }
            set
            {
                this._RoleId = value;
            }
        }

        public Operadores_NVarChar OpeRoleName
        {
            get
            {
                return this._OpeRoleName;
            }
            set
            {
                this._OpeRoleName = value;
            }
        }

        public string RoleName
        {
            get
            {
                return this._RoleName;
            }
            set
            {
                this._RoleName = value;
            }
        }

        public Operadores_NVarChar OpeLoweredRoleName
        {
            get
            {
                return this._OpeLoweredRoleName;
            }
            set
            {
                this._OpeLoweredRoleName = value;
            }
        }

        public string LoweredRoleName
        {
            get
            {
                return this._LoweredRoleName;
            }
            set
            {
                this._LoweredRoleName = value;
            }
        }

        public Operadores_NVarChar OpeDescription
        {
            get
            {
                return this._OpeDescription;
            }
            set
            {
                this._OpeDescription = value;
            }
        }

        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this._Description = value;
            }
        }

        public Operadores_VarChar OpeLongDescription
        {
            get
            {
                return this._OpeLongDescription;
            }
            set
            {
                this._OpeLongDescription = value;
            }
        }

        public string LongDescription
        {
            get
            {
                return this._LongDescription;
            }
            set
            {
                this._LongDescription = value;
            }
        }

        public aspnet_RolesEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeApplicationId = Operadores_UniqueIdentifier.Vacio;
            this.ApplicationId = new Guid?();
            this.OpeRoleId = Operadores_UniqueIdentifier.Vacio;
            this.RoleId = new Guid?();
            this.OpeRoleName = Operadores_NVarChar.Vacio;
            this.RoleName = (string)null;
            this.OpeLoweredRoleName = Operadores_NVarChar.Vacio;
            this.LoweredRoleName = (string)null;
            this.OpeDescription = Operadores_NVarChar.Vacio;
            this.Description = (string)null;
            this.OpeLongDescription = Operadores_VarChar.Vacio;
            this.LongDescription = (string)null;
        }
    }
}
