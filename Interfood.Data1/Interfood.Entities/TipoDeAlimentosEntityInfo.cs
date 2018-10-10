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
    public class TipoDeAlimentosEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _TipoDeAlimentoId;
        private string _TipoDeAlimento;
        private int _OrdenDeVisualizacion;
        private string _Estado;

        [NotNullValidator(MessageTemplate = "La propiedad TipoDeAlimentoId no puede ser Nula.")]
        public int TipoDeAlimentoId
        {
            get
            {
                return this._TipoDeAlimentoId;
            }
            set
            {
                this._TipoDeAlimentoId = value;
            }
        }

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

        public TipoDeAlimentosEntityInfo()
        {
        }

        public TipoDeAlimentosEntityInfo(int oTipoDeAlimentoId, string oTipoDeAlimento, int oOrdenDeVisualizacion, string oEstado)
        {
            this.TipoDeAlimentoId = oTipoDeAlimentoId;
            this.TipoDeAlimento = oTipoDeAlimento;
            this.OrdenDeVisualizacion = oOrdenDeVisualizacion;
            this.Estado = oEstado;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<TipoDeAlimentosEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad TipoDeAlimentosEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class TipoDeAlimentosEntityInfoList : IEnumerable
        {
            private TipoDeAlimentosEntityInfo[] _entitiesInfo;

            public TipoDeAlimentosEntityInfoList()
            {
                this._entitiesInfo = (TipoDeAlimentosEntityInfo[])null;
            }

            public TipoDeAlimentosEntityInfoList(TipoDeAlimentosEntityInfo[] pArray)
            {
                this._entitiesInfo = new TipoDeAlimentosEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new TipoDeAlimentosEntityInfo.TipoDeAlimentosEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class TipoDeAlimentosEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public TipoDeAlimentosEntityInfo[] _entitiesInfo;

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

            public TipoDeAlimentosEntityInfoEnum(TipoDeAlimentosEntityInfo[] list)
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

