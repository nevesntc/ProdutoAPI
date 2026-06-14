using ProdutoAPI.DTOs;
using ProdutoAPI.Models;
using ProdutoAPI.Repositories;

namespace ProdutoAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository; //aqui estamos declarando uma variável privada do tipo IProdutoRepository chamada _produtoRepository. Essa variável é usada para armazenar a instância do repositório de produtos que será injetada na classe de serviço. O repositório é responsável por realizar operações de acesso a dados relacionadas aos produtos, como listar, obter por ID, criar, atualizar e remover produtos.
        public ProdutoService(IProdutoRepository produtoRepository) //aqui estamos definindo o construtor da classe ProdutoService, que recebe um objeto do tipo IProdutoRepository como parâmetro. O construtor é usado para injetar a dependência do repositório de produtos na classe de serviço, permitindo que a classe de serviço utilize os métodos do repositório para realizar operações relacionadas aos produtos.
        {
            _produtoRepository = produtoRepository;
        }

        public List <ProdutoResponseDTO> Listar() //aqui estamos implementando o método Listar, que retorna uma lista de objetos ProdutoResponseDTO. O método utiliza o repositório para obter a lista de produtos e, em seguida, filtra os produtos ativos usando o método Where. Em seguida, ele mapeia cada produto ativo para um objeto ProdutoResponseDTO usando o método MapearParaResponse e retorna a lista resultante. O LINQ é utilizado para realizar as operações de filtragem e mapeamento de forma concisa e eficiente.
        {
            return _produtoRepository.Listar()
                .Where(produto => produto.Ativo)
                .Select(MapearParaResponse)
                .ToList();
        }

        public ProdutoResponseDTO? ObterPorId(int ID) //aqui estamos implementando o método ObterPorId, que recebe um ID como parâmetro e retorna um objeto ProdutoResponseDTO correspondente ao produto com o ID fornecido. O método utiliza o repositório para obter o produto por ID e verifica se o produto é nulo ou não está ativo. Se o produto for nulo ou não estiver ativo, o método retorna null. Caso contrário, ele mapeia o produto para um objeto ProdutoResponseDTO usando o método MapearParaResponse e retorna esse objeto.
        {
            var produto = _produtoRepository.ObterPorId(ID);

            if (produto == null || !produto.Ativo)
            
                return null;
            
            return MapearParaResponse(produto);
        }

        public ProdutoResponseDTO Criar(CreateProdutoRequestDTO dto) //aqui estamos implementando o método Criar, que recebe um objeto CreateProdutoRequestDTO como parâmetro e retorna um objeto ProdutoResponseDTO correspondente ao produto criado. O método cria um novo objeto Produto usando as informações fornecidas no DTO, chama o método Criar do repositório para salvar o produto no banco de dados e, em seguida, mapeia o produto criado para um objeto ProdutoResponseDTO usando o método MapearParaResponse e retorna esse objeto.
        {
            var produto = new Produto(dto.Nome, dto.Descricao, dto.Preco, dto.QuantidadeEstoque);
            _produtoRepository.Criar(produto);
            return MapearParaResponse(produto);
        }

        public bool Atualizar(int id, UpdateProdutoRequestDTO dto) //aqui estamos implementando o método Atualizar, que recebe um ID e um objeto UpdateProdutoRequestDTO como parâmetros. O método procura o produto correspondente ao ID fornecido na lista de produtos. Se o produto não for encontrado ou não estiver ativo, o método retorna false. Caso contrário, ele chama o método Atualizar do produto para atualizar as informações do produto com os valores fornecidos no DTO e, em seguida, chama o método Atualizar do repositório para salvar as alterações. Por fim, o método retorna true para indicar que a atualização foi bem-sucedida.
        {
            var produto = _produtoRepository.ObterPorId(id);
            if (produto == null || !produto.Ativo)
                return false;

            produto.Atualizar(dto.Nome, dto.Descricao, dto.Preco, dto.QuantidadeEstoque);

            _produtoRepository.Atualizar(produto);

            return true;
        }

        public bool Remover(int id) //aqui estamos implementando o método Remover, que recebe um ID como parâmetro. O método procura o produto correspondente ao ID fornecido na lista de produtos. Se o produto não for encontrado ou não estiver ativo, o método retorna false. Caso contrário, ele chama o método Desativar do produto para marcar o produto como inativo e, em seguida, chama o método Atualizar do repositório para salvar as alterações. Por fim, o método retorna true para indicar que a remoção (desativação) foi bem-sucedida.
        {
            var produto = _produtoRepository.ObterPorId(id);
            if (produto == null || !produto.Ativo)
                return false;

            produto.Desativar();

            _produtoRepository.Atualizar(produto);

            return true;
        }

        private static ProdutoResponseDTO MapearParaResponse(Produto produto) //aqui estamos implementando o método privado MapearParaResponse, que recebe um objeto Produto como parâmetro e retorna um objeto ProdutoResponseDTO correspondente. O método cria um novo objeto ProdutoResponseDTO e atribui as propriedades do produto ao DTO, mapeando os valores correspondentes. Em seguida, ele retorna o objeto ProdutoResponseDTO resultante.
        {
            return new ProdutoResponseDTO
            {
                Id = produto.ID,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                DataCadastro = produto.DataCadastro,
                Ativo = produto.Ativo
            };
        }
    }
}



