using Domain.Interfaces.IFuncionario;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProduto;
using Entitities.Entidades;

namespace Domain.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly InterfaceProduto _produtoInterface;

        public ProdutoServico(InterfaceProduto produtoRepositorio)
        {
            _produtoInterface = produtoRepositorio;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            await _produtoInterface.Adicionar(produto);
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

        public async Task EntradaEstoque(Produto produto)
        {
            await _produtoInterface.EntradaEstoque(produto);
        }

        public async Task SaidaEstoque(Produto produto)
        {
            await _produtoInterface.SaidaEstoque(produto);
        }
    }
}
