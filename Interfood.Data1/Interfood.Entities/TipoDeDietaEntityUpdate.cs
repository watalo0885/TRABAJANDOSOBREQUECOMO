using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Interfood.Entities
{
    public class TipoDeDietaEntityUpdate
    {
        private int? _TipoDeDietaId;
        private string _TipoDeDieta;

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

        public TipoDeDietaEntityUpdate()
        {
            this.Clear();
        }

        public TipoDeDietaEntityUpdate(TipoDeDietaEntityInfo EntityInfo)
        {
            this.Clear();
            this.TipoDeDieta = EntityInfo.TipoDeDieta;
        }

        public void LoadFromInfo(TipoDeDietaEntityInfo EntityInfo)
        {
            this.Clear();
            this.TipoDeDieta = EntityInfo.TipoDeDieta;
        }

        public void Clear()
        {
            this.TipoDeDietaId = new int?();
            this.TipoDeDieta = (string)null;
        }
    }
}

