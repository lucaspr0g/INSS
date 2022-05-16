using INSS.Aplicacao.Interfaces;
using System;

namespace INSS.Aplicacao
{
    public class CalculadorInss : ICalculadorInss
    {
        private readonly IContexto _contexto;

        public CalculadorInss(IContexto contexto)
        {
            _contexto = contexto;
        }

        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            var ano = data.Year;

            var configuracaoDesconto = _contexto.ObterConfiguracaoDescontoInss(ano, salario);

            if (configuracaoDesconto is null)
                return _contexto.ObterDescontoDoSalarioTeto(ano);

            return salario * configuracaoDesconto.Aliquota / 100;
        }
    }
}