using LanchesMac.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        //injeção de dependencia do REPOSITORY
        private LancheRepository _lancheRepository;
        private CategoriaRepository _categoriaRepository;

        public LancheController(LancheRepository lancheRepository,
                                CategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List()
        {
            var lanches = _lancheRepository.Lanches;
            return View(lanches);

        }
    }
}
