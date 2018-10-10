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
    public class EncuestaAliNutEntityInsert
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _EncuestaNro;
        private int _AlimentoId;
        private int _NutrienteId;
        private Decimal? _Cantidad;

        [NotNullValidator(MessageTemplate = "La propiedad EncuestaNro no puede ser Nula.")]
        public int EncuestaNro
        {
            get
            {
                return this._EncuestaNro;
            }
            set
            {
                this._EncuestaNro = value;
            }
        }

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

        [NotNullValidator(MessageTemplate = "La propiedad NutrienteId no puede ser Nula.")]
        public int NutrienteId
        {
            get
            {
                return this._NutrienteId;
            }
            set
            {
                this._NutrienteId = value;
            }
        }

        public Decimal? Cantidad
        {
            get
            {
                return this._Cantidad;
            }
            set
            {
                this._Cantidad = value;
            }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public EncuestaAliNutEntityInsert()
        {
        }

        public EncuestaAliNutEntityInsert(int oEncuestaNro, int oAlimentoId, int oNutrienteId, Decimal? oCantidad)
        {
            this.EncuestaNro = oEncuestaNro;
            this.AlimentoId = oAlimentoId;
            this.NutrienteId = oNutrienteId;
            this.Cantidad = oCantidad;
        }

        public EncuestaAliNutEntityInsert(EncuestaAliNutEntityInfo EntityInfo)
        {
            this.EncuestaNro = EntityInfo.EncuestaNro;
            this.AlimentoId = EntityInfo.AlimentoId;
            this.NutrienteId = EntityInfo.NutrienteId;
            this.Cantidad = EntityInfo.Cantidad;
        }

        public void LoadFromInfo(EncuestaAliNutEntityInfo EntityInfo)
        {
            this.EncuestaNro = EntityInfo.EncuestaNro;
            this.AlimentoId = EntityInfo.AlimentoId;
            this.NutrienteId = EntityInfo.NutrienteId;
            this.Cantidad = EntityInfo.Cantidad;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<EncuestaAliNutEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad EncuestaAliNutEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}
