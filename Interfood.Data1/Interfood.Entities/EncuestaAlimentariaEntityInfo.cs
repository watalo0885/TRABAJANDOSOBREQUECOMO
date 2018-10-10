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
    public class EncuestaAlimentariaEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _EncuestaNro;
        private Guid _UserId;
        private string _HistoriaClinica;
        private string _Encuestador;
        private DateTime? _Fecha;
        private string _ApeNom;
        private string _Direccion;
        private string _Telefono;
        private string _Sexo;
        private short? _Edad;
        private Decimal? _Peso;
        private Decimal? _Talla;
        private Decimal? _IMC;
        private int? _TipoDeDietaId;

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

        public string Encuestador
        {
            get
            {
                return this._Encuestador;
            }
            set
            {
                this._Encuestador = value;
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

        public string ApeNom
        {
            get
            {
                return this._ApeNom;
            }
            set
            {
                this._ApeNom = value;
            }
        }

        public string Direccion
        {
            get
            {
                return this._Direccion;
            }
            set
            {
                this._Direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return this._Telefono;
            }
            set
            {
                this._Telefono = value;
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

        public int? TipoDeDietaId
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public EncuestaAlimentariaEntityInfo()
        {
        }

        public EncuestaAlimentariaEntityInfo(int oEncuestaNro, Guid oUserId, string oHistoriaClinica, string oEncuestador, DateTime? oFecha, string oApeNom, string oDireccion, string oTelefono, string oSexo, short? oEdad, Decimal? oPeso, Decimal? oTalla, Decimal? oIMC, int? oTipoDeDietaId)
        {
            this.EncuestaNro = oEncuestaNro;
            this.UserId = oUserId;
            this.HistoriaClinica = oHistoriaClinica;
            this.Encuestador = oEncuestador;
            this.Fecha = oFecha;
            this.ApeNom = oApeNom;
            this.Direccion = oDireccion;
            this.Telefono = oTelefono;
            this.Sexo = oSexo;
            this.Edad = oEdad;
            this.Peso = oPeso;
            this.Talla = oTalla;
            this.IMC = oIMC;
            this.TipoDeDietaId = oTipoDeDietaId;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<EncuestaAlimentariaEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad EncuestaAlimentariaEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class EncuestaAlimentariaEntityInfoList : IEnumerable
        {
            private EncuestaAlimentariaEntityInfo[] _entitiesInfo;

            public EncuestaAlimentariaEntityInfoList()
            {
                this._entitiesInfo = (EncuestaAlimentariaEntityInfo[])null;
            }

            public EncuestaAlimentariaEntityInfoList(EncuestaAlimentariaEntityInfo[] pArray)
            {
                this._entitiesInfo = new EncuestaAlimentariaEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new EncuestaAlimentariaEntityInfo.EncuestaAlimentariaEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class EncuestaAlimentariaEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public EncuestaAlimentariaEntityInfo[] _entitiesInfo;

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

            public EncuestaAlimentariaEntityInfoEnum(EncuestaAlimentariaEntityInfo[] list)
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

