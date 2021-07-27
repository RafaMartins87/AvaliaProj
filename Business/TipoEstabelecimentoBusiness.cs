using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Business
{
    public class TipoEstabelecimentoBusiness
    {
        public string TipoEstabelecimentoValidaAdd(TipoEstabelecimentoModel dados)
        {
            if (!String.IsNullOrEmpty(dados.DESCR_TIPO_ESTAB)) return "OK";

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

        ~TipoEstabelecimentoBusiness()
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
