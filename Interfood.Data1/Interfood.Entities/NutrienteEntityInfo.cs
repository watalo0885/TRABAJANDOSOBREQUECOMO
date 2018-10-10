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
    public class NutrienteEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _NutrienteId;
        private string _Nombre;
        private string _UDMId;
        private int? _PerteneceA;
        private string _Estado;

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

        public NutrienteEntityInfo()
        {
        }

        public NutrienteEntityInfo(int oNutrienteId, string oNombre, string oUDMId, int? oPerteneceA, string oEstado)
        {
            this.NutrienteId = oNutrienteId;
            this.Nombre = oNombre;
            this.UDMId = oUDMId;
            this.PerteneceA = oPerteneceA;
            this.Estado = oEstado;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<NutrienteEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad NutrienteEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class NutrienteEntityInfoList : IEnumerable
        {
            private NutrienteEntityInfo[] _entitiesInfo;

            public NutrienteEntityInfoList()
            {
                this._entitiesInfo = (NutrienteEntityInfo[])null;
            }

            public NutrienteEntityInfoList(NutrienteEntityInfo[] pArray)
            {
                this._entitiesInfo = new NutrienteEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new NutrienteEntityInfo.NutrienteEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class NutrienteEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public NutrienteEntityInfo[] _entitiesInfo;

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

            public NutrienteEntityInfoEnum(NutrienteEntityInfo[] list)
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

