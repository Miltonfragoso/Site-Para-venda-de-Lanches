using LanchesMac.Context;
using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private AppDbContext _context;

        public CategoriaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        //Método  para retornar uma coleção de categorias
        public IEnumerable<Categoria> Categorias => _context.Categorias;

        IEnumerable<Categoria> ICategoriaRepository.Categorias => throw new System.NotImplementedException();
    }
}
