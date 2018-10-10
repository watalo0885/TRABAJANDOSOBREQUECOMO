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
    public class vExtendedPropertiesEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private Guid _UserId;
        private string _Apellido;
        private string _Nombres;
        private string _Empresa;
        private int _LimiteDeEncuestas;
        private string _TelefonoFijo1;
        private string _TelefonoFijo2;
        private string _Fax;
        private string _Celular;
        private DateTime _FechaAlta;
        private string _UserName;
        private string _Password;
        private string _Email;
        private bool? _IsApproved;
        private bool? _IsLockedOut;
        private DateTime? _LastLoginDate;
        private string _RoleName;

        [NotNullValidator(MessageTemplate = "La propiedad UserId no puede ser Nula.")]
        public Guid UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this._UserId = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad Apellido no puede ser Nula.")]
        public string Apellido
        {
            get
            {
                return this._Apellido;
            }
            set
            {
                this._Apellido = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad Nombres no puede ser Nula.")]
        public string Nombres
        {
            get
            {
                return this._Nombres;
            }
            set
            {
                this._Nombres = value;
            }
        }

        public string Empresa
        {
            get
            {
                return this._Empresa;
            }
            set
            {
                this._Empresa = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad LimiteDeEncuestas no puede ser Nula.")]
        public int LimiteDeEncuestas
        {
            get
            {
                return this._LimiteDeEncuestas;
            }
            set
            {
                this._LimiteDeEncuestas = value;
            }
        }

        public string TelefonoFijo1
        {
            get
            {
                return this._TelefonoFijo1;
            }
            set
            {
                this._TelefonoFijo1 = value;
            }
        }

        public string TelefonoFijo2
        {
            get
            {
                return this._TelefonoFijo2;
            }
            set
            {
                this._TelefonoFijo2 = value;
            }
        }

        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this._Fax = value;
            }
        }

        public string Celular
        {
            get
            {
                return this._Celular;
            }
            set
            {
                this._Celular = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad FechaAlta no puede ser Nula.")]
        public DateTime FechaAlta
        {
            get
            {
                return this._FechaAlta;
            }
            set
            {
                this._FechaAlta = value;
            }
        }

        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }

        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
            }
        }

        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }

        public bool? IsApproved
        {
            get
            {
                return this._IsApproved;
            }
            set
            {
                this._IsApproved = value;
            }
        }

        public bool? IsLockedOut
        {
            get
            {
                return this._IsLockedOut;
            }
            set
            {
                this._IsLockedOut = value;
            }
        }

        public DateTime? LastLoginDate
        {
            get
            {
                return this._LastLoginDate;
            }
            set
            {
                this._LastLoginDate = value;
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public vExtendedPropertiesEntityInfo()
        {
        }

        public vExtendedPropertiesEntityInfo(Guid oUserId, string oApellido, string oNombres, string oEmpresa, int oLimiteDeEncuestas, string oTelefonoFijo1, string oTelefonoFijo2, string oFax, string oCelular, DateTime oFechaAlta, string oUserName, string oPassword, string oEmail, bool? oIsApproved, bool? oIsLockedOut, DateTime? oLastLoginDate, string oRoleName)
        {
            this.UserId = oUserId;
            this.Apellido = oApellido;
            this.Nombres = oNombres;
            this.Empresa = oEmpresa;
            this.LimiteDeEncuestas = oLimiteDeEncuestas;
            this.TelefonoFijo1 = oTelefonoFijo1;
            this.TelefonoFijo2 = oTelefonoFijo2;
            this.Fax = oFax;
            this.Celular = oCelular;
            this.FechaAlta = oFechaAlta;
            this.UserName = oUserName;
            this.Password = oPassword;
            this.Email = oEmail;
            this.IsApproved = oIsApproved;
            this.IsLockedOut = oIsLockedOut;
            this.LastLoginDate = oLastLoginDate;
            this.RoleName = oRoleName;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<vExtendedPropertiesEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad vExtendedPropertiesEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class vExtendedPropertiesEntityInfoList : IEnumerable
        {
            private vExtendedPropertiesEntityInfo[] _entitiesInfo;

            public vExtendedPropertiesEntityInfoList()
            {
                this._entitiesInfo = (vExtendedPropertiesEntityInfo[])null;
            }

            public vExtendedPropertiesEntityInfoList(vExtendedPropertiesEntityInfo[] pArray)
            {
                this._entitiesInfo = new vExtendedPropertiesEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new vExtendedPropertiesEntityInfo.vExtendedPropertiesEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class vExtendedPropertiesEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public vExtendedPropertiesEntityInfo[] _entitiesInfo;

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

            public vExtendedPropertiesEntityInfoEnum(vExtendedPropertiesEntityInfo[] list)
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
