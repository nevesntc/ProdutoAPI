using ProdutoAPI.DTOs;

namespace ProdutoAPI.Services
{
    public interface IProdutoService
    {
        List<ProdutoResponseDTO> Listar(); //aqui o método Listar retorna uma lista de ProdutoResponseDTO, ou seja, uma coleção de produtos
        ProdutoResponseDTO? ObterPorId(int id); //isso significa que o id pode ser nulo, ou seja, o método pode retornar um ProdutoResponseDTO ou null

        ProdutoResponseDTO Criar(CreateProdutoRequestDTO dto); //aqui o método Criar recebe um CreateProdutoRequestDTO como parâmetro e retorna um ProdutoResponseDTO, ou seja, ele cria um novo produto com base nas informações fornecidas no DTO de criação e retorna os detalhes do produto criado.

        bool Atualizar(int ID, UpdateProdutoRequestDTO dto); //Atualiza os dados de um produto existente com base no ID fornecido e nas informações contidas no DTO de atualização. O método retorna um valor booleano indicando se a atualização foi bem-sucedida ou não.

        bool Remover(int ID); //Remove um produto existente com base no ID fornecido. O método retorna um valor booleano indicando se a remoção foi bem-sucedida ou não.


    }
}
