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
    public class EstabelecimentoRepository : AcessoDados, IEstabelecimentoRepository, IDisposable
    {
        private EstabelecimentoBusiness _estabelecimentoBusiness = new EstabelecimentoBusiness();
        private EstabelecimentoDbScripts dbScript = new EstabelecimentoDbScripts();
        public EstabelecimentoRepository() { Dispose(true); }

        public string EstabelecimentoAdd(EstabelecimentoModel dados)//CREATE
        {
            try
            {
                string retornoValidaAdd = _estabelecimentoBusiness.EstabelecimentoValidaAdd(dados);

                if (retornoValidaAdd != "OK")
                {
                    return retornoValidaAdd;
                }

                var execCadastro = Executar(dbScript.EstabelecimentoAdd(dados));

                dbScript.Dispose();
                _estabelecimentoBusiness.Dispose();
                return "Estabelecimento Cadastrado";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public IEnumerable<EstabelecimentoModel> EstabelecimentoGetAll()//READ
        {
            try
            {

                var getCadastro = Pesquisar<EstabelecimentoModel>(dbScript.EstabelecimentoGet());

                dbScript.Dispose();
                _estabelecimentoBusiness.Dispose();
                return getCadastro;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string EstabelecimentoUpd(EstabelecimentoModel dados)//UPDATE
        {
            try
            {

                var execCadastro = Executar(dbScript.EstabelecimentoUpd(dados));

                dbScript.Dispose();
                _estabelecimentoBusiness.Dispose();

                return "Dados = " + "Nome: " + dados.NOME_FANTASIA + " |" + " CEP: " + dados.CEP + "inseridos";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string EstabelecimentoDel(int id)//DELETE
        {
            try
            {

                var execCadastro = Executar(dbScript.EstabelecimentoDel(id));

                dbScript.Dispose();
                _estabelecimentoBusiness.Dispose();
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
