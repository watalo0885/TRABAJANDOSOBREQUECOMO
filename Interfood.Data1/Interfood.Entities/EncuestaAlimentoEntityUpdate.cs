using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfood.Entities
{
    public class EncuestaAlimentoEntityUpdate
    {
        private int? _EncuestaNro;
        private int? _AlimentoId;
        private bool? _Nunca;
        private int? _VecesPorMes;
        private int? _VecesPorSemana;
        private int? _VecesPorDia;
        private bool? _PorcionPequeña;
        private bool? _PorcionMediana;
        private bool? _PorcionGrande;
        private Decimal? _TamañoPorcion;
        private Decimal? _Cantidad;

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

        public int? AlimentoId
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

        public EncuestaAlimentoEntityUpdate()
        {
            this.Clear();
        }

        public EncuestaAlimentoEntityUpdate(EncuestaAlimentoEntityInfo EntityInfo)
        {
            this.Clear();
            this.EncuestaNro = new int?(EntityInfo.EncuestaNro);
            this.AlimentoId = new int?(EntityInfo.AlimentoId);
            this.Nunca = EntityInfo.Nunca;
            this.VecesPorMes = EntityInfo.VecesPorMes;
            this.VecesPorSemana = EntityInfo.VecesPorSemana;
            this.VecesPorDia = EntityInfo.VecesPorDia;
            this.PorcionPequeña = EntityInfo.PorcionPequeña;
            this.PorcionMediana = EntityInfo.PorcionMediana;
            this.PorcionGrande = EntityInfo.PorcionGrande;
            this.TamañoPorcion = EntityInfo.TamañoPorcion;
            this.Cantidad = EntityInfo.Cantidad;
        }

        public void LoadFromInfo(EncuestaAlimentoEntityInfo EntityInfo)
        {
            this.Clear();
            this.EncuestaNro = new int?(EntityInfo.EncuestaNro);
            this.AlimentoId = new int?(EntityInfo.AlimentoId);
            this.Nunca = EntityInfo.Nunca;
            this.VecesPorMes = EntityInfo.VecesPorMes;
            this.VecesPorSemana = EntityInfo.VecesPorSemana;
            this.VecesPorDia = EntityInfo.VecesPorDia;
            this.PorcionPequeña = EntityInfo.PorcionPequeña;
            this.PorcionMediana = EntityInfo.PorcionMediana;
            this.PorcionGrande = EntityInfo.PorcionGrande;
            this.TamañoPorcion = EntityInfo.TamañoPorcion;
            this.Cantidad = EntityInfo.Cantidad;
        }

        public void Clear()
        {
            this.EncuestaNro = new int?();
            this.AlimentoId = new int?();
            this.Nunca = new bool?();
            this.VecesPorMes = new int?();
            this.VecesPorSemana = new int?();
            this.VecesPorDia = new int?();
            this.PorcionPequeña = new bool?();
            this.PorcionMediana = new bool?();
            this.PorcionGrande = new bool?();
            this.TamañoPorcion = new Decimal?();
            this.Cantidad = new Decimal?();
        }
    }
}

