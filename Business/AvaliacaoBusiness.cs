using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Business
{
    public class AvaliacaoBusiness
    {
        public string AvaliacaoValidaAdd(AvaliacaoModel dados)
        {
            if (!String.IsNullOrEmpty(dados.USUARIO_AVALIADOR) && dados.DATA_AVALIACAO != null  && dados.ID_AVALIACAO != 0 && dados.ID_ESTAB != 0 && dados.ID_NOTA_AVAL!= 0 && dados.ID_TIPO_AVAL!= 0)
            {
                return "OK";
            }                   
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

        ~AvaliacaoBusiness()
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
