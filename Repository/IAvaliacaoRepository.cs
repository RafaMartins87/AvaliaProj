using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public interface IAvaliacaoRepository
    {
        string AvaliacaoAdd(AvaliacaoModel dados);
        string AvaliacaoUpd(AvaliacaoModel dados);
        string AvaliacaoDel(int id);
        IEnumerable<AvaliacaoModel> AvaliacaoGetAll();

    }
}
