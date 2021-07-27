using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.DbScripts
{
    public class AvaliacaoDbScripts
    {
        public Dictionary<string, object> AvaliacaoAdd(AvaliacaoModel dados)
        {
            string SQL = @"INSERT INTO TB_AVALIACAO 
                            VALUES (@USUARIO_AVALIADOR, @DATA_AVALIACAO, @ID_ESTAB,@ID_TIPO_ESTAB, @ID_TIPO_AVAL, @ID_NOTA_AVAL)";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public string AvaliacaoGetAll()
        {
            string SQL = "SELECT * FROM TB_AVALIACAO";

            return SQL;
        }

        public Dictionary<string, object> AvaliacaoUpd(AvaliacaoModel dados)
        {
            string SQL = @"UPDATE TB_AVALIACAO SET 
                            USUARIO_AVALIADOR = @USUARIO_AVALIADOR, 
                            DATA_AVALIACAO = @DATA_AVALIACAO, 
                            ID_ESTAB = @ID_ESTAB,
                            ID_TIPO_ESTAB = @ID_TIPO_ESTAB, 
                            ID_TIPO_AVAL = @ID_TIPO_AVAL, 
                            ID_NOTA_AVAL = @ID_NOTA_AVAL 
                            WHERE ID = @ID";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public Dictionary<string, object> AvaliacaoDel(int id)
        {
            string SQL = "DELETE FROM TB_AVALIACAO WHERE ID = @ID";

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

        ~AvaliacaoDbScripts()
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
