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
    public class TipoEstabelecimentoRepository : AcessoDados, ITipoEstabelecimentoRepository, IDisposable
    {
        private TipoEstabelecimentoBusiness _tipoEstabelecimentoBusiness = new TipoEstabelecimentoBusiness();
        private TipoEstabelecimentoDbScripts dbScript = new TipoEstabelecimentoDbScripts();
        public TipoEstabelecimentoRepository() { Dispose(true); }

        public string TipoEstabelecimentoAdd(TipoEstabelecimentoModel dados)//CREATE
        {
            try
            {
                string retornoValidaAdd = _tipoEstabelecimentoBusiness.TipoEstabelecimentoValidaAdd(dados);

                if (retornoValidaAdd != "OK")
                {
                    return retornoValidaAdd;
                }

                var execCadastro = Executar(dbScript.TipoEstabelecimentoAdd(dados));

                dbScript.Dispose();
                _tipoEstabelecimentoBusiness.Dispose();
                return "TipoEstabelecimento Cadastrado";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<TipoEstabelecimentoModel> TipoEstabelecimentoGetAll()//READ
        {
            try
            {

                var getCadastro = Pesquisar<TipoEstabelecimentoModel>(dbScript.TipoEstabelecimentoGetAll());

                dbScript.Dispose();
                _tipoEstabelecimentoBusiness.Dispose();
                return getCadastro;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string TipoEstabelecimentoUpd(TipoEstabelecimentoModel dados)//UPDATE
        {
            try
            {

                var execCadastro = Executar(dbScript.TipoEstabelecimentoUpd(dados));

                dbScript.Dispose();
                _tipoEstabelecimentoBusiness.Dispose();

                return "Nome: " + dados.DESCR_TIPO_ESTAB + "inseridos";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string TipoEstabelecimentoDel(int id)//DELETE
        {
            try
            {

                var execCadastro = Executar(dbScript.TipoEstabelecimentoDel(id));

                dbScript.Dispose();
                _tipoEstabelecimentoBusiness.Dispose();
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
