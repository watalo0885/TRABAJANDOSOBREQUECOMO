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
    public class vEncuestaAlimentoEntityInfo
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private int _EncuestaNro;
        private int _AlimentoId;
        private string _Codigo;
        private string _Nombre;
        private bool? _Nunca;
        private int? _VecesPorMes;
        private int? _VecesPorSemana;
        private int? _VecesPorDia;
        private bool? _PorcionPequeña;
        private bool? _PorcionMediana;
        private bool? _PorcionGrande;
        private Decimal? _TamañoPorcion;
        private Decimal? _Cantidad;
        private Decimal _Pequeña;
        private Decimal _Mediana;
        private Decimal _Grande;
        private int? _TipoDeAlimentoId;
        private int? _OrdenDeVisualizacion;
        private string _Estado;
        private string _Tipo;

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

        public string Tipo
        {
            get
            {
                return this._Tipo;
            }
            set
            {
                this._Tipo = value;
            }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public vEncuestaAlimentoEntityInfo()
        {
        }

        public vEncuestaAlimentoEntityInfo(int oEncuestaNro, int oAlimentoId, string oCodigo, string oNombre, bool? oNunca, int? oVecesPorMes, int? oVecesPorSemana, int? oVecesPorDia, bool? oPorcionPequeña, bool? oPorcionMediana, bool? oPorcionGrande, Decimal? oTamañoPorcion, Decimal? oCantidad, Decimal oPequeña, Decimal oMediana, Decimal oGrande, int? oTipoDeAlimentoId, int? oOrdenDeVisualizacion, string oEstado, string oTipo)
        {
            this.EncuestaNro = oEncuestaNro;
            this.AlimentoId = oAlimentoId;
            this.Codigo = oCodigo;
            this.Nombre = oNombre;
            this.Nunca = oNunca;
            this.VecesPorMes = oVecesPorMes;
            this.VecesPorSemana = oVecesPorSemana;
            this.VecesPorDia = oVecesPorDia;
            this.PorcionPequeña = oPorcionPequeña;
            this.PorcionMediana = oPorcionMediana;
            this.PorcionGrande = oPorcionGrande;
            this.TamañoPorcion = oTamañoPorcion;
            this.Cantidad = oCantidad;
            this.Pequeña = oPequeña;
            this.Mediana = oMediana;
            this.Grande = oGrande;
            this.TipoDeAlimentoId = oTipoDeAlimentoId;
            this.OrdenDeVisualizacion = oOrdenDeVisualizacion;
            this.Estado = oEstado;
            this.Tipo = oTipo;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<vEncuestaAlimentoEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad vEncuestaAlimentoEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class vEncuestaAlimentoEntityInfoList : IEnumerable
        {
            private vEncuestaAlimentoEntityInfo[] _entitiesInfo;

            public vEncuestaAlimentoEntityInfoList()
            {
                this._entitiesInfo = (vEncuestaAlimentoEntityInfo[])null;
            }

            public vEncuestaAlimentoEntityInfoList(vEncuestaAlimentoEntityInfo[] pArray)
            {
                this._entitiesInfo = new vEncuestaAlimentoEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new vEncuestaAlimentoEntityInfo.vEncuestaAlimentoEntityInfoEnum(this._entitiesInfo);
            }
        }

        public class vEncuestaAlimentoEntityInfoEnum : IEnumerator
        {
            private int position = -1;
            public vEncuestaAlimentoEntityInfo[] _entitiesInfo;

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

            public vEncuestaAlimentoEntityInfoEnum(vEncuestaAlimentoEntityInfo[] list)
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

