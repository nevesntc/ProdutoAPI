using ProdutoAPI.Models;

namespace ProdutoAPI.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> Listar(); // Método para listar todos os produtos
        Produto? ObterPorId(int id); // Método para obter um produto específico por ID. O tipo de retorno é Produto? (Produto nullable) para indicar que o método pode retornar um produto ou null caso o produto não seja encontrado.
        void Criar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(Produto produto);
    }
}
