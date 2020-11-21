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
        T consultar(T t);
        Enum registrar(T t);
        Enum modificar(T t);
        Enum eliminar(T t);
    }
}
