using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public interface INotaAvaliacaoRepository
    {
        string AvaliacaooAdd(NotaAvaliacaoModel dados);
        string AvaliacaoUpd(NotaAvaliacaoModel dados);
        string AvaliacaoDel(int id);
        IEnumerable<NotaAvaliacaoModel> AvaliacaoGetAll();
    }
}
