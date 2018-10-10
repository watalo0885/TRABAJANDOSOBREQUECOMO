using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System.Collections.Generic;
using System.Text;

namespace Interfood.Entities
{
    public class NutrienteEntityInsert
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private string _Nombre;
        private string _UDMId;
        private int? _PerteneceA;
        private string _Estado;

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

        public int? PerteneceA
        {
            get
            {
                return this._PerteneceA;
            }
            set
            {
                this._PerteneceA = value;
            }
        }

        public string Estado
        {
            get
            {
                return this._Estado;
            }
            set
            {
                this._Estado = value;
            }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public NutrienteEntityInsert()
        {
        }

        public NutrienteEntityInsert(string oNombre, string oUDMId, int? oPerteneceA, string oEstado)
        {
            this.Nombre = oNombre;
            this.UDMId = oUDMId;
            this.PerteneceA = oPerteneceA;
            this.Estado = oEstado;
        }

        public NutrienteEntityInsert(NutrienteEntityInfo EntityInfo)
        {
            this.Nombre = EntityInfo.Nombre;
            this.UDMId = EntityInfo.UDMId;
            this.PerteneceA = EntityInfo.PerteneceA;
            this.Estado = EntityInfo.Estado;
        }

        public void LoadFromInfo(NutrienteEntityInfo EntityInfo)
        {
            this.Nombre = EntityInfo.Nombre;
            this.UDMId = EntityInfo.UDMId;
            this.PerteneceA = EntityInfo.PerteneceA;
            this.Estado = EntityInfo.Estado;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<NutrienteEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad NutrienteEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}
