using INSS.Aplicacao.Interfaces;
using INSS.Infra;
using System;
using System.Globalization;

namespace INSS.Aplicacao
{
    public class CalculadorFolhaSalarial : ICalculadorFolhaSalarial
    {
        private readonly IContexto _contexto;

        public CalculadorFolhaSalarial()
        {
            _contexto = new Contexto();
        }

        public void CalcularFolhaSalarial()
        {
            var data = DateTime.Now;
            var salario = 1000M;

            Validar(data, salario);

            var calculadorInss = new CalculadorInss(_contexto);

            var desconto = calculadorInss.CalcularDesconto(data, salario);

            Console.WriteLine($"Desconto: {desconto.ToString("c", CultureInfo.GetCultureInfo("pt-BR"))}");
        }

        private void Validar(DateTime data, decimal salario)
        {
            var periodoConfigurado = _contexto.PeriodoConfigurado(data.Year);

            if (!periodoConfigurado)
                throw new Exception("Período não configurado.");

            if (salario <= 0)
                throw new Exception("Salário inválido.");
        }
    }
}