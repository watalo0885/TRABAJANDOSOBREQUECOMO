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
    public class TipoDeAlimentosEntityInsert
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private string _TipoDeAlimento;
        private int _OrdenDeVisualizacion;
        private string _Estado;

        [NotNullValidator(MessageTemplate = "La propiedad TipoDeAlimento no puede ser Nula.")]
        public string TipoDeAlimento
        {
            get
            {
                return this._TipoDeAlimento;
            }
            set
            {
                this._TipoDeAlimento = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad OrdenDeVisualizacion no puede ser Nula.")]
        public int OrdenDeVisualizacion
        {
            get
            {
                return this._OrdenDeVisualizacion;
            }
            set
            {
                this._OrdenDeVisualizacion = value;
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

        public TipoDeAlimentosEntityInsert()
        {
        }

        public TipoDeAlimentosEntityInsert(string oTipoDeAlimento, int oOrdenDeVisualizacion, string oEstado)
        {
            this.TipoDeAlimento = oTipoDeAlimento;
            this.OrdenDeVisualizacion = oOrdenDeVisualizacion;
            this.Estado = oEstado;
        }

        public TipoDeAlimentosEntityInsert(TipoDeAlimentosEntityInfo EntityInfo)
        {
            this.TipoDeAlimento = EntityInfo.TipoDeAlimento;
            this.OrdenDeVisualizacion = EntityInfo.OrdenDeVisualizacion;
            this.Estado = EntityInfo.Estado;
        }

        public void LoadFromInfo(TipoDeAlimentosEntityInfo EntityInfo)
        {
            this.TipoDeAlimento = EntityInfo.TipoDeAlimento;
            this.OrdenDeVisualizacion = EntityInfo.OrdenDeVisualizacion;
            this.Estado = EntityInfo.Estado;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<TipoDeAlimentosEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad TipoDeAlimentosEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}

