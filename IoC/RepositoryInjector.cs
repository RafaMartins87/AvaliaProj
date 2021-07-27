using CadastrosGerais.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrosGerais.IoC
{
    public class RepositoryInjector
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<INotaAvaliacaoRepository, NotaAvaliacaoRepository>();
            services.AddScoped<ITipoAvaliacaoRepository, TipoAvaliacaoRepository>();
            services.AddScoped<ITipoEstabelecimentoRepository, TipoEstabelecimentoRepository>();
        }

    }
}
