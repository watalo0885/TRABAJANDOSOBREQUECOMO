using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interfood.Entities
{
    public class aspnet_RolesEntityInfo
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

        public aspnet_RolesEntityInfo()
        {
        }

        public aspnet_RolesEntityInfo(Guid oApplicationId, Guid oRoleId, string oRoleName, string oLoweredRoleName, string oDescription, string oLongDescription)
        {
            this.ApplicationId = oApplicationId;
            this.RoleId = oRoleId;
            this.RoleName = oRoleName;
            this.LoweredRoleName = oLoweredRoleName;
            this.Description = oDescription;
            this.LongDescription = oLongDescription;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<aspnet_RolesEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad aspnet_RolesEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class aspnet_RolesEntityInfoList : IEnumerable
        {
            private aspnet_RolesEntityInfo[] _entitiesInfo;

            public aspnet_RolesEntityInfoList()
            {
                this._entitiesInfo = (aspnet_RolesEntityInfo[])null;
            }

            public aspnet_RolesEntityInfoList(aspnet_RolesEntityInfo[] pArray)
            {
                this._entitiesInfo = new aspnet_RolesEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new aspnet_RolesEntityInfo.aspnet_RolesEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class aspnet_RolesEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public aspnet_RolesEntityInfo[] _entitiesInfo;

            public object Current
            {
                get
                {
                    try
                    {
                        return (object)this._entitiesInfo[this.position];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public aspnet_RolesEntityInfoEnum(aspnet_RolesEntityInfo[] list)
            {
                this._entitiesInfo = list;
            }

            public bool MoveNext()
            {
                ++this.position;
                return this.position < this._entitiesInfo.Length;
            }

            public void Reset()
            {
                this.position = -1;
            }
        }
    }
}
