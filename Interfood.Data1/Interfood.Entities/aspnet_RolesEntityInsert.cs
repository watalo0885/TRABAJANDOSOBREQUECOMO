using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfood.Entities
{
    public class aspnet_RolesEntityInsert
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private Guid _ApplicationId;
        private Guid _RoleId;
        private string _RoleName;
        private string _LoweredRoleName;
        private string _Description;
        private string _LongDescription;

        [NotNullValidator(MessageTemplate = "La propiedad ApplicationId no puede ser Nula.")]
        public Guid ApplicationId
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

        [NotNullValidator(MessageTemplate = "La propiedad RoleId no puede ser Nula.")]
        public Guid RoleId
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

        [NotNullValidator(MessageTemplate = "La propiedad RoleName no puede ser Nula.")]
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

        [NotNullValidator(MessageTemplate = "La propiedad LoweredRoleName no puede ser Nula.")]
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public aspnet_RolesEntityInsert()
        {
        }

        public aspnet_RolesEntityInsert(Guid oApplicationId, Guid oRoleId, string oRoleName, string oLoweredRoleName, string oDescription, string oLongDescription)
        {
            this.ApplicationId = oApplicationId;
            this.RoleId = oRoleId;
            this.RoleName = oRoleName;
            this.LoweredRoleName = oLoweredRoleName;
            this.Description = oDescription;
            this.LongDescription = oLongDescription;
        }

        public aspnet_RolesEntityInsert(aspnet_RolesEntityInfo EntityInfo)
        {
            this.ApplicationId = EntityInfo.ApplicationId;
            this.RoleId = EntityInfo.RoleId;
            this.RoleName = EntityInfo.RoleName;
            this.LoweredRoleName = EntityInfo.LoweredRoleName;
            this.Description = EntityInfo.Description;
            this.LongDescription = EntityInfo.LongDescription;
        }

        public void LoadFromInfo(aspnet_RolesEntityInfo EntityInfo)
        {
            this.ApplicationId = EntityInfo.ApplicationId;
            this.RoleId = EntityInfo.RoleId;
            this.RoleName = EntityInfo.RoleName;
            this.LoweredRoleName = EntityInfo.LoweredRoleName;
            this.Description = EntityInfo.Description;
            this.LongDescription = EntityInfo.LongDescription;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<aspnet_RolesEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad aspnet_RolesEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}

