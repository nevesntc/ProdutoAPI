using ProdutoAPI.Data;
using ProdutoAPI.Models;

namespace ProdutoAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context; // Declaração de uma variável privada do tipo AppDbContext chamada _context. Essa variável é usada para acessar o banco de dados e realizar operações relacionadas aos produtos.
        public ProdutoRepository(AppDbContext context) // Construtor da classe ProdutoRepository que recebe uma instância de AppDbContext como parâmetro. Essa instância é usada para acessar o banco de dados e realizar operações relacionadas aos produtos.
        {
            _context = context;
        }
        public List<Produto> Listar() // Método para listar todos os produtos. Ele retorna a lista de produtos armazenada na variável _produtos.
        {
            return _context.Produtos.ToList();
        }
        public Produto? ObterPorId(int id) // Método para obter um produto específico pelo seu ID. Ele utiliza o método FirstOrDefault para procurar o produto na lista _produtos que tenha o ID correspondente ao valor fornecido como parâmetro. Se um produto com o ID especificado for encontrado, ele é retornado; caso contrário, o método retorna null.
        {
            return _context.Produtos.FirstOrDefault(produto => produto.ID == id);
        } 
        public void Criar(Produto produto) // Método para criar um novo produto. Ele recebe um objeto do tipo Produto como parâmetro e o adiciona à lista _produtos usando o método Add. Antes de chamar esse método, é importante garantir que o produto tenha um ID único, o que pode ser feito utilizando o método GerarProximoId para atribuir um ID ao produto antes de adicioná-lo à lista.
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
        public void Atualizar(Produto produto) // Método para atualizar um produto existente. Ele recebe um objeto do tipo Produto como parâmetro e substitui o produto na lista _produtos que tenha o mesmo ID.
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
        public void Remover(Produto produto) // Método para remover um produto existente. Ele recebe um objeto do tipo Produto como parâmetro e o remove da lista _produtos usando o método Remove. Antes de chamar esse método, é importante garantir que o produto a ser removido exista na lista, o que pode ser feito utilizando o método ObterPorId para verificar se o produto com o ID especificado existe antes de tentar removê-lo.
        {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }

}
