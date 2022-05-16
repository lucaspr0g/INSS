namespace INSS.Dominio.Entidades
{
    public class ConfiguracaoDescontoInss
    {
        public int Ano { get; set; }

        public decimal SalarioMinimo { get; set; }

        public decimal? SalarioMaximo { get; set; }

        public decimal Aliquota { get; set; }

        public bool Teto { get; set; }
    }
}