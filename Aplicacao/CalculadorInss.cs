using Aplicacao.Interfaces;
using Infra.Interfaces;
using System;

namespace Aplicacao
{
    public class CalculadorInss : ICalculadorInss
    {
        private readonly IConfiguracaoDescontoInssRepositorio _repositorio;

        public CalculadorInss(IConfiguracaoDescontoInssRepositorio respositorio)
        {
            _repositorio = respositorio;
        }

        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            var ano = data.Year;

            var aliquota = _repositorio.ObterAliquota(ano, salario);

            if (aliquota is null)
                return _repositorio.ObterDescontoDoSalarioTeto(ano);

            return salario * aliquota.GetValueOrDefault() / 100;
        }
    }
}