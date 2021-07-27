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
    public class AvaliacaoRepository : AcessoDados, IAvaliacaoRepository, IDisposable
    {
        private AvaliacaoBusiness _avaliacaoBusiness = new AvaliacaoBusiness();
        private AvaliacaoDbScripts dbScript = new AvaliacaoDbScripts();
        public AvaliacaoRepository() { Dispose(true); }

        public string AvaliacaoAdd(AvaliacaoModel dados)//CREATE
        {
            try
            {
                string retornoValidaAdd = _avaliacaoBusiness.AvaliacaoValidaAdd(dados);

                if (retornoValidaAdd != "OK")
                {
                    return retornoValidaAdd;
                }

                var execCadastro = Executar(dbScript.AvaliacaoAdd(dados));

                dbScript.Dispose();
                _avaliacaoBusiness.Dispose();
                return "Avaliacao Cadastrado";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<AvaliacaoModel> AvaliacaoGetAll()//READ
        {
            try
            {

                var getCadastro = Pesquisar<AvaliacaoModel>(dbScript.AvaliacaoGet());

                dbScript.Dispose();
                _avaliacaoBusiness.Dispose();
                return getCadastro;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string AvaliacaoUpd(AvaliacaoModel dados)//UPDATE
        {
            try
            {

                var execCadastro = Executar(dbScript.AvaliacaoUpd(dados));

                dbScript.Dispose();
                _avaliacaoBusiness.Dispose();

                return "Usuario: " + dados.USUARIO_AVALIADOR;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string AvaliacaoDel(int id)//DELETE
        {
            try
            {

                var execCadastro = Executar(dbScript.AvaliacaoDel(id));

                dbScript.Dispose();
                _avaliacaoBusiness.Dispose();
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
