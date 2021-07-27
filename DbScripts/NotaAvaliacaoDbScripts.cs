using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.DbScripts
{
    public class NotaAvaliacaoDbScripts
    {
        public Dictionary<string, object> NotaAvaliacaoAdd(NotaAvaliacaoModel dados)
        {
            string SQL = @"INSERT INTO TB_NOTA_AVALIACAO 
                            VALUES (@DESCR_NOTA_AVAL, @VALOR_NOTA)";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public string NotaAvaliacaoGetAll()
        {
            string SQL = "SELECT * FROM TB_NOTA_AVALIACAO";

            return SQL;
        }

        public Dictionary<string, object> NotaAvaliacaoUpd(NotaAvaliacaoModel dados)
        {
            string SQL = "UPDATE TB_NOTA_AVALIACAO SET DESCR_NOTA_AVAL = @DESCR_NOTA_AVAL, VALOR_NOTA = @VALOR_NOTA WHERE ID = @ID";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public Dictionary<string, object> NotaAvaliacaoDel(int id)
        {
            string SQL = "DELETE FROM TB_NOTA_AVALIACAO WHERE ID = @ID";

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

        ~NotaAvaliacaoDbScripts()
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
