using INSS.Aplicacao.Interfaces;
using INSS.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace INSS.Infra
{
    public class Contexto : IContexto
    {
        private List<ConfiguracaoDescontoInss> ConfiguracoesDescontoInss => InicializarDados();

        public ConfiguracaoDescontoInss ObterConfiguracaoDescontoInss(int ano, decimal salario)
        {
            return ConfiguracoesDescontoInss
                .Where(s => s.Ano == ano && s.SalarioMinimo <= salario && s.SalarioMaximo >= salario && !s.Teto)
                .FirstOrDefault();
        }

        public bool PeriodoConfigurado(int ano)
        {
            return ConfiguracoesDescontoInss.Any(s => s.Ano == ano);
        }

        public decimal ObterDescontoDoSalarioTeto(int ano)
        {
            return ConfiguracoesDescontoInss
                .FirstOrDefault(s => s.Ano == ano && s.Teto)
                .Aliquota;
        }

        private static List<ConfiguracaoDescontoInss> InicializarDados()
        {
            return new List<ConfiguracaoDescontoInss>()
            {
                new ConfiguracaoDescontoInss
                {
                    Ano = 2011,
                    SalarioMinimo = 0,
                    SalarioMaximo = 1106.9M,
                    Aliquota = 8M
                },
                new ConfiguracaoDescontoInss
                {
                    Ano = 2011,
                    SalarioMinimo = 1106.91M,
                    SalarioMaximo = 1844.83M,
                    Aliquota = 9M
                },
                new ConfiguracaoDescontoInss
                {
                    Ano = 2011,
                    SalarioMinimo = 1844.84M,
                    SalarioMaximo = 3689.66M,
                    Aliquota = 11M
                },
                new ConfiguracaoDescontoInss
                {
                    Ano = 2011,
                    SalarioMinimo = 3689.67M,
                    Aliquota = 405.86M,
                    Teto = true
                },
                new ConfiguracaoDescontoInss
                {
                    Ano = 2012,
                    SalarioMinimo = 0,
                    SalarioMaximo = 1000M,
                    Aliquota = 7M
                },
                new ConfiguracaoDescontoInss
                {
                    Ano = 2012,
                    SalarioMinimo = 1000.01M,
                    SalarioMaximo = 1500M,
                    Aliquota = 8M
                },
                new ConfiguracaoDescontoInss
                {
                    Ano = 2012,
                    SalarioMinimo = 1500.01M,
                    SalarioMaximo = 3000M,
                    Aliquota = 9M
                },
                new ConfiguracaoDescontoInss
                {
                    Ano = 2012,
                    SalarioMinimo = 3000.01M,
                    SalarioMaximo = 4000M,
                    Aliquota = 11M
                },
                new ConfiguracaoDescontoInss
                {
                    Ano = 2012,
                    SalarioMinimo = 4000.01M,
                    Aliquota = 500M,
                    Teto = true
                },
            };
        }
    }
}