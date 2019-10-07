using PruebaApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Repository
{
    public interface IRestUsuario
    {
        Task<List<UsuarioModel>> ObtenerItems();

        Task GuardarItem(UsuarioModel item, bool isNewItem);

        Task DeleteTodoItemAsync(string id);

    }
}
