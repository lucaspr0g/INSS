using INSS.Aplicacao;
using INSS.Aplicacao.Interfaces;
using INSS.Infra;
using System;
using Xunit;

namespace TESTES.Aplicacao
{
    public class CalculadorInssTeste
    {
        private readonly IContexto _contexto;
        private readonly ICalculadorInss _calculadorInss;

        private static DateTime Data2011 => new DateTime(2011, 01, 01);
        private static DateTime Data2012 => new DateTime(2012, 01, 01);

        public static readonly object[][] Dados =
        {
            new object[] { Data2011, 1000, 80 },
            new object[] { Data2011, 1200, 108 },
            new object[] { Data2011, 3000, 330 },
            new object[] { Data2011, 6000, 405.86 },
            new object[] { Data2012, 1000, 70 },
            new object[] { Data2012, 1200, 96 },
            new object[] { Data2012, 3000, 270 },
            new object[] { Data2012, 3500, 385 },
            new object[] { Data2012, 6000, 500 }
        };
        
        public CalculadorInssTeste()
        {
            _contexto = new Contexto();
            _calculadorInss = new CalculadorInss(_contexto);
        }

        [Theory, MemberData(nameof(Dados))]
        public void CalcularDesconto_ConsiderandoOsDadosInformados_DeveRetornarODescontoEsperado(DateTime data, decimal salario, decimal descontoEsperado)
        {
            var desconto = _calculadorInss.CalcularDesconto(data, salario);

            Assert.Equal(descontoEsperado, desconto);
        }

        [Fact]
        public void CalcularDesconto_PassandoUmaDataInexistenteNoContexto_DeveLancarUmaException()
        {
            Assert.Throws<NullReferenceException>(() => _calculadorInss.CalcularDesconto(new DateTime(2010, 01, 01), 1000));
        }
    }
}