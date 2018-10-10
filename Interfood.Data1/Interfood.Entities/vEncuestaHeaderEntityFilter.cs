using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class vEncuestaHeaderEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_Int _OpeEncuestaNro;
        private int? _EncuestaNro;
        private Operadores_UniqueIdentifier _OpeUserId;
        private Guid? _UserId;
        private Operadores_VarChar _OpeApellido;
        private string _Apellido;
        private Operadores_VarChar _OpeNombres;
        private string _Nombres;
        private Operadores_VarChar _OpeHistoriaClinica;
        private string _HistoriaClinica;
        private Operadores_VarChar _OpeEncuestador;
        private string _Encuestador;
        private Operadores_DateTime _OpeFecha;
        private DateTime? _FechaDesde;
        private DateTime? _FechaHasta;
        private Operadores_VarChar _OpeApeNom;
        private string _ApeNom;
        private Operadores_VarChar _OpeDireccion;
        private string _Direccion;
        private Operadores_VarChar _OpeTelefono;
        private string _Telefono;
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
        private Operadores_Int _OpeTipoDeDietaId;
        private int? _TipoDeDietaId;
        private Operadores_VarChar _OpeTipoDeDieta;
        private string _TipoDeDieta;

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

        public Operadores_VarChar OpeApellido
        {
            get
            {
                return this._OpeApellido;
            }
            set
            {
                this._OpeApellido = value;
            }
        }

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

        public Operadores_VarChar OpeNombres
        {
            get
            {
                return this._OpeNombres;
            }
            set
            {
                this._OpeNombres = value;
            }
        }

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

        public Operadores_VarChar OpeEncuestador
        {
            get
            {
                return this._OpeEncuestador;
            }
            set
            {
                this._OpeEncuestador = value;
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

        public Operadores_VarChar OpeApeNom
        {
            get
            {
                return this._OpeApeNom;
            }
            set
            {
                this._OpeApeNom = value;
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

        public Operadores_VarChar OpeDireccion
        {
            get
            {
                return this._OpeDireccion;
            }
            set
            {
                this._OpeDireccion = value;
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

        public Operadores_VarChar OpeTelefono
        {
            get
            {
                return this._OpeTelefono;
            }
            set
            {
                this._OpeTelefono = value;
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

        public Operadores_Int OpeTipoDeDietaId
        {
            get
            {
                return this._OpeTipoDeDietaId;
            }
            set
            {
                this._OpeTipoDeDietaId = value;
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

        public vEncuestaHeaderEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeEncuestaNro = Operadores_Int.Vacio;
            this.EncuestaNro = new int?();
            this.OpeUserId = Operadores_UniqueIdentifier.Vacio;
            this.UserId = new Guid?();
            this.OpeApellido = Operadores_VarChar.Vacio;
            this.Apellido = (string)null;
            this.OpeNombres = Operadores_VarChar.Vacio;
            this.Nombres = (string)null;
            this.OpeHistoriaClinica = Operadores_VarChar.Vacio;
            this.HistoriaClinica = (string)null;
            this.OpeEncuestador = Operadores_VarChar.Vacio;
            this.Encuestador = (string)null;
            this.OpeFecha = Operadores_DateTime.Vacio;
            this.FechaDesde = new DateTime?();
            this.FechaHasta = new DateTime?();
            this.OpeApeNom = Operadores_VarChar.Vacio;
            this.ApeNom = (string)null;
            this.OpeDireccion = Operadores_VarChar.Vacio;
            this.Direccion = (string)null;
            this.OpeTelefono = Operadores_VarChar.Vacio;
            this.Telefono = (string)null;
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
            this.OpeTipoDeDietaId = Operadores_Int.Vacio;
            this.TipoDeDietaId = new int?();
            this.OpeTipoDeDieta = Operadores_VarChar.Vacio;
            this.TipoDeDieta = (string)null;
        }
    }
}

