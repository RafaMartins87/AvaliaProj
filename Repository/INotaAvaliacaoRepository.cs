using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public interface INotaAvaliacaoRepository
    {
        string NotaAvaliacaoAdd(NotaAvaliacaoModel dados);
        string NotaAvaliacaoUpd(NotaAvaliacaoModel dados);
        string NotaAvaliacaoDel(int id);
        IEnumerable<NotaAvaliacaoModel> NotaAvaliacaoGetAll();
    }
}
