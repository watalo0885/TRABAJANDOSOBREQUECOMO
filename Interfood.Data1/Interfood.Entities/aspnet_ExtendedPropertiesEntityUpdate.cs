using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Interfood.Entities
{
    public class aspnet_ExtendedPropertiesEntityUpdate
    {
        private Guid? _UserId;
        private string _Apellido;
        private string _Nombres;
        private string _Empresa;
        private int? _LimiteDeEncuestas;
        private string _TelefonoFijo1;
        private string _TelefonoFijo2;
        private string _Fax;
        private string _Celular;
        private string _Email;
        private DateTime? _FechaAlta;

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

        public int? LimiteDeEncuestas
        {
            get
            {
                return this._LimiteDeEncuestas;
            }
            set
            {
                this._LimiteDeEncuestas = value;
            }
        }

        public string TelefonoFijo1
        {
            get
            {
                return this._TelefonoFijo1;
            }
            set
            {
                this._TelefonoFijo1 = value;
            }
        }

        public string TelefonoFijo2
        {
            get
            {
                return this._TelefonoFijo2;
            }
            set
            {
                this._TelefonoFijo2 = value;
            }
        }

        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                this._Fax = value;
            }
        }

        public string Celular
        {
            get
            {
                return this._Celular;
            }
            set
            {
                this._Celular = value;
            }
        }

        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }

        public DateTime? FechaAlta
        {
            get
            {
                return this._FechaAlta;
            }
            set
            {
                this._FechaAlta = value;
            }
        }

        public aspnet_ExtendedPropertiesEntityUpdate()
        {
            this.Clear();
        }

        public aspnet_ExtendedPropertiesEntityUpdate(aspnet_ExtendedPropertiesEntityInfo EntityInfo)
        {
            this.Clear();
            this.UserId = new Guid?(EntityInfo.UserId);
            this.Apellido = EntityInfo.Apellido;
            this.Nombres = EntityInfo.Nombres;
            this.Empresa = EntityInfo.Empresa;
            this.LimiteDeEncuestas = new int?(EntityInfo.LimiteDeEncuestas);
            this.TelefonoFijo1 = EntityInfo.TelefonoFijo1;
            this.TelefonoFijo2 = EntityInfo.TelefonoFijo2;
            this.Fax = EntityInfo.Fax;
            this.Celular = EntityInfo.Celular;
            this.Email = EntityInfo.Email;
            this.FechaAlta = new DateTime?(EntityInfo.FechaAlta);
        }

        public void LoadFromInfo(aspnet_ExtendedPropertiesEntityInfo EntityInfo)
        {
            this.Clear();
            this.UserId = new Guid?(EntityInfo.UserId);
            this.Apellido = EntityInfo.Apellido;
            this.Nombres = EntityInfo.Nombres;
            this.Empresa = EntityInfo.Empresa;
            this.LimiteDeEncuestas = new int?(EntityInfo.LimiteDeEncuestas);
            this.TelefonoFijo1 = EntityInfo.TelefonoFijo1;
            this.TelefonoFijo2 = EntityInfo.TelefonoFijo2;
            this.Fax = EntityInfo.Fax;
            this.Celular = EntityInfo.Celular;
            this.Email = EntityInfo.Email;
            this.FechaAlta = new DateTime?(EntityInfo.FechaAlta);
        }

        public void Clear()
        {
            this.UserId = new Guid?();
            this.Apellido = (string)null;
            this.Nombres = (string)null;
            this.Empresa = (string)null;
            this.LimiteDeEncuestas = new int?();
            this.TelefonoFijo1 = (string)null;
            this.TelefonoFijo2 = (string)null;
            this.Fax = (string)null;
            this.Celular = (string)null;
            this.Email = (string)null;
            this.FechaAlta = new DateTime?();
        }
    }
}
