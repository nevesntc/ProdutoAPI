using Microsoft.AspNetCore.Mvc;
using ProdutoAPI.DTOs;
using ProdutoAPI.Services;

namespace ProdutoAPI.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService; //aqui estamos injetando a dependência do serviço de produtos na classe ProdutosController. Isso permite que a controller utilize os métodos definidos na interface IProdutoService para realizar as operações relacionadas aos produtos, como listar, obter por ID, criar, atualizar e remover produtos. A injeção de dependência é uma prática comum para promover a separação de preocupações e facilitar a testabilidade do código.

    public ProdutosController(IProdutoService produtoService) //aqui estamos definindo o construtor da classe ProdutosController, que recebe um objeto do tipo IProdutoService como parâmetro. Esse construtor é utilizado para injetar a dependência do serviço de produtos na controller, permitindo que a controller utilize os métodos definidos na interface IProdutoService para realizar as operações relacionadas aos produtos.
    {
        _produtoService = produtoService;

    }

    [HttpGet]
    public ActionResult Listar() //aqui estamos implementando o método Listar, que é um endpoint HTTP GET para listar os produtos. Ele chama o método Listar do serviço de produtos para obter a lista de produtos ativos e retorna essa lista como resposta usando o método Ok, que indica que a solicitação foi bem-sucedida e inclui os dados na resposta.
    {
        var produtos = _produtoService.Listar();

        return Ok(produtos); }

    [HttpGet("{id:int}")]
    public IActionResult ObterPorId(int id) //aqui estamos implementando o método ObterPorId, que é um endpoint HTTP GET para obter um produto específico por ID. Ele recebe um parâmetro id do tipo inteiro, que representa o ID do produto a ser obtido. O método chama o método ObterPorId do serviço de produtos para buscar o produto correspondente ao ID fornecido. Se o produto não for encontrado, o método retorna uma resposta NotFound com uma mensagem indicando que o produto não foi encontrado. Caso contrário, ele retorna o produto encontrado como resposta usando o método Ok, que indica que a solicitação foi bem-sucedida e inclui os dados na resposta.
    {
        var produto = _produtoService.ObterPorId(id);

        if (produto == null)
            return NotFound("Produto não encontrado");

        return Ok(produto); }

    [HttpPost]
    public IActionResult Criar(CreateProdutoRequestDTO dto) //aqui estamos implementando o método Criar, que é um endpoint HTTP POST para criar um novo produto. Ele recebe um objeto dto do tipo CreateProdutoRequestDTO, que contém os dados necessários para criar um novo produto. O método chama o método Criar do serviço de produtos para criar o produto com base nos dados fornecidos no DTO. Se a criação for bem-sucedida, o método retorna uma resposta CreatedAtAction, que indica que um novo recurso foi criado e inclui a localização do recurso criado (usando o nome do método ObterPorId e o ID do produto criado) e os dados do produto criado na resposta. Caso ocorra uma exceção do tipo ArgumentException durante a criação, o método captura a exceção e retorna uma resposta BadRequest com a mensagem de erro da exceção.
    {
        try
        {
            var produtoCriado = _produtoService.Criar(dto);

            return CreatedAtAction(nameof(ObterPorId), new { id = produtoCriado.Id }, produtoCriado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }


    }

    [HttpPut("{id:int}")] //aqui estamos implementando o método Atualizar, que é um endpoint HTTP PUT para atualizar um produto existente. Ele recebe um parâmetro id do tipo inteiro, que representa o ID do produto a ser atualizado, e um objeto dto do tipo UpdateProdutoRequestDTO, que contém os dados atualizados do produto. O método chama o método Atualizar do serviço de produtos para realizar a atualização do produto com base no ID fornecido e nos dados do DTO. Se o produto não for encontrado, o método retorna uma resposta NotFound com uma mensagem indicando que o produto não foi encontrado. Caso contrário, ele retorna uma resposta NoContent, indicando que a atualização foi bem-sucedida, mas sem incluir nenhum conteúdo na resposta.
    public IActionResult Atualizar(int id, UpdateProdutoRequestDTO dto)
    {
        try
        {
            var atualizado = _produtoService.Atualizar(id, dto);
            if (!atualizado) // o ponto de exclamação é usado para negar o valor booleano retornado pelo método Atualizar. Se o valor for false, significa que a atualização não foi bem-sucedida, o que pode ocorrer se o produto com o ID fornecido não for encontrado ou já estiver inativo. Nesse caso, o método retorna uma resposta NotFound com uma mensagem indicando que o produto não foi encontrado. Caso contrário, se a atualização for bem-sucedida (ou seja, se o valor retornado for true), o método retorna uma resposta NoContent, indicando que a atualização foi realizada com sucesso, mas sem incluir nenhum conteúdo na resposta.
                return NotFound("Produto não encontrado");
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:int}")] //aqui estamos implementando o método Remover, que é um endpoint HTTP DELETE para remover um produto existente. Ele recebe um parâmetro id do tipo inteiro, que representa o ID do produto a ser removido. O método chama o método Remover do serviço de produtos para realizar a remoção do produto com base no ID fornecido. Se o produto não for encontrado, o método retorna uma resposta NotFound com uma mensagem indicando que o produto não foi encontrado. Caso contrário, ele retorna uma resposta NoContent, indicando que a remoção foi bem-sucedida, mas sem incluir nenhum conteúdo na resposta.
    public IActionResult Remover(int id)
    {
        var removido = _produtoService.Remover(id);
        if (!removido) //o ponto de exclamação é usado para negar o valor booleano retornado pelo método Remover. Se o valor for false, significa que a remoção não foi bem-sucedida, o que pode ocorrer se o produto com o ID fornecido não for encontrado ou já estiver inativo. Nesse caso, o método retorna uma resposta NotFound com uma mensagem indicando que o produto não foi encontrado. Caso contrário, se a remoção for bem-sucedida (ou seja, se o valor retornado for true), o método retorna uma resposta NoContent, indicando que a remoção foi realizada com sucesso, mas sem incluir nenhum conteúdo na resposta.
            return NotFound("Produto não encontrado");
        return NoContent();
    }
}

