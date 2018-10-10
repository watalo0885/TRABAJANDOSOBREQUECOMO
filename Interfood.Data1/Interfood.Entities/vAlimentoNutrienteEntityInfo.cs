using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interfood.Entities
{
    public class vAlimentoNutrienteEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _AlimentoId;
        private string _AlimentoCodigo;
        private string _AlimentoNombre;
        private int _NutrienteId;
        private string _NutrienteNombre;
        private Decimal? _AlimentoNutrienteCantidad;
        private string _NutrienteUDMId;
        private int? _PerteneceA;

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

        public string AlimentoCodigo
        {
            get
            {
                return this._AlimentoCodigo;
            }
            set
            {
                this._AlimentoCodigo = value;
            }
        }

        public string AlimentoNombre
        {
            get
            {
                return this._AlimentoNombre;
            }
            set
            {
                this._AlimentoNombre = value;
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

        public string NutrienteNombre
        {
            get
            {
                return this._NutrienteNombre;
            }
            set
            {
                this._NutrienteNombre = value;
            }
        }

        public Decimal? AlimentoNutrienteCantidad
        {
            get
            {
                return this._AlimentoNutrienteCantidad;
            }
            set
            {
                this._AlimentoNutrienteCantidad = value;
            }
        }

        public string NutrienteUDMId
        {
            get
            {
                return this._NutrienteUDMId;
            }
            set
            {
                this._NutrienteUDMId = value;
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public vAlimentoNutrienteEntityInfo()
        {
        }

        public vAlimentoNutrienteEntityInfo(int oAlimentoId, string oAlimentoCodigo, string oAlimentoNombre, int oNutrienteId, string oNutrienteNombre, Decimal? oAlimentoNutrienteCantidad, string oNutrienteUDMId, int? oPerteneceA)
        {
            this.AlimentoId = oAlimentoId;
            this.AlimentoCodigo = oAlimentoCodigo;
            this.AlimentoNombre = oAlimentoNombre;
            this.NutrienteId = oNutrienteId;
            this.NutrienteNombre = oNutrienteNombre;
            this.AlimentoNutrienteCantidad = oAlimentoNutrienteCantidad;
            this.NutrienteUDMId = oNutrienteUDMId;
            this.PerteneceA = oPerteneceA;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<vAlimentoNutrienteEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad vAlimentoNutrienteEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class vAlimentoNutrienteEntityInfoList : IEnumerable
        {
            private vAlimentoNutrienteEntityInfo[] _entitiesInfo;

            public vAlimentoNutrienteEntityInfoList()
            {
                this._entitiesInfo = (vAlimentoNutrienteEntityInfo[])null;
            }

            public vAlimentoNutrienteEntityInfoList(vAlimentoNutrienteEntityInfo[] pArray)
            {
                this._entitiesInfo = new vAlimentoNutrienteEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new vAlimentoNutrienteEntityInfo.vAlimentoNutrienteEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class vAlimentoNutrienteEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public vAlimentoNutrienteEntityInfo[] _entitiesInfo;

            public object Current
            {
                get
                {
                    try
                    {
                        return (object)this._entitiesInfo[this.position];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public vAlimentoNutrienteEntityInfoEnum(vAlimentoNutrienteEntityInfo[] list)
            {
                this._entitiesInfo = list;
            }

            public bool MoveNext()
            {
                ++this.position;
                return this.position < this._entitiesInfo.Length;
            }

            public void Reset()
            {
                this.position = -1;
            }
        }
    }
}

