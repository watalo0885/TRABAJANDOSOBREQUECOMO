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
    public class vAlimentoNutrienteParaAgregarEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _AlimentoId;
        private int _NutrienteId;
        private string _NutrienteNombre;
        private int _AlimentoNutrienteCantidad;
        private string _NutrienteUDMId;

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

        [NotNullValidator(MessageTemplate = "La propiedad AlimentoNutrienteCantidad no puede ser Nula.")]
        public int AlimentoNutrienteCantidad
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public vAlimentoNutrienteParaAgregarEntityInfo()
        {
        }

        public vAlimentoNutrienteParaAgregarEntityInfo(int oAlimentoId, int oNutrienteId, string oNutrienteNombre, int oAlimentoNutrienteCantidad, string oNutrienteUDMId)
        {
            this.AlimentoId = oAlimentoId;
            this.NutrienteId = oNutrienteId;
            this.NutrienteNombre = oNutrienteNombre;
            this.AlimentoNutrienteCantidad = oAlimentoNutrienteCantidad;
            this.NutrienteUDMId = oNutrienteUDMId;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<vAlimentoNutrienteParaAgregarEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad vAlimentoNutrienteParaAgregarEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class vAlimentoNutrienteParaAgregarEntityInfoList : IEnumerable
        {
            private vAlimentoNutrienteParaAgregarEntityInfo[] _entitiesInfo;

            public vAlimentoNutrienteParaAgregarEntityInfoList()
            {
                this._entitiesInfo = (vAlimentoNutrienteParaAgregarEntityInfo[])null;
            }

            public vAlimentoNutrienteParaAgregarEntityInfoList(vAlimentoNutrienteParaAgregarEntityInfo[] pArray)
            {
                this._entitiesInfo = new vAlimentoNutrienteParaAgregarEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new vAlimentoNutrienteParaAgregarEntityInfo.vAlimentoNutrienteParaAgregarEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class vAlimentoNutrienteParaAgregarEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public vAlimentoNutrienteParaAgregarEntityInfo[] _entitiesInfo;

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

            public vAlimentoNutrienteParaAgregarEntityInfoEnum(vAlimentoNutrienteParaAgregarEntityInfo[] list)
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
