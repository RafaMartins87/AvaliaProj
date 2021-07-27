using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.DbScripts
{
    public class EstabelecimentoDbScripts
    {
        public Dictionary<string, object> EstabelecimentoAdd(EstabelecimentoModel dados)
        {
            string SQL = @"INSERT INTO TB_ESTABELECIMENTO 
                            VALUES (@NOME_FANTASIA, @CEP, @ENDERECO)";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public string EstabelecimentoGet()
        {
            string SQL = "SELECT ID, NOME, EMAIL FROM TB_CADASTRO";

            return SQL;
        }

        public Dictionary<string, object> EstabelecimentoUpd(EstabelecimentoModel dados)
        {
            string SQL = "UPDATE TB_CADASTRO SET NOME = @NOME, EMAIL = @EMAIL WHERE ID = @ID";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public Dictionary<string, object> EstabelecimentoDel(int id)
        {
            string SQL = "DELETE FROM TB_CADASTRO WHERE ID = @ID";

            return new Dictionary<string, object>() { { SQL, new { id = id } } };
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

        ~EstabelecimentoDbScripts()
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
