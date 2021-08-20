using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IDepartamentoService :IDepartamentoRepository
    {       
        Task AdicionarMembro(Departamento entity, Membro membro);
        Task RemoverMembro(Departamento entity, Membro membro);
    }
}