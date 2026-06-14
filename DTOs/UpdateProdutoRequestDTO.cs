namespace ProdutoAPI.DTOs
{
    public class UpdateProdutoRequestDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }

        public bool Ativo { get; set; }

    }
}
