using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public interface ITipoEstabelecimentoRepository
    {
        string TipoEstabelecimentoAdd(TipoEstabelecimentoModel dados);
        string TipoEstabelecimentoUpd(TipoEstabelecimentoModel dados);
        string TipoEstabelecimentoDel(int id);
        IEnumerable<TipoEstabelecimentoModel> TipoEstabelecimentoGetAll();
    }
}
