using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Business
{
    public class EstabelecimentoBusiness
    {
        public string EstabelecimentoValidaAdd(EstabelecimentoModel dados)
        {
            if (!String.IsNullOrEmpty(dados.CEP)) return "OK";
            if (!String.IsNullOrEmpty(dados.ENDERECO)) return "OK";
            if (!String.IsNullOrEmpty(dados.NOME_FANTASIA)) return "OK";

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

        ~EstabelecimentoBusiness()
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
