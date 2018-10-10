using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Collections;

namespace Interfood.Entities
{
    public class FuenteEntityInfo
    {
        private StringBuilder _errorQueInvalidaLaEntidad = new StringBuilder();
        private string _FntID;
        private string _Nombre;

       
        [NotNullValidator(MessageTemplate = "La Propiedad FntID no puede ser Nula")]
        public string FntID
        {
            get { return this._FntID; }
            set { this._FntID = value; }
        }

        public string Nombre
        {
            get { return this._Nombre; }
            set { this._Nombre = value; }
        }

        public string ErroresQueInvalidanLaEntidad
        {
            get { return this._errorQueInvalidaLaEntidad.ToString(); }
        }

        public FuenteEntityInfo() { }

        public FuenteEntityInfo(string oFntID, string oNombre)
        {
            this.FntID = oFntID; 
            this.Nombre = oNombre;
        }

        public bool Validate()
        {
            short num = 1;
            ValidationResults validationResults = Microsoft.Practices.EnterpriseLibrary.Validation.Validation.Validate<FuenteEntityInfo>(this);
            if (validationResults.IsValid)
                return true;
            this._errorQueInvalidaLaEntidad.AppendLine("La entidad FuenteEntityInfo no es Valida");
            foreach (ValidationResult validationResult in (IEnumerable<ValidationResult>)validationResults)
                this._errorQueInvalidaLaEntidad.AppendLine(string.Format("{0} - {1}", (object)num++.ToString(), (object)validationResult.Message));
            return false;
        }

        public class FuenteEntityInfoList : IEnumerable
        {
            private FuenteEntityInfo[] _entitiesInfo;

            public FuenteEntityInfoList()
            {
                this._entitiesInfo = (FuenteEntityInfo[])null;
            }

            public FuenteEntityInfoList(FuenteEntityInfo[] pArray)
            {
                this._entitiesInfo = new FuenteEntityInfo[pArray.Length];
                for (int index = 0; index < pArray.Length; ++index)
                    this._entitiesInfo[index] = pArray[index];
            }

            public IEnumerable GetEnumerator() 
            {
                return (IEnumerable)new FuenteEntityInfo.FuenteEntityInfoEnum(this._entitiesInfo);
            }




            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }


            public class FuenteEntityInfoEnum : IEnumerator
            {
                private int position = -1;
                public FuenteEntityInfo[] _entitiesInfo;

                public object Current
                {
                    get
                    {
                        try
                        {
                            return (object)this._entitiesInfo[this.position];
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            throw new InvalidOperationException();
                        }
                    }
                 }

                public FuenteEntityInfoEnum(FuenteEntityInfo[] list)
                {
                    this._entitiesInfo = list;
            
                }

                public bool MoveNext()
                {
                    ++this.position;
                    return this.position < this._entitiesInfo.Length;
                }

                public void Reset()
                { this.position = -1; }

            }

        }

    }

