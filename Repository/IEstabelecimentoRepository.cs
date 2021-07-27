using CadastrosGerais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Repository
{
    public interface IEstabelecimentoRepository
    {
        string EstabelecimentoAdd(EstabelecimentoModel dados);
        string EstabelecimentoUpd(EstabelecimentoModel dados);
        string EstabelecimentoDel(int id);
        IEnumerable<EstabelecimentoModel> EstabelecimentoGetAll();
    }
}
