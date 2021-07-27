using CadastrosGerais.Business;
using CadastrosGerais.Common;
using CadastrosGerais.DbScripts;
using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public class NotaAvaliacaoRepository : AcessoDados, INotaAvaliacaoRepository, IDisposable
    {
        private NotaAvaliacaoBusiness _notaAvaliacaoBusiness = new NotaAvaliacaoBusiness();
        private NotaAvaliacaoDbScripts dbScript = new NotaAvaliacaoDbScripts();
        public NotaAvaliacaoRepository() { Dispose(true); }

        public string NotaAvaliacaoAdd(NotaAvaliacaoModel dados)//CREATE
        {
            try
            {
                string retornoValidaAdd = _notaAvaliacaoBusiness.NotaAvaliacaoValidaAdd(dados);

                if (retornoValidaAdd != "OK")
                {
                    return retornoValidaAdd;
                }

                var execCadastro = Executar(dbScript.NotaAvaliacaoAdd(dados));

                dbScript.Dispose();
                _notaAvaliacaoBusiness.Dispose();
                return "NotaAvaliacao Cadastrado";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<NotaAvaliacaoModel> NotaAvaliacaoGetAll()//READ
        {
            try
            {

                var getCadastro = Pesquisar<NotaAvaliacaoModel>(dbScript.NotaAvaliacaoGetAll());

                dbScript.Dispose();
                _notaAvaliacaoBusiness.Dispose();
                return getCadastro;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string NotaAvaliacaoUpd(NotaAvaliacaoModel dados)//UPDATE
        {
            try
            {

                var execCadastro = Executar(dbScript.NotaAvaliacaoUpd(dados));

                dbScript.Dispose();
                _notaAvaliacaoBusiness.Dispose();

                return "Nome: " + dados.DESCR_NOTA_AVAL + " " + dados.VALOR_NOTA + "inseridos";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string NotaAvaliacaoDel(int id)//DELETE
        {
            try
            {

                var execCadastro = Executar(dbScript.NotaAvaliacaoDel(id));

                dbScript.Dispose();
                _notaAvaliacaoBusiness.Dispose();
                return "id = " + id + "deletado";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CadastroRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
