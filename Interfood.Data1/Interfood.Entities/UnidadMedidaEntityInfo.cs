using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections;

namespace Interfood.Entities
{
    public class UnidadMedidaEntityInfo
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

        public UnidadMedidaEntityInfo()
        {
        }

        public UnidadMedidaEntityInfo(string oUDMId, string oNombre)
        {
            this.UDMId = oUDMId;
            this.Nombre = oNombre;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<UnidadMedidaEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad UnidadMedidaEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class UnidadMedidaEntityInfoList : IEnumerable
        {
            private UnidadMedidaEntityInfo[] _entitiesInfo;

            public UnidadMedidaEntityInfoList()
            {
                this._entitiesInfo = (UnidadMedidaEntityInfo[])null;
            }

            public UnidadMedidaEntityInfoList(UnidadMedidaEntityInfo[] pArray)
            {
                this._entitiesInfo = new UnidadMedidaEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new UnidadMedidaEntityInfo.UnidadMedidaEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class UnidadMedidaEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public UnidadMedidaEntityInfo[] _entitiesInfo;

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

            public UnidadMedidaEntityInfoEnum(UnidadMedidaEntityInfo[] list)
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

