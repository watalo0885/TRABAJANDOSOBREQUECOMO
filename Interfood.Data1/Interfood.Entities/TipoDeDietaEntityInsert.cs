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
    public class TipoDeDietaEntityInsert
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private string _TipoDeDieta;

        [NotNullValidator(MessageTemplate = "La propiedad TipoDeDieta no puede ser Nula.")]
        public string TipoDeDieta
        {
            get
            {
                return this._TipoDeDieta;
            }
            set
            {
                this._TipoDeDieta = value;
            }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public TipoDeDietaEntityInsert()
        {
        }

        public TipoDeDietaEntityInsert(string oTipoDeDieta)
        {
            this.TipoDeDieta = oTipoDeDieta;
        }

        public TipoDeDietaEntityInsert(TipoDeDietaEntityInfo EntityInfo)
        {
            this.TipoDeDieta = EntityInfo.TipoDeDieta;
        }

        public void LoadFromInfo(TipoDeDietaEntityInfo EntityInfo)
        {
            this.TipoDeDieta = EntityInfo.TipoDeDieta;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<TipoDeDietaEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad TipoDeDietaEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}
