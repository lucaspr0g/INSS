using INSS.Dominio.Entidades;

namespace INSS.Aplicacao.Interfaces
{
    public interface IContexto
    {
        ConfiguracaoDescontoInss ObterConfiguracaoDescontoInss(int ano, decimal salario);

        bool PeriodoConfigurado(int ano);

        decimal ObterDescontoDoSalarioTeto(int ano);
    }
}