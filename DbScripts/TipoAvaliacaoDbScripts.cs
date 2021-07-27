using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.DbScripts
{
    public class TipoAvaliacaoDbScripts
    {
        public Dictionary<string, object> TipoAvaliacaoAdd(TipoAvaliacaoModel dados)
        {
            string SQL = @"INSERT INTO TB_TIPO_AVALIACAO 
                            VALUES (@DESCR_TIPO_AVAL)";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public string TipoAvaliacaoGetAll()
        {
            string SQL = "SELECT * FROM TB_TIPO_AVALIACAO";

            return SQL;
        }

        public Dictionary<string, object> TipoAvaliacaoUpd(TipoAvaliacaoModel dados)
        {
            string SQL = "UPDATE TB_TIPO_AVALIACAO SET DESCR_TIPO_AVAL = @DESCR_TIPO_AVAL WHERE ID_TIPO_AVAL = @ID_TIPO_AVAL";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public Dictionary<string, object> TipoAvaliacaoDel(int id)
        {
            string SQL = "DELETE FROM TB_TIPO_AVALIACAO WHERE ID_TIPO_AVAL = @ID_TIPO_AVAL";

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

        ~TipoAvaliacaoDbScripts()
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
