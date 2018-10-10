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
    public class Listado_AlimentosPorEncuestasEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _EncuestaNro;
        private Guid _UserId;
        private string _Apellido;
        private string _Nombres;
        private string _Empresa;
        private string _HistoriaClinica;
        private DateTime? _Fecha;
        private string _Sexo;
        private short? _Edad;
        private Decimal? _Peso;
        private Decimal? _Talla;
        private Decimal? _IMC;
        private string _TipoDeDieta;
        private string _Nombre;
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

        [NotNullValidator(MessageTemplate = "La propiedad Apellido no puede ser Nula.")]
        public string Apellido
        {
            get
            {
                return this._Apellido;
            }
            set
            {
                this._Apellido = value;
            }
        }

        [NotNullValidator(MessageTemplate = "La propiedad Nombres no puede ser Nula.")]
        public string Nombres
        {
            get
            {
                return this._Nombres;
            }
            set
            {
                this._Nombres = value;
            }
        }

        public string Empresa
        {
            get
            {
                return this._Empresa;
            }
            set
            {
                this._Empresa = value;
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

        public Listado_AlimentosPorEncuestasEntityInfo()
        {
        }

        public Listado_AlimentosPorEncuestasEntityInfo(int oEncuestaNro, Guid oUserId, string oApellido, string oNombres, string oEmpresa, string oHistoriaClinica, DateTime? oFecha, string oSexo, short? oEdad, Decimal? oPeso, Decimal? oTalla, Decimal? oIMC, string oTipoDeDieta, string oNombre, Decimal? oCantidad)
        {
            this.EncuestaNro = oEncuestaNro;
            this.UserId = oUserId;
            this.Apellido = oApellido;
            this.Nombres = oNombres;
            this.Empresa = oEmpresa;
            this.HistoriaClinica = oHistoriaClinica;
            this.Fecha = oFecha;
            this.Sexo = oSexo;
            this.Edad = oEdad;
            this.Peso = oPeso;
            this.Talla = oTalla;
            this.IMC = oIMC;
            this.TipoDeDieta = oTipoDeDieta;
            this.Nombre = oNombre;
            this.Cantidad = oCantidad;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<Listado_AlimentosPorEncuestasEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad Listado_AlimentosPorEncuestasEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class Listado_AlimentosPorEncuestasEntityInfoList : IEnumerable
        {
            private Listado_AlimentosPorEncuestasEntityInfo[] _entitiesInfo;

            public Listado_AlimentosPorEncuestasEntityInfoList()
            {
                this._entitiesInfo = (Listado_AlimentosPorEncuestasEntityInfo[])null;
            }

            public Listado_AlimentosPorEncuestasEntityInfoList(Listado_AlimentosPorEncuestasEntityInfo[] pArray)
            {
                this._entitiesInfo = new Listado_AlimentosPorEncuestasEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new Listado_AlimentosPorEncuestasEntityInfo.Listado_AlimentosPorEncuestasEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class Listado_AlimentosPorEncuestasEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public Listado_AlimentosPorEncuestasEntityInfo[] _entitiesInfo;

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

            public Listado_AlimentosPorEncuestasEntityInfoEnum(Listado_AlimentosPorEncuestasEntityInfo[] list)
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

