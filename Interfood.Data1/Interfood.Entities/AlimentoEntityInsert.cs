using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfood.Entities
{
    public class AlimentoEntityInsert
    {
        private StringBuilder _erroresQueInvalidanLaEntidad = new StringBuilder();
        private string _Codigo;
        private string _Nombre;
        private string _Tipo;
        private string _Estacional;
        private Decimal _Pequeña;
        private Decimal _Mediana;
        private Decimal _Grande;
        private string _Estado;
        private int? _TipoDeAlimentoId;
        private int? _OrdenDeVisualizacion;

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

        [NotNullValidator(MessageTemplate = "La propiedad Estacional no puede ser Nula.")]
        public string Estacional
        {
            get { return this._Estacional; }
            set { this._Estacional = value; }
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

        public string ErroresQueInvalidanLaEntidad
        {
            get
            {
                return this._erroresQueInvalidanLaEntidad.ToString();
            }
        }

        public AlimentoEntityInsert()
        {
        }

        public AlimentoEntityInsert(string oCodigo, string oNombre, string oTipo, string oEstacional, Decimal oPequeña, Decimal oMediana, Decimal oGrande, string oEstado, int? oTipoDeAlimentoId, int? oOrdenDeVisualizacion)
        {
            this.Codigo = oCodigo;
            this.Nombre = oNombre;
            this.Tipo = oTipo;
            this.Estacional = oEstacional;
            this.Pequeña = oPequeña;
            this.Mediana = oMediana;
            this.Grande = oGrande;
            this.Estado = oEstado;
            this.TipoDeAlimentoId = oTipoDeAlimentoId;
            this.OrdenDeVisualizacion = oOrdenDeVisualizacion;
        }

        public AlimentoEntityInsert(AlimentoEntityInfo EntityInfo)
        {
            this.Codigo = EntityInfo.Codigo;
            this.Nombre = EntityInfo.Nombre;
            this.Tipo = EntityInfo.Tipo;
            this.Estacional = EntityInfo.Estacional;
            this.Pequeña = EntityInfo.Pequeña;
            this.Mediana = EntityInfo.Mediana;
            this.Grande = EntityInfo.Grande;
            this.Estado = EntityInfo.Estado;
            this.TipoDeAlimentoId = EntityInfo.TipoDeAlimentoId;
            this.OrdenDeVisualizacion = EntityInfo.OrdenDeVisualizacion;
        }

        public void LoadFromInfo(AlimentoEntityInfo EntityInfo)
        {
            this.Codigo = EntityInfo.Codigo;
            this.Nombre = EntityInfo.Nombre;
            this.Tipo = EntityInfo.Tipo;
            this.Estacional = EntityInfo.Estacional;
            this.Pequeña = EntityInfo.Pequeña;
            this.Mediana = EntityInfo.Mediana;
            this.Grande = EntityInfo.Grande;
            this.Estado = EntityInfo.Estado;
            this.TipoDeAlimentoId = EntityInfo.TipoDeAlimentoId;
            this.OrdenDeVisualizacion = EntityInfo.OrdenDeVisualizacion;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<AlimentoEntityInsert>(this);
            if (validationResults.IsValid)
                return true;
            this._erroresQueInvalidanLaEntidad.AppendLine("La entidad AlimentoEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._erroresQueInvalidanLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }
    }
}
