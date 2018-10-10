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
    public class Listado_NutrientesPorAlimentosEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _EncuestaNro;
        private string _HistoriaClinica;
        private DateTime? _Fecha;
        private string _Sexo;
        private short? _Edad;
        private Decimal? _Peso;
        private Decimal? _Talla;
        private Decimal? _IMC;
        private string _TipoDeDieta;
        private string _Alimento;
        private Decimal? _CantidadAlimento;
        private string _Nutriente;
        private Decimal? _CantidadNutriente;
        private Guid _UserId;

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

        public string HistoriaClinica
        {
            get
            {
                return this._HistoriaClinica;
            }
            set
            {
                this._HistoriaClinica = value;
            }
        }

        public DateTime? Fecha
        {
            get
            {
                return this._Fecha;
            }
            set
            {
                this._Fecha = value;
            }
        }

        public string Sexo
        {
            get
            {
                return this._Sexo;
            }
            set
            {
                this._Sexo = value;
            }
        }

        public short? Edad
        {
            get
            {
                return this._Edad;
            }
            set
            {
                this._Edad = value;
            }
        }

        public Decimal? Peso
        {
            get
            {
                return this._Peso;
            }
            set
            {
                this._Peso = value;
            }
        }

        public Decimal? Talla
        {
            get
            {
                return this._Talla;
            }
            set
            {
                this._Talla = value;
            }
        }

        public Decimal? IMC
        {
            get
            {
                return this._IMC;
            }
            set
            {
                this._IMC = value;
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

        [NotNullValidator(MessageTemplate = "La propiedad Alimento no puede ser Nula.")]
        public string Alimento
        {
            get
            {
                return this._Alimento;
            }
            set
            {
                this._Alimento = value;
            }
        }

        public Decimal? CantidadAlimento
        {
            get
            {
                return this._CantidadAlimento;
            }
            set
            {
                this._CantidadAlimento = value;
            }
        }

        public string Nutriente
        {
            get
            {
                return this._Nutriente;
            }
            set
            {
                this._Nutriente = value;
            }
        }

        public Decimal? CantidadNutriente
        {
            get
            {
                return this._CantidadNutriente;
            }
            set
            {
                this._CantidadNutriente = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad UserId no puede ser Nula.")]
        public Guid UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                this._UserId = value;
            }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public Listado_NutrientesPorAlimentosEntityInfo()
        {
        }

        public Listado_NutrientesPorAlimentosEntityInfo(int oEncuestaNro, string oHistoriaClinica, DateTime? oFecha, string oSexo, short? oEdad, Decimal? oPeso, Decimal? oTalla, Decimal? oIMC, string oTipoDeDieta, string oAlimento, Decimal? oCantidadAlimento, string oNutriente, Decimal? oCantidadNutriente, Guid oUserId)
        {
            this.EncuestaNro = oEncuestaNro;
            this.HistoriaClinica = oHistoriaClinica;
            this.Fecha = oFecha;
            this.Sexo = oSexo;
            this.Edad = oEdad;
            this.Peso = oPeso;
            this.Talla = oTalla;
            this.IMC = oIMC;
            this.TipoDeDieta = oTipoDeDieta;
            this.Alimento = oAlimento;
            this.CantidadAlimento = oCantidadAlimento;
            this.Nutriente = oNutriente;
            this.CantidadNutriente = oCantidadNutriente;
            this.UserId = oUserId;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<Listado_NutrientesPorAlimentosEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad Listado_NutrientesPorAlimentosEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class Listado_NutrientesPorAlimentosEntityInfoList : IEnumerable
        {
            private Listado_NutrientesPorAlimentosEntityInfo[] _entitiesInfo;

            public Listado_NutrientesPorAlimentosEntityInfoList()
            {
                this._entitiesInfo = (Listado_NutrientesPorAlimentosEntityInfo[])null;
            }

            public Listado_NutrientesPorAlimentosEntityInfoList(Listado_NutrientesPorAlimentosEntityInfo[] pArray)
            {
                this._entitiesInfo = new Listado_NutrientesPorAlimentosEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new Listado_NutrientesPorAlimentosEntityInfo.Listado_NutrientesPorAlimentosEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class Listado_NutrientesPorAlimentosEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public Listado_NutrientesPorAlimentosEntityInfo[] _entitiesInfo;

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

            public Listado_NutrientesPorAlimentosEntityInfoEnum(Listado_NutrientesPorAlimentosEntityInfo[] list)
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

