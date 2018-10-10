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
    public class TipoDeDietaEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _TipoDeDietaId;
        private string _TipoDeDieta;

        [NotNullValidator(MessageTemplate = "La propiedad TipoDeDietaId no puede ser Nula.")]
        public int TipoDeDietaId
        {
            get
            {
                return this._TipoDeDietaId;
            }
            set
            {
                this._TipoDeDietaId = value;
            }
        }

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

        public TipoDeDietaEntityInfo()
        {
        }

        public TipoDeDietaEntityInfo(int oTipoDeDietaId, string oTipoDeDieta)
        {
            this.TipoDeDietaId = oTipoDeDietaId;
            this.TipoDeDieta = oTipoDeDieta;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<TipoDeDietaEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad TipoDeDietaEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class TipoDeDietaEntityInfoList : IEnumerable
        {
            private TipoDeDietaEntityInfo[] _entitiesInfo;

            public TipoDeDietaEntityInfoList()
            {
                this._entitiesInfo = (TipoDeDietaEntityInfo[])null;
            }

            public TipoDeDietaEntityInfoList(TipoDeDietaEntityInfo[] pArray)
            {
                this._entitiesInfo = new TipoDeDietaEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new TipoDeDietaEntityInfo.TipoDeDietaEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class TipoDeDietaEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public TipoDeDietaEntityInfo[] _entitiesInfo;

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

            public TipoDeDietaEntityInfoEnum(TipoDeDietaEntityInfo[] list)
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
