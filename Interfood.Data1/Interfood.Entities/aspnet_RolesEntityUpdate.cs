using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfood.Entities
{
    public class aspnet_RolesEntityUpdate
    {
        private Guid? _ApplicationId;
        private Guid? _RoleId;
        private string _RoleName;
        private string _LoweredRoleName;
        private string _Description;
        private string _LongDescription;

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

        public aspnet_RolesEntityUpdate()
        {
            this.Clear();
        }

        public aspnet_RolesEntityUpdate(aspnet_RolesEntityInfo EntityInfo)
        {
            this.Clear();
            this.ApplicationId = new Guid?(EntityInfo.ApplicationId);
            this.RoleId = new Guid?(EntityInfo.RoleId);
            this.RoleName = EntityInfo.RoleName;
            this.LoweredRoleName = EntityInfo.LoweredRoleName;
            this.Description = EntityInfo.Description;
            this.LongDescription = EntityInfo.LongDescription;
        }

        public void LoadFromInfo(aspnet_RolesEntityInfo EntityInfo)
        {
            this.Clear();
            this.ApplicationId = new Guid?(EntityInfo.ApplicationId);
            this.RoleId = new Guid?(EntityInfo.RoleId);
            this.RoleName = EntityInfo.RoleName;
            this.LoweredRoleName = EntityInfo.LoweredRoleName;
            this.Description = EntityInfo.Description;
            this.LongDescription = EntityInfo.LongDescription;
        }

        public void Clear()
        {
            this.ApplicationId = new Guid?();
            this.RoleId = new Guid?();
            this.RoleName = (string)null;
            this.LoweredRoleName = (string)null;
            this.Description = (string)null;
            this.LongDescription = (string)null;
        }
    }
}

