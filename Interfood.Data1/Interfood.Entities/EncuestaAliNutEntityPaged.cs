﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Interfood.Entities
{
    public class EncuestaAliNutEntityPaged
    {
        private int _pageSize;
        private int _pageReturn;

        public int pageSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;
            }
        }

        public int pageReturn
        {
            get
            {
                return this._pageReturn;
            }
            set
            {
                this._pageReturn = value;
            }
        }

        public EncuestaAliNutEntityPaged()
        {
            try
            {
                this.pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                this.pageReturn = int.Parse(ConfigurationManager.AppSettings["PageReturn"]);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
        }

        public EncuestaAliNutEntityPaged(int oPageSize, int oPageReturn)
        {
            try
            {
                this.pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
                this.pageReturn = int.Parse(ConfigurationManager.AppSettings["PageReturn"]);
            }
            catch (Exception ex)
            {
                Helpers.Logger.Logger.LogExceptionStatic(ex);
                throw ex;
            }
            if (oPageSize > 0)
                this.pageSize = oPageSize;
            if (oPageReturn <= 0)
                return;
            this.pageReturn = oPageReturn;
        }
    }
}

