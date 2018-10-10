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
    public class AlimentoNutrienteEntityInsert
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _AlimentoId;
        private int _NutrienteId;
        private Decimal? _Cantidad;
        private string _FntID;

        
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


        public string FntID
        {
            get { return _FntID; }
            set { _FntID = value; }
        }


        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public AlimentoNutrienteEntityInsert()
        {
        }

        public AlimentoNutrienteEntityInsert(int oAlimentoId, int oNutrienteId, Decimal? oCantidad, string oFntID)
        {
            this.AlimentoId = oAlimentoId;
            this.NutrienteId = oNutrienteId;
            this.Cantidad = oCantidad;
            this.FntID = oFntID;
        }

        public AlimentoNutrienteEntityInsert(AlimentoNutrienteEntityInfo EntityInfo)
        {
            this.AlimentoId = EntityInfo.AlimentoId;
            this.NutrienteId = EntityInfo.NutrienteId;
            this.Cantidad = EntityInfo.Cantidad;
            this.FntID = EntityInfo.FntID;
        }

        public void LoadFromInfo(AlimentoNutrienteEntityInfo EntityInfo)
        {
            this.AlimentoId = EntityInfo.AlimentoId;
            this.NutrienteId = EntityInfo.NutrienteId;
            this.Cantidad = EntityInfo.Cantidad;
            this.FntID = EntityInfo.FntID;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<AlimentoNutrienteEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad AlimentoNutrienteEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}

