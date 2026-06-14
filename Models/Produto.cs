namespace ProdutoAPI.Models
{
    public class Produto
    {
        public int ID { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataCadastro { get; private set; }


        private Produto() { } // Construtor privado para evitar a criação de objetos Produto sem passar os parâmetros necessários. Isso garante que todos os produtos sejam criados com as informações obrigatórias, como nome, preço e quantidade em estoque, e evita a criação de produtos incompletos ou inválidos.

        public Produto(string nome, string descricao, decimal preco, int quantidadeEstoque) // Construtor público para criar um novo produto. Ele recebe os parâmetros necessários para inicializar as propriedades do produto, como nome, descrição, preço e quantidade em estoque. O construtor também inclui validações para garantir que o nome do produto não seja vazio, o preço seja maior que zero e a quantidade em estoque não seja negativa. Se alguma dessas condições não for atendida, uma exceção ArgumentException é lançada com uma mensagem de erro apropriada.
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto é obrigatório.", nameof(nome));

            if (preco <= 0)
                throw new ArgumentException("O preço do produto deve ser maior que 0", nameof(preco));

            if (quantidadeEstoque < 0)
                throw new ArgumentException("Quantidade em estoque não pode ser negativa", nameof(quantidadeEstoque));

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Ativo = true;
            DataCadastro = DateTime.Now;
        }

        public void Atualizar(string nome, string descricao, decimal preco, int quantidadeEstoque) // Método para atualizar as informações de um produto existente. Ele recebe os parâmetros necessários para atualizar as propriedades do produto, como nome, descrição, preço e quantidade em estoque. O método também inclui validações semelhantes às do construtor para garantir que as informações fornecidas sejam válidas. Se alguma das condições não for atendida, uma exceção ArgumentException é lançada com uma mensagem de erro apropriada.
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto é obrigatório.", nameof(nome));
            if (preco <= 0)
                throw new ArgumentException("O preço do produto deve ser maior que 0", nameof(preco));
            if (quantidadeEstoque < 0)
                throw new ArgumentException("Quantidade em estoque não pode ser negativa", nameof(quantidadeEstoque));
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public void Desativar() // Método para desativar um produto. Ele simplesmente define a propriedade Ativo como false, indicando que o produto não está mais ativo ou disponível para venda. Isso pode ser útil para marcar produtos que foram descontinuados ou que não estão mais em estoque, sem removê-los completamente do sistema, permitindo que as informações do produto sejam mantidas para fins de histórico ou relatórios.
        {
            Ativo = false;

        }







    }
}
