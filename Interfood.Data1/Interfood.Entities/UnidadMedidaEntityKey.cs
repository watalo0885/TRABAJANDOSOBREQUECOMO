using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections.Generic;
using System.Text;

namespace Interfood.Entities
{
    public class UnidadMedidaEntityKey
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private string _UDMId;

        [NotNullValidator(MessageTemplate = "La propiedad UDMId no puede ser Nula.")]
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public UnidadMedidaEntityKey()
        {
        }

        public UnidadMedidaEntityKey(string oUDMId)
        {
            this.UDMId = oUDMId;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<UnidadMedidaEntityKey>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad UnidadMedidaEntityKey no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}

