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
    public class vAlimentosEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _AlimentoId;
        private string _Codigo;
        private string _Nombre;
        private int? _TipoDeAlimentoId;
        private string _TipoDeAlimento;
        private string _Estacional;
        private Decimal _Pequeña;
        private Decimal _Mediana;
        private Decimal _Grande;
        private string _Estado;
        private int? _OrdenDeVisualizacion;

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

        [NotNullValidator(MessageTemplate = "La propiedad Codigo no puede ser Nula.")]
        public string Codigo
        {
            get
            {
                return this._Codigo;
            }
            set
            {
                this._Codigo = value;
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

        public int? TipoDeAlimentoId
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

        [NotNullValidator(MessageTemplate = "La propiedad Estacional no puede ser Nula.")]
        public string Estacional
        {
            get { return this._Estacional; }
            set { this._Estacional = value; }
        }

        [NotNullValidator(MessageTemplate = "La propiedad Pequeña no puede ser Nula.")]
        public Decimal Pequeña
        {
            get
            {
                return this._Pequeña;
            }
            set
            {
                this._Pequeña = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad Mediana no puede ser Nula.")]
        public Decimal Mediana
        {
            get
            {
                return this._Mediana;
            }
            set
            {
                this._Mediana = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad Grande no puede ser Nula.")]
        public Decimal Grande
        {
            get
            {
                return this._Grande;
            }
            set
            {
                this._Grande = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad Estado no puede ser Nula.")]
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

        public int? OrdenDeVisualizacion
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public vAlimentosEntityInfo()
        {
        }

        public vAlimentosEntityInfo(int oAlimentoId, string oCodigo, string oNombre, int? oTipoDeAlimentoId, string oTipoDeAlimento, string oEstacional, Decimal oPequeña, Decimal oMediana, Decimal oGrande, string oEstado, int? oOrdenDeVisualizacion)
        {
            this.AlimentoId = oAlimentoId;
            this.Codigo = oCodigo;
            this.Nombre = oNombre;
            this.TipoDeAlimentoId = oTipoDeAlimentoId;
            this.TipoDeAlimento = oTipoDeAlimento;
            this.Estacional = oEstacional;
            this.Pequeña = oPequeña;
            this.Mediana = oMediana;
            this.Grande = oGrande;
            this.Estado = oEstado;
            this.OrdenDeVisualizacion = oOrdenDeVisualizacion;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<vAlimentosEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad vAlimentosEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class vAlimentosEntityInfoList : IEnumerable
        {
            private vAlimentosEntityInfo[] _entitiesInfo;

            public vAlimentosEntityInfoList()
            {
                this._entitiesInfo = (vAlimentosEntityInfo[])null;
            }

            public vAlimentosEntityInfoList(vAlimentosEntityInfo[] pArray)
            {
                this._entitiesInfo = new vAlimentosEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new vAlimentosEntityInfo.vAlimentosEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class vAlimentosEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public vAlimentosEntityInfo[] _entitiesInfo;

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

            public vAlimentosEntityInfoEnum(vAlimentosEntityInfo[] list)
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
