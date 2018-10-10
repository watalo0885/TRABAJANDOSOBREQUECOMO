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
    public class AlimentoEntityKey
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _AlimentoId;

        [NotNullValidator(MessageTemplate = "La propiedad AlimentoId no puede ser Nula.")]
        public int AlimentoId
        {
            get
            {
                return this._AlimentoId;
            }
            set
            {
                this._AlimentoId = value;
            }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public AlimentoEntityKey()
        {
        }

        public AlimentoEntityKey(int oAlimentoId)
        {
            this.AlimentoId = oAlimentoId;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<AlimentoEntityKey>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad AlimentoEntityKey no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}
