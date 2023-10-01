using LobbyAPP.Models;

namespace LobbyAPP.Repositorio
{
    public interface ILobbyRepositorio
    {

        LobbyModel ListarPorId(int id);
        List<LobbyModel> BuscarTodos();
        LobbyModel Adicionar(LobbyModel lobby);
        LobbyModel Atualizar(LobbyModel lobby);

        bool ApagarConfirmacao(int id);




    }
}
