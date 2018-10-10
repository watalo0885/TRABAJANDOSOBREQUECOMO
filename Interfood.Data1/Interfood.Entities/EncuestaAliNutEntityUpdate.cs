using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfood.Entities
{
    public class EncuestaAliNutEntityUpdate
    {
        private int? _EncuestaNro;
        private int? _AlimentoId;
        private int? _NutrienteId;
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

        public int? NutrienteId
        {
            get
            {
                return this._NutrienteId;
            }
            set
            {
                this._NutrienteId = value;
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

        public EncuestaAliNutEntityUpdate()
        {
            this.Clear();
        }

        public EncuestaAliNutEntityUpdate(EncuestaAliNutEntityInfo EntityInfo)
        {
            this.Clear();
            this.EncuestaNro = new int?(EntityInfo.EncuestaNro);
            this.AlimentoId = new int?(EntityInfo.AlimentoId);
            this.NutrienteId = new int?(EntityInfo.NutrienteId);
            this.Cantidad = EntityInfo.Cantidad;
        }

        public void LoadFromInfo(EncuestaAliNutEntityInfo EntityInfo)
        {
            this.Clear();
            this.EncuestaNro = new int?(EntityInfo.EncuestaNro);
            this.AlimentoId = new int?(EntityInfo.AlimentoId);
            this.NutrienteId = new int?(EntityInfo.NutrienteId);
            this.Cantidad = EntityInfo.Cantidad;
        }

        public void Clear()
        {
            this.EncuestaNro = new int?();
            this.AlimentoId = new int?();
            this.NutrienteId = new int?();
            this.Cantidad = new Decimal?();
        }
    }
}

