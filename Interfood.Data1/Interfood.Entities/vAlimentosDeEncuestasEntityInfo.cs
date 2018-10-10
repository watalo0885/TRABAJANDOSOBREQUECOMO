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
    public class vAlimentosDeEncuestasEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _Orden1;
        private int? _Orden2;
        private string _TipoDeAlimento;
        private string _AlimentoCodigo;
        private string _Nombre;
        private int _Nunca;
        private int _VM;
        private int _VS;
        private int _VD;
        private int _P;
        private int _M;
        private int _G;

        [NotNullValidator(MessageTemplate = "La propiedad Orden1 no puede ser Nula.")]
        public int Orden1
        {
            get
            {
                return this._Orden1;
            }
            set
            {
                this._Orden1 = value;
            }
        }

        public int? Orden2
        {
            get
            {
                return this._Orden2;
            }
            set
            {
                this._Orden2 = value;
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

        [NotNullValidator(MessageTemplate = "La propiedad AlimentoCodigo no puede ser Nula.")]
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

        [NotNullValidator(MessageTemplate = "La propiedad Nombre no puede ser Nula.")]
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

        [NotNullValidator(MessageTemplate = "La propiedad Nunca no puede ser Nula.")]
        public int Nunca
        {
            get
            {
                return this._Nunca;
            }
            set
            {
                this._Nunca = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad VM no puede ser Nula.")]
        public int VM
        {
            get
            {
                return this._VM;
            }
            set
            {
                this._VM = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad VS no puede ser Nula.")]
        public int VS
        {
            get
            {
                return this._VS;
            }
            set
            {
                this._VS = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad VD no puede ser Nula.")]
        public int VD
        {
            get
            {
                return this._VD;
            }
            set
            {
                this._VD = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad P no puede ser Nula.")]
        public int P
        {
            get
            {
                return this._P;
            }
            set
            {
                this._P = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad M no puede ser Nula.")]
        public int M
        {
            get
            {
                return this._M;
            }
            set
            {
                this._M = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad G no puede ser Nula.")]
        public int G
        {
            get
            {
                return this._G;
            }
            set
            {
                this._G = value;
            }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public vAlimentosDeEncuestasEntityInfo()
        {
        }

        public vAlimentosDeEncuestasEntityInfo(int oOrden1, int? oOrden2, string oTipoDeAlimento, string oAlimentoCodigo, string oNombre, int oNunca, int oVM, int oVS, int oVD, int oP, int oM, int oG)
        {
            this.Orden1 = oOrden1;
            this.Orden2 = oOrden2;
            this.TipoDeAlimento = oTipoDeAlimento;
            this.AlimentoCodigo = oAlimentoCodigo;
            this.Nombre = oNombre;
            this.Nunca = oNunca;
            this.VM = oVM;
            this.VS = oVS;
            this.VD = oVD;
            this.P = oP;
            this.M = oM;
            this.G = oG;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<vAlimentosDeEncuestasEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad vAlimentosDeEncuestasEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class vAlimentosDeEncuestasEntityInfoList : IEnumerable
        {
            private vAlimentosDeEncuestasEntityInfo[] _entitiesInfo;

            public vAlimentosDeEncuestasEntityInfoList()
            {
                this._entitiesInfo = (vAlimentosDeEncuestasEntityInfo[])null;
            }

            public vAlimentosDeEncuestasEntityInfoList(vAlimentosDeEncuestasEntityInfo[] pArray)
            {
                this._entitiesInfo = new vAlimentosDeEncuestasEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new vAlimentosDeEncuestasEntityInfo.vAlimentosDeEncuestasEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class vAlimentosDeEncuestasEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public vAlimentosDeEncuestasEntityInfo[] _entitiesInfo;

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

            public vAlimentosDeEncuestasEntityInfoEnum(vAlimentosDeEncuestasEntityInfo[] list)
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
