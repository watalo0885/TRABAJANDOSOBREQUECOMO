using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfood.Entities
{
    public class AlimentoNutrienteEntityUpdate
    {
        private int? _AlimentoId;
        private int? _NutrienteId;
        private Decimal? _Cantidad;
        private string _FntID;

        
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

        public string FntID
        {
            get { return _FntID; }
            set { _FntID = value; }
        }


        public AlimentoNutrienteEntityUpdate()
        {
            this.Clear();
        }

        public AlimentoNutrienteEntityUpdate(AlimentoNutrienteEntityInfo EntityInfo)
        {
            this.Clear();
            this.AlimentoId = new int?(EntityInfo.AlimentoId);
            this.NutrienteId = new int?(EntityInfo.NutrienteId);
           this.Cantidad = EntityInfo.Cantidad;
           this.FntID = EntityInfo.FntID;
        }

        public void LoadFromInfo(AlimentoNutrienteEntityInfo EntityInfo)
        {
            this.Clear();
            this.AlimentoId = new int?(EntityInfo.AlimentoId);
            this.NutrienteId = new int?(EntityInfo.NutrienteId);
            this.Cantidad = EntityInfo.Cantidad;
            this.FntID = EntityInfo.FntID;
        }

        public void Clear()
        {
            this.AlimentoId = new int?();
            this.NutrienteId = new int?();
            this.Cantidad = new Decimal?();
            this.FntID = (string)null;
        }
    }
}
