﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers.Operators;
using System;

namespace Interfood.Entities
{
    [Serializable]
    public class aspnet_ExtendedPropertiesEntityFilter
    {
        private string _whereExtendido;
        private string _OrderBy;
        private Operadores_UniqueIdentifier _OpeUserId;
        private Guid? _UserId;
        private Operadores_VarChar _OpeApellido;
        private string _Apellido;
        private Operadores_VarChar _OpeNombres;
        private string _Nombres;
        private Operadores_VarChar _OpeEmpresa;
        private string _Empresa;
        private Operadores_Int _OpeLimiteDeEncuestas;
        private int? _LimiteDeEncuestas;
        private Operadores_VarChar _OpeTelefonoFijo1;
        private string _TelefonoFijo1;
        private Operadores_VarChar _OpeTelefonoFijo2;
        private string _TelefonoFijo2;
        private Operadores_VarChar _OpeFax;
        private string _Fax;
        private Operadores_VarChar _OpeCelular;
        private string _Celular;
        private Operadores_VarChar _OpeEmail;
        private string _Email;
        private Operadores_DateTime _OpeFechaAlta;
        private DateTime? _FechaAltaDesde;
        private DateTime? _FechaAltaHasta;

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

        public Operadores_VarChar OpeEmpresa
        {
            get
            {
                return this._OpeEmpresa;
            }
            set
            {
                this._OpeEmpresa = value;
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

        public Operadores_Int OpeLimiteDeEncuestas
        {
            get
            {
                return this._OpeLimiteDeEncuestas;
            }
            set
            {
                this._OpeLimiteDeEncuestas = value;
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

        public Operadores_VarChar OpeTelefonoFijo1
        {
            get
            {
                return this._OpeTelefonoFijo1;
            }
            set
            {
                this._OpeTelefonoFijo1 = value;
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

        public Operadores_VarChar OpeTelefonoFijo2
        {
            get
            {
                return this._OpeTelefonoFijo2;
            }
            set
            {
                this._OpeTelefonoFijo2 = value;
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

        public Operadores_VarChar OpeFax
        {
            get
            {
                return this._OpeFax;
            }
            set
            {
                this._OpeFax = value;
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

        public Operadores_VarChar OpeCelular
        {
            get
            {
                return this._OpeCelular;
            }
            set
            {
                this._OpeCelular = value;
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

        public Operadores_VarChar OpeEmail
        {
            get
            {
                return this._OpeEmail;
            }
            set
            {
                this._OpeEmail = value;
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

        public Operadores_DateTime OpeFechaAlta
        {
            get
            {
                return this._OpeFechaAlta;
            }
            set
            {
                this._OpeFechaAlta = value;
            }
        }

        public DateTime? FechaAltaDesde
        {
            get
            {
                return this._FechaAltaDesde;
            }
            set
            {
                this._FechaAltaDesde = value;
            }
        }

        public DateTime? FechaAltaHasta
        {
            get
            {
                return this._FechaAltaHasta;
            }
            set
            {
                this._FechaAltaHasta = value;
            }
        }

        public aspnet_ExtendedPropertiesEntityFilter()
        {
            this.Clear();
        }

        public void Clear()
        {
            this.WhereExtendido = (string)null;
            this.OrderBy = (string)null;
            this.OpeUserId = Operadores_UniqueIdentifier.Vacio;
            this.UserId = new Guid?();
            this.OpeApellido = Operadores_VarChar.Vacio;
            this.Apellido = (string)null;
            this.OpeNombres = Operadores_VarChar.Vacio;
            this.Nombres = (string)null;
            this.OpeEmpresa = Operadores_VarChar.Vacio;
            this.Empresa = (string)null;
            this.OpeLimiteDeEncuestas = Operadores_Int.Vacio;
            this.LimiteDeEncuestas = new int?();
            this.OpeTelefonoFijo1 = Operadores_VarChar.Vacio;
            this.TelefonoFijo1 = (string)null;
            this.OpeTelefonoFijo2 = Operadores_VarChar.Vacio;
            this.TelefonoFijo2 = (string)null;
            this.OpeFax = Operadores_VarChar.Vacio;
            this.Fax = (string)null;
            this.OpeCelular = Operadores_VarChar.Vacio;
            this.Celular = (string)null;
            this.OpeEmail = Operadores_VarChar.Vacio;
            this.Email = (string)null;
            this.OpeFechaAlta = Operadores_DateTime.Vacio;
            this.FechaAltaDesde = new DateTime?();
            this.FechaAltaHasta = new DateTime?();
        }
    }
}
