using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCLIP.BD
{
    public interface CRUD<T>
    {
        List<T> listarTodos();
        int consultar(T t);
        int registrar(T t);
        int modificar(T t);
        int eliminar(T t);
    }
}
