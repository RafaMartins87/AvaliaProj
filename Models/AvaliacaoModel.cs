using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.Models
{
    public class AvaliacaoModel
    {
        public int ID_AVALIACAO { get; set; }
        public string USUARIO_AVALIADOR { get; set; }
        public DateTime DATA_AVALIACAO { get; set; }
        public int ID_ESTAB { get; set; }
        public int ID_TIPO_ESTAB { get; set; }
        public int ID_TIPO_AVAL { get; set; }
        public int ID_NOTA_AVAL { get; set; }           
        
    }
}
