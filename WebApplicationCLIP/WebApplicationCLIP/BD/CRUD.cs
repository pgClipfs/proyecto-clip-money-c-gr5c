using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace WebApplicationCLIP.BD
{
    public interface CRUD<T>
    {
        List<T> listarTodos();
        T consultar(T t);
        void registrar(T t);
        void modificar(T t);
        void eliminar(T t);
    }
}