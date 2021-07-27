using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public interface ITipoAvaliacaoRepository
    {
        string AvaliacaooAdd(TipoAvaliacaoModel dados);
        string AvaliacaoUpd(TipoAvaliacaoModel dados);
        string AvaliacaoDel(int id);
        IEnumerable<TipoAvaliacaoModel> AvaliacaoGetAll();
    }
}
