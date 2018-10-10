using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Interfood.Entities
{
    public class FuenteEntityKey
    {

            private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private string _FntID;

        [NotNullValidator(MessageTemplate = "La propiedad FntID no puede ser Nula.")]
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public FuenteEntityKey()
        {
        }

        public FuenteEntityKey(string oUDMId)
        {
            this.FntID = oUDMId;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<FuenteEntityKey>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad FuenteEntityKey no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }



    }
}
