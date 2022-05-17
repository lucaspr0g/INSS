using Aplicacao.Interfaces;
using Infra.Data.Repositorios;
using Infra.Interfaces;
using System;
using System.Globalization;

namespace Aplicacao
{
    public class CalculadorFolhaSalarial : ICalculadorFolhaSalarial
    {
        private readonly IConfiguracaoDescontoInssRepositorio _respositorio;

        public CalculadorFolhaSalarial()
        {
            _respositorio = new ConfiguracaoDescontoInssRepositorio();
        }

        public void CalcularFolhaSalarial()
        {
            var data = DateTime.Now;
            var salario = 1000M;

            Validar(data, salario);

            var calculadorInss = new CalculadorInss(_respositorio);

            var desconto = calculadorInss.CalcularDesconto(data, salario);

            Console.WriteLine($"Desconto: {desconto.ToString("c", CultureInfo.GetCultureInfo("pt-BR"))}");
        }

        private void Validar(DateTime data, decimal salario)
        {
            var periodoConfigurado = _respositorio.PeriodoConfigurado(data.Year);

            if (!periodoConfigurado)
                throw new Exception("Período não configurado.");

            if (salario <= 0)
                throw new Exception("Salário inválido.");
        }
    }
}