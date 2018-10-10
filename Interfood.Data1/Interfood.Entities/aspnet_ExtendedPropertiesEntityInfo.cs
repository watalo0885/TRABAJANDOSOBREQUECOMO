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
    public class aspnet_ExtendedPropertiesEntityInfo
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
        private string _Email;
        private DateTime _FechaAlta;

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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public aspnet_ExtendedPropertiesEntityInfo()
        {
        }

        public aspnet_ExtendedPropertiesEntityInfo(Guid oUserId, string oApellido, string oNombres, string oEmpresa, int oLimiteDeEncuestas, string oTelefonoFijo1, string oTelefonoFijo2, string oFax, string oCelular, string oEmail, DateTime oFechaAlta)
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
            this.Email = oEmail;
            this.FechaAlta = oFechaAlta;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<aspnet_ExtendedPropertiesEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad aspnet_ExtendedPropertiesEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class aspnet_ExtendedPropertiesEntityInfoList : IEnumerable
        {
            private aspnet_ExtendedPropertiesEntityInfo[] _entitiesInfo;

            public aspnet_ExtendedPropertiesEntityInfoList()
            {
                this._entitiesInfo = (aspnet_ExtendedPropertiesEntityInfo[])null;
            }

            public aspnet_ExtendedPropertiesEntityInfoList(aspnet_ExtendedPropertiesEntityInfo[] pArray)
            {
                this._entitiesInfo = new aspnet_ExtendedPropertiesEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new aspnet_ExtendedPropertiesEntityInfo.aspnet_ExtendedPropertiesEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class aspnet_ExtendedPropertiesEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public aspnet_ExtendedPropertiesEntityInfo[] _entitiesInfo;

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

            public aspnet_ExtendedPropertiesEntityInfoEnum(aspnet_ExtendedPropertiesEntityInfo[] list)
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

