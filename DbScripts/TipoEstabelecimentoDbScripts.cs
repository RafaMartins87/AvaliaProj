using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.DbScripts
{
    public class TipoEstabelecimentoDbScripts
    {
        public Dictionary<string, object> TipoEstabelecimentoAdd(TipoEstabelecimentoModel dados)
        {
            string SQL = @"INSERT INTO TB_TIPO_ESTABELECIMENTO 
                            VALUES (@DESCR_TIPO_ESTAB)";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public string TipoEstabelecimentoGetAll()
        {
            string SQL = "SELECT * FROM TB_TIPO_ESTABELECIMENTO";

            return SQL;
        }

        public Dictionary<string, object> TipoEstabelecimentoUpd(TipoEstabelecimentoModel dados)
        {
            string SQL = "UPDATE TB_TIPO_ESTABELECIMENTO SET DESCR_TIPO_ESTAB = @DESCR_TIPO_ESTAB WHERE ID_TIPO_ESTAB = @ID_TIPO_ESTAB";

            return new Dictionary<string, object>() { { SQL, dados } };
        }

        public Dictionary<string, object> TipoEstabelecimentoDel(int id)
        {
            string SQL = "DELETE FROM TB_TIPO_ESTABELECIMENTO WHERE ID_TIPO_ESTAB = @ID_TIPO_ESTAB";

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

        ~TipoEstabelecimentoDbScripts()
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
