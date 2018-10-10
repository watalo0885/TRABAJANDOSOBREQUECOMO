using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Interfood.Entities
{
    public class EncuestaAlimentariaEntityUpdate
    {
        private int? _EncuestaNro;
        private Guid? _UserId;
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

        public EncuestaAlimentariaEntityUpdate()
        {
            this.Clear();
        }

        public EncuestaAlimentariaEntityUpdate(EncuestaAlimentariaEntityInfo EntityInfo)
        {
            this.Clear();
            this.UserId = new Guid?(EntityInfo.UserId);
            this.HistoriaClinica = EntityInfo.HistoriaClinica;
            this.Encuestador = EntityInfo.Encuestador;
            this.Fecha = EntityInfo.Fecha;
            this.ApeNom = EntityInfo.ApeNom;
            this.Direccion = EntityInfo.Direccion;
            this.Telefono = EntityInfo.Telefono;
            this.Sexo = EntityInfo.Sexo;
            this.Edad = EntityInfo.Edad;
            this.Peso = EntityInfo.Peso;
            this.Talla = EntityInfo.Talla;
            this.IMC = EntityInfo.IMC;
            this.TipoDeDietaId = EntityInfo.TipoDeDietaId;
        }

        public void LoadFromInfo(EncuestaAlimentariaEntityInfo EntityInfo)
        {
            this.Clear();
            this.UserId = new Guid?(EntityInfo.UserId);
            this.HistoriaClinica = EntityInfo.HistoriaClinica;
            this.Encuestador = EntityInfo.Encuestador;
            this.Fecha = EntityInfo.Fecha;
            this.ApeNom = EntityInfo.ApeNom;
            this.Direccion = EntityInfo.Direccion;
            this.Telefono = EntityInfo.Telefono;
            this.Sexo = EntityInfo.Sexo;
            this.Edad = EntityInfo.Edad;
            this.Peso = EntityInfo.Peso;
            this.Talla = EntityInfo.Talla;
            this.IMC = EntityInfo.IMC;
            this.TipoDeDietaId = EntityInfo.TipoDeDietaId;
        }

        public void Clear()
        {
            this.EncuestaNro = new int?();
            this.UserId = new Guid?();
            this.HistoriaClinica = (string)null;
            this.Encuestador = (string)null;
            this.Fecha = new DateTime?();
            this.ApeNom = (string)null;
            this.Direccion = (string)null;
            this.Telefono = (string)null;
            this.Sexo = (string)null;
            this.Edad = new short?();
            this.Peso = new Decimal?();
            this.Talla = new Decimal?();
            this.IMC = new Decimal?();
            this.TipoDeDietaId = new int?();
        }
    }
}

