using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.Repositories
{
    public interface ILacheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GetLancheById(int lancheId);
    }
}
