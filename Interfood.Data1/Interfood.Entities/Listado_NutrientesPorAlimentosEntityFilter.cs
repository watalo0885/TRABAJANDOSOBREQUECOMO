using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class Listado_NutrientesPorAlimentosEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeEncuestaNro;
        private int? _EncuestaNro;
        private Operadores_VarChar _OpeHistoriaClinica;
        private string _HistoriaClinica;
        private Operadores_DateTime _OpeFecha;
        private DateTime? _FechaDesde;
        private DateTime? _FechaHasta;
        private Operadores_VarChar _OpeSexo;
        private string _Sexo;
        private Operadores_SmallInt _OpeEdad;
        private short? _Edad;
        private Operadores_Numeric _OpePeso;
        private Decimal? _Peso;
        private Operadores_Numeric _OpeTalla;
        private Decimal? _Talla;
        private Operadores_Numeric _OpeIMC;
        private Decimal? _IMC;
        private Operadores_VarChar _OpeTipoDeDieta;
        private string _TipoDeDieta;
        private Operadores_VarChar _OpeAlimento;
        private string _Alimento;
        private Operadores_Numeric _OpeCantidadAlimento;
        private Decimal? _CantidadAlimento;
        private Operadores_VarChar _OpeNutriente;
        private string _Nutriente;
        private Operadores_Numeric _OpeCantidadNutriente;
        private Decimal? _CantidadNutriente;
        private Operadores_UniqueIdentifier _OpeUserId;
        private Guid? _UserId;

        public string WhereExtendido
        {
            get
            {
                return this._whereExtendido;
            }
            set
            {
                this._whereExtendido = value;
            }
        }

        public string OrderBy
        {
            get
            {
                return this._OrderBy;
            }
            set
            {
                this._OrderBy = value;
            }
        }

        public Operadores_Int OpeEncuestaNro
        {
            get
            {
                return this._OpeEncuestaNro;
            }
            set
            {
                this._OpeEncuestaNro = value;
            }
        }

        public int? EncuestaNro
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

        public Operadores_VarChar OpeHistoriaClinica
        {
            get
            {
                return this._OpeHistoriaClinica;
            }
            set
            {
                this._OpeHistoriaClinica = value;
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

        public Operadores_DateTime OpeFecha
        {
            get
            {
                return this._OpeFecha;
            }
            set
            {
                this._OpeFecha = value;
            }
        }

        public DateTime? FechaDesde
        {
            get
            {
                return this._FechaDesde;
            }
            set
            {
                this._FechaDesde = value;
            }
        }

        public DateTime? FechaHasta
        {
            get
            {
                return this._FechaHasta;
            }
            set
            {
                this._FechaHasta = value;
            }
        }

        public Operadores_VarChar OpeSexo
        {
            get
            {
                return this._OpeSexo;
            }
            set
            {
                this._OpeSexo = value;
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

        public Operadores_SmallInt OpeEdad
        {
            get
            {
                return this._OpeEdad;
            }
            set
            {
                this._OpeEdad = value;
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

        public Operadores_Numeric OpePeso
        {
            get
            {
                return this._OpePeso;
            }
            set
            {
                this._OpePeso = value;
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

        public Operadores_Numeric OpeTalla
        {
            get
            {
                return this._OpeTalla;
            }
            set
            {
                this._OpeTalla = value;
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

        public Operadores_Numeric OpeIMC
        {
            get
            {
                return this._OpeIMC;
            }
            set
            {
                this._OpeIMC = value;
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

        public Operadores_VarChar OpeTipoDeDieta
        {
            get
            {
                return this._OpeTipoDeDieta;
            }
            set
            {
                this._OpeTipoDeDieta = value;
            }
        }

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

        public Operadores_VarChar OpeAlimento
        {
            get
            {
                return this._OpeAlimento;
            }
            set
            {
                this._OpeAlimento = value;
            }
        }

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

        public Operadores_Numeric OpeCantidadAlimento
        {
            get
            {
                return this._OpeCantidadAlimento;
            }
            set
            {
                this._OpeCantidadAlimento = value;
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

        public Operadores_VarChar OpeNutriente
        {
            get
            {
                return this._OpeNutriente;
            }
            set
            {
                this._OpeNutriente = value;
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

        public Operadores_Numeric OpeCantidadNutriente
        {
            get
            {
                return this._OpeCantidadNutriente;
            }
            set
            {
                this._OpeCantidadNutriente = value;
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

        public Operadores_UniqueIdentifier OpeUserId
        {
            get
            {
                return this._OpeUserId;
            }
            set
            {
                this._OpeUserId = value;
            }
        }

        public Guid? UserId
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

        public Listado_NutrientesPorAlimentosEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeEncuestaNro = Operadores_Int.Vacio;
            this.EncuestaNro = new int?();
            this.OpeHistoriaClinica = Operadores_VarChar.Vacio;
            this.HistoriaClinica = (string)null;
            this.OpeFecha = Operadores_DateTime.Vacio;
            this.FechaDesde = new DateTime?();
            this.FechaHasta = new DateTime?();
            this.OpeSexo = Operadores_VarChar.Vacio;
            this.Sexo = (string)null;
            this.OpeEdad = Operadores_SmallInt.Vacio;
            this.Edad = new short?();
            this.OpePeso = Operadores_Numeric.Vacio;
            this.Peso = new Decimal?();
            this.OpeTalla = Operadores_Numeric.Vacio;
            this.Talla = new Decimal?();
            this.OpeIMC = Operadores_Numeric.Vacio;
            this.IMC = new Decimal?();
            this.OpeTipoDeDieta = Operadores_VarChar.Vacio;
            this.TipoDeDieta = (string)null;
            this.OpeAlimento = Operadores_VarChar.Vacio;
            this.Alimento = (string)null;
            this.OpeCantidadAlimento = Operadores_Numeric.Vacio;
            this.CantidadAlimento = new Decimal?();
            this.OpeNutriente = Operadores_VarChar.Vacio;
            this.Nutriente = (string)null;
            this.OpeCantidadNutriente = Operadores_Numeric.Vacio;
            this.CantidadNutriente = new Decimal?();
            this.OpeUserId = Operadores_UniqueIdentifier.Vacio;
            this.UserId = new Guid?();
        }
    }
}

