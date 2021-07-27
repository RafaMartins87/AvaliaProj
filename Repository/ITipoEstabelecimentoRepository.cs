using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public interface ITipoEstabelecimentoRepository
    {
        string AvaliacaooAdd(TipoEstabelecimentoModel dados);
        string AvaliacaoUpd(TipoEstabelecimentoModel dados);
        string AvaliacaoDel(int id);
        IEnumerable<TipoEstabelecimentoModel> AvaliacaoGetAll();
    }
}
