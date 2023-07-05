using Domain.Interfaces.Generica;
using Infra.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Infra.Repositorio.Generics
{
    public class RepositoryGenerics<T> : InterfaceGenerica<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryGenerics()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Adicionar(T Objeto)
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    await data.Set<T>().AddAsync(Objeto);
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar o objeto: {ex.Message}");
                throw;
            }
        }

        public async Task Atualizar(T Objeto)
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    data.Set<T>().Update(Objeto);
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o objeto: {ex.Message}");
                throw;
            }
        }

        public async Task Excluir(T Objeto)
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    data.Set<T>().Remove(Objeto);
                    await data.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir o objeto: {ex.Message}");
                throw;
            }
        }

        public async Task<List<T>> Listar()
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    return await data.Set<T>().ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar os objetos: {ex.Message}");
                throw;
            }
        }

        public async Task<T> ObterPorId(int Id)
        {
            try
            {
                using (var data = new ContextBase(_OptionsBuilder))
                {
                    return await data.Set<T>().FindAsync(Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter o objeto por ID: {ex.Message}");
                throw;
            }
        }

        #region Dispose
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    handle.Dispose();
                }
                disposed = true;
            }
        }
        #endregion
    }
}
