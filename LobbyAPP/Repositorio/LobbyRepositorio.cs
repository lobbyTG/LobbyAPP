using LobbyAPP.Data;
using LobbyAPP.Models;

namespace LobbyAPP.Repositorio
{
    public class LobbyRepositorio : ILobbyRepositorio
    {

        private readonly BancoContext _bancoContext;

        public LobbyRepositorio(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }

        public LobbyModel ListarPorId(int id)
        {
            return _bancoContext.Lobbys.FirstOrDefault(x => x.Id == id);
        }
        public List<LobbyModel> BuscarTodos()
        {
            return _bancoContext.Lobbys.ToList();
        }
        public LobbyModel Adicionar(LobbyModel lobby)
        {
            //gravar no banco de dados
            _bancoContext.Lobbys.Add(lobby);
            _bancoContext.SaveChanges();

            return lobby;

        }

        public LobbyModel Atualizar(LobbyModel lobby)
        {
            LobbyModel lobbyDB = ListarPorId(lobby.Id);

            if (lobbyDB == null) throw new System.Exception("Houve um erro na atualização do lobby!");

            lobbyDB.Quadra = lobby.Quadra;
            lobbyDB.Endereco = lobby.Endereco;
            lobbyDB.Modalidades = lobby.Modalidades;

            _bancoContext.Lobbys.Update(lobbyDB);
            _bancoContext.SaveChanges();

            return lobbyDB;
        }
    }
}
