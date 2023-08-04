using Domain.Interfaces.IEstoque;
using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IProduto;
using Helpers;
using Microsoft.AspNetCore.Http;

namespace Domain.Servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly InterfaceProduto _produtoInterface;
        private readonly InterfaceEstoque _estoqueInterface;
        private readonly GetEmpresaUsuario _getEmpresaUsuario;

        public ProdutoServico(
            InterfaceProduto produtoRepositorio, 
            InterfaceEstoque interfaceRepositorio, 
            GetEmpresaUsuario getEmpresaUsuario)
        {
            _produtoInterface = produtoRepositorio;
            _estoqueInterface = interfaceRepositorio;
            _getEmpresaUsuario = getEmpresaUsuario;
        }

        public async Task AdicionarProduto(Produto produto)
        {
            try
            {
                var idEmpresa = _getEmpresaUsuario.GetIdEmpresaUsuario();

                Estoque estoque = new Estoque
                {
                    Id = produto.Id,
                    IdEmpresa = idEmpresa,
                    IdAlteracao = 0,
                    Produto = produto.NomeProduto,
                    QuantidadeEstoque = 0,
                    ValorEstoque = 0,
                    ValorUnitarioEstoque = 0
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
