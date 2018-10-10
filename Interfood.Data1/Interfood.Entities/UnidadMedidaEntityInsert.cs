using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;


namespace Interfood.Entities
{
    public class UnidadMedidaEntityInsert
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private string _UDMId;
        private string _Nombre;

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

        public string Nombre
        {
            get
            {
                return this._Nombre;
            }
            set
            {
                this._Nombre = value;
            }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public UnidadMedidaEntityInsert()
        {
        }

        public UnidadMedidaEntityInsert(string oUDMId, string oNombre)
        {
            this.UDMId = oUDMId;
            this.Nombre = oNombre;
        }

        public UnidadMedidaEntityInsert(UnidadMedidaEntityInfo EntityInfo)
        {
            this.UDMId = EntityInfo.UDMId;
            this.Nombre = EntityInfo.Nombre;
        }

        public void LoadFromInfo(UnidadMedidaEntityInfo EntityInfo)
        {
            this.UDMId = EntityInfo.UDMId;
            this.Nombre = EntityInfo.Nombre;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<UnidadMedidaEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad UnidadMedidaEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}

