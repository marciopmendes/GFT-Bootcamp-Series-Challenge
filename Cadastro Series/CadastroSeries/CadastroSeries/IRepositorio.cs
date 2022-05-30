using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroSeries
{
    public interface IRepositorio
    {
        List<Serie> Listar();
        Serie RetornaPorId(int Id);
        void Insere(Serie entidade);
        void Exclui(int Id);
        void Atualiza(int id, Serie entidade);
        int ProximoId();
    }
}
