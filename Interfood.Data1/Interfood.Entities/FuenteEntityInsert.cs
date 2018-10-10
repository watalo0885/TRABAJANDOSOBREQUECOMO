using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Interfood.Entities
{
    public class FuenteEntityInsert
    {
        private StringBuilder _errorQueInvalidanLaEntidad = new StringBuilder();
        private string _FntID;
        private string _Nombre;

      
        [NotNullValidator(MessageTemplate = "La propiedad fntID no puede ser Nula.")]
        public string FntID
        {
            get { return _FntID; }
            set { _FntID = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._errorQueInvalidanLaEntidad.ToString();
            }
        }

        public FuenteEntityInsert()
        {
                    }

        public FuenteEntityInsert(string oFntID, string oNombre)
        {
            this.FntID = oFntID;
            this.Nombre = oNombre;
        }

        public FuenteEntityInsert(FuenteEntityInfo EntityInfo)
        {
            this.FntID = EntityInfo.FntID;
            this.Nombre = EntityInfo.Nombre;
        }

        public void LoadFromInfo(FuenteEntityInfo EntityInfo)
        {
            this.FntID = EntityInfo.FntID;
            this.Nombre = EntityInfo.Nombre;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<FuenteEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._errorQueInvalidanLaEntidad.AppendLine("La entidad FuenteEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._errorQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
            }
        }

    
}
