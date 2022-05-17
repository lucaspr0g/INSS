using Dominio.Entidades;

namespace Infra.Interfaces
{
    public interface IConfiguracaoDescontoInssRepositorio
    {
        decimal? ObterAliquota(int ano, decimal salario);

        decimal ObterDescontoDoSalarioTeto(int ano);

        bool PeriodoConfigurado(int ano);
    }
}