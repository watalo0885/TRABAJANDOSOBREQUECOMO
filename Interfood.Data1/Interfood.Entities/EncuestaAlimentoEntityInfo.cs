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
    public class EncuestaAlimentoEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _EncuestaNro;
        private int _AlimentoId;
        private bool? _Nunca;
        private int? _VecesPorMes;
        private int? _VecesPorSemana;
        private int? _VecesPorDia;
        private bool? _PorcionPequeña;
        private bool? _PorcionMediana;
        private bool? _PorcionGrande;
        private Decimal? _TamañoPorcion;
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

        public bool? Nunca
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

        public int? VecesPorMes
        {
            get
            {
                return this._VecesPorMes;
            }
            set
            {
                this._VecesPorMes = value;
            }
        }

        public int? VecesPorSemana
        {
            get
            {
                return this._VecesPorSemana;
            }
            set
            {
                this._VecesPorSemana = value;
            }
        }

        public int? VecesPorDia
        {
            get
            {
                return this._VecesPorDia;
            }
            set
            {
                this._VecesPorDia = value;
            }
        }

        public bool? PorcionPequeña
        {
            get
            {
                return this._PorcionPequeña;
            }
            set
            {
                this._PorcionPequeña = value;
            }
        }

        public bool? PorcionMediana
        {
            get
            {
                return this._PorcionMediana;
            }
            set
            {
                this._PorcionMediana = value;
            }
        }

        public bool? PorcionGrande
        {
            get
            {
                return this._PorcionGrande;
            }
            set
            {
                this._PorcionGrande = value;
            }
        }

        public Decimal? TamañoPorcion
        {
            get
            {
                return this._TamañoPorcion;
            }
            set
            {
                this._TamañoPorcion = value;
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

        public EncuestaAlimentoEntityInfo()
        {
        }

        public EncuestaAlimentoEntityInfo(int oEncuestaNro, int oAlimentoId, bool? oNunca, int? oVecesPorMes, int? oVecesPorSemana, int? oVecesPorDia, bool? oPorcionPequeña, bool? oPorcionMediana, bool? oPorcionGrande, Decimal? oTamañoPorcion, Decimal? oCantidad)
        {
            this.EncuestaNro = oEncuestaNro;
            this.AlimentoId = oAlimentoId;
            this.Nunca = oNunca;
            this.VecesPorMes = oVecesPorMes;
            this.VecesPorSemana = oVecesPorSemana;
            this.VecesPorDia = oVecesPorDia;
            this.PorcionPequeña = oPorcionPequeña;
            this.PorcionMediana = oPorcionMediana;
            this.PorcionGrande = oPorcionGrande;
            this.TamañoPorcion = oTamañoPorcion;
            this.Cantidad = oCantidad;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<EncuestaAlimentoEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad EncuestaAlimentoEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class EncuestaAlimentoEntityInfoList : IEnumerable
        {
            private EncuestaAlimentoEntityInfo[] _entitiesInfo;

            public EncuestaAlimentoEntityInfoList()
            {
                this._entitiesInfo = (EncuestaAlimentoEntityInfo[])null;
            }

            public EncuestaAlimentoEntityInfoList(EncuestaAlimentoEntityInfo[] pArray)
            {
                this._entitiesInfo = new EncuestaAlimentoEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new EncuestaAlimentoEntityInfo.EncuestaAlimentoEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class EncuestaAlimentoEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public EncuestaAlimentoEntityInfo[] _entitiesInfo;

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

            public EncuestaAlimentoEntityInfoEnum(EncuestaAlimentoEntityInfo[] list)
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

