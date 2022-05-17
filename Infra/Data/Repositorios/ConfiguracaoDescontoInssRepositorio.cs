using Infra.Interfaces;
using System.Linq;

namespace Infra.Data.Repositorios
{
    public class ConfiguracaoDescontoInssRepositorio : IConfiguracaoDescontoInssRepositorio
    {
        public decimal? ObterAliquota(int ano, decimal salario)
        {
            return Contexto.Contexto.ConfiguracoesDescontoInss
                .Where(s => s.Ano == ano && s.SalarioMinimo <= salario && s.SalarioMaximo >= salario && !s.Teto)
                .FirstOrDefault()?
                .Aliquota;
        }

        public bool PeriodoConfigurado(int ano)
        {
            return Contexto.Contexto.ConfiguracoesDescontoInss.Any(s => s.Ano == ano);
        }

        public decimal ObterDescontoDoSalarioTeto(int ano)
        {
            return Contexto.Contexto.ConfiguracoesDescontoInss
                .FirstOrDefault(s => s.Ano == ano && s.Teto)
                .Aliquota;
        }
    }
}
