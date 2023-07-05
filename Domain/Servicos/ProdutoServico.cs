using Domain.Interfaces.IEstoque;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProduto;
using Entitities.Enums;

namespace Domain.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly InterfaceProduto _produtoInterface;
        private readonly InterfaceEstoque _estoqueInterface;

        public ProdutoServico(InterfaceProduto produtoRepositorio, InterfaceEstoque interfaceRepositorio)
        {
            _produtoInterface = produtoRepositorio;
            _estoqueInterface = interfaceRepositorio;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            try
            {
                Estoque estoque = new Estoque
                {
                    Codigo = produto.Codigo,
                    Produto = produto.NomeProduto,
                    DataAlteracao = DateTime.Now,
                    TipoAlteracao = EnumTipoAlteracao.Cadastro,
                    QuantidadeEntrada = 0,
                    QuantidadeSaida = 0,
                    QuantidadeSaldo = 0,
                    CustoEntrada = 0,
                    CustoSaida = 0,
                    CustoSaldo = 0
                };

                await _estoqueInterface.Adicionar(estoque);
                await _produtoInterface.Adicionar(produto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao adicionar o produto: {ex.Message}");
            }
        }


        public async Task AtualizarProduto(Produto produto)
        {
            await _produtoInterface.Atualizar(produto);
        }

        public async Task ExcluirProduto(Produto produto)
        {
            await _produtoInterface.Excluir(produto);
        }

        public async Task<Produto> ObterProdutoPorId(int Id)
        {
            return await _produtoInterface.ObterPorId(Id);
        }

        public async Task<IList<Produto>> ListarProdutos()
        {
            return await _produtoInterface.Listar();
        }

        public async Task<IList<Produto>> ObterProdutoPorNome(string nome)
        {
            return await _produtoInterface.ObterProdutoPorNome(nome);
        }
    }
}
