using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
   public interface IDepartamentoRepository 
   {
        Task Adicionar(Departamento entity);
        Task Atualizar(Departamento entity);
        Task Excluir(Departamento entity);
        Task<List<Departamento>> Listar();
   } 
}