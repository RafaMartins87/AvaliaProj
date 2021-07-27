using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Business
{
    public class TipoAvaliacaoBusiness
    {
        public string TipoAvaliacaoValidaAdd(TipoAvaliacaoModel dados)
        {
            if (!String.IsNullOrEmpty(dados.DESCR_TIPO_AVAL)) return "OK";

            else
            {
                return "NOK";
            }
        }


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                { }

                disposedValue = true;
            }
        }

        ~TipoAvaliacaoBusiness()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
