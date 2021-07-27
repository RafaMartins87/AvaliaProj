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
    public class TipoAvaliacaoRepository : AcessoDados, ITipoAvaliacaoRepository, IDisposable
    {
        private TipoAvaliacaoBusiness _tipoAvaliacaoBusiness = new TipoAvaliacaoBusiness();
        private TipoAvaliacaoDbScripts dbScript = new TipoAvaliacaoDbScripts();
        public TipoAvaliacaoRepository() { Dispose(true); }

        public string TipoAvaliacaoAdd(TipoAvaliacaoModel dados)//CREATE
        {
            try
            {
                string retornoValidaAdd = _tipoAvaliacaoBusiness.TipoAvaliacaoValidaAdd(dados);

                if (retornoValidaAdd != "OK")
                {
                    return retornoValidaAdd;
                }

                var execCadastro = Executar(dbScript.TipoAvaliacaoAdd(dados));

                dbScript.Dispose();
                _tipoAvaliacaoBusiness.Dispose();
                return "TipoAvaliacao Cadastrado";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<TipoAvaliacaoModel> TipoAvaliacaoGetAll()//READ
        {
            try
            {

                var getCadastro = Pesquisar<TipoAvaliacaoModel>(dbScript.TipoAvaliacaoGetAll());

                dbScript.Dispose();
                _tipoAvaliacaoBusiness.Dispose();
                return getCadastro;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string TipoAvaliacaoUpd(TipoAvaliacaoModel dados)//UPDATE
        {
            try
            {

                var execCadastro = Executar(dbScript.TipoAvaliacaoUpd(dados));

                dbScript.Dispose();
                _tipoAvaliacaoBusiness.Dispose();

                return "Nome: " + dados.DESCR_TIPO_AVAL + "inseridos";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string TipoAvaliacaoDel(int id)//DELETE
        {
            try
            {

                var execCadastro = Executar(dbScript.TipoAvaliacaoDel(id));

                dbScript.Dispose();
                _tipoAvaliacaoBusiness.Dispose();
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
