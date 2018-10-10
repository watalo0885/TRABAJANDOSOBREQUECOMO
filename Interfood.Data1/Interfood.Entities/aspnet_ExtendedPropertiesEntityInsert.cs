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
    public class aspnet_ExtendedPropertiesEntityInsert
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

        public aspnet_ExtendedPropertiesEntityInsert()
        {
        }

        public aspnet_ExtendedPropertiesEntityInsert(Guid oUserId, string oApellido, string oNombres, string oEmpresa, int oLimiteDeEncuestas, string oTelefonoFijo1, string oTelefonoFijo2, string oFax, string oCelular, string oEmail, DateTime oFechaAlta)
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

        public aspnet_ExtendedPropertiesEntityInsert(aspnet_ExtendedPropertiesEntityInfo EntityInfo)
        {
            this.UserId = EntityInfo.UserId;
            this.Apellido = EntityInfo.Apellido;
            this.Nombres = EntityInfo.Nombres;
            this.Empresa = EntityInfo.Empresa;
            this.LimiteDeEncuestas = EntityInfo.LimiteDeEncuestas;
            this.TelefonoFijo1 = EntityInfo.TelefonoFijo1;
            this.TelefonoFijo2 = EntityInfo.TelefonoFijo2;
            this.Fax = EntityInfo.Fax;
            this.Celular = EntityInfo.Celular;
            this.Email = EntityInfo.Email;
            this.FechaAlta = EntityInfo.FechaAlta;
        }

        public void LoadFromInfo(aspnet_ExtendedPropertiesEntityInfo EntityInfo)
        {
            this.UserId = EntityInfo.UserId;
            this.Apellido = EntityInfo.Apellido;
            this.Nombres = EntityInfo.Nombres;
            this.Empresa = EntityInfo.Empresa;
            this.LimiteDeEncuestas = EntityInfo.LimiteDeEncuestas;
            this.TelefonoFijo1 = EntityInfo.TelefonoFijo1;
            this.TelefonoFijo2 = EntityInfo.TelefonoFijo2;
            this.Fax = EntityInfo.Fax;
            this.Celular = EntityInfo.Celular;
            this.Email = EntityInfo.Email;
            this.FechaAlta = EntityInfo.FechaAlta;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<aspnet_ExtendedPropertiesEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad aspnet_ExtendedPropertiesEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}

