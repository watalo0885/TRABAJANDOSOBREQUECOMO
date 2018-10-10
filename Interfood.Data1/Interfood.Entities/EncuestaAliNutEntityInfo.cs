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
    public class EncuestaAliNutEntityInfo
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

        public EncuestaAliNutEntityInfo()
        {
        }

        public EncuestaAliNutEntityInfo(int oEncuestaNro, int oAlimentoId, int oNutrienteId, Decimal? oCantidad)
        {
            this.EncuestaNro = oEncuestaNro;
            this.AlimentoId = oAlimentoId;
            this.NutrienteId = oNutrienteId;
            this.Cantidad = oCantidad;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<EncuestaAliNutEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad EncuestaAliNutEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class EncuestaAliNutEntityInfoList : IEnumerable
        {
            private EncuestaAliNutEntityInfo[] _entitiesInfo;

            public EncuestaAliNutEntityInfoList()
            {
                this._entitiesInfo = (EncuestaAliNutEntityInfo[])null;
            }

            public EncuestaAliNutEntityInfoList(EncuestaAliNutEntityInfo[] pArray)
            {
                this._entitiesInfo = new EncuestaAliNutEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new EncuestaAliNutEntityInfo.EncuestaAliNutEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class EncuestaAliNutEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public EncuestaAliNutEntityInfo[] _entitiesInfo;

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

            public EncuestaAliNutEntityInfoEnum(EncuestaAliNutEntityInfo[] list)
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
