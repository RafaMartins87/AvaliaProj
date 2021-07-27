using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public interface ITipoAvaliacaoRepository
    {
        string TipoAvaliacaoAdd(TipoAvaliacaoModel dados);
        string TipoAvaliacaoUpd(TipoAvaliacaoModel dados);
        string TipoAvaliacaoDel(int id);
        IEnumerable<TipoAvaliacaoModel> TipoAvaliacaoGetAll();
    }
}
