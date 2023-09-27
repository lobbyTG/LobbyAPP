using LobbyAPP.Models;
using LobbyAPP.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace LobbyAPP.Controllers
{
    public class LobbyController : Controller
    {

        private readonly ILobbyRepositorio _lobbyRepositorio;
        public LobbyController(ILobbyRepositorio lobbyRepositorio)
        {

            _lobbyRepositorio = lobbyRepositorio;

        }
        public IActionResult Index()
        {
            List<LobbyModel> lobbys = _lobbyRepositorio.BuscarTodos();

            return View(lobbys);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            LobbyModel lobby = _lobbyRepositorio.ListarPorId(id);
            return View(lobby);
        }

        public IActionResult Apagar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(LobbyModel lobby)
        {

            _lobbyRepositorio.Adicionar(lobby);
            return RedirectToAction("Index");
               
        }

        [HttpPost]
        public IActionResult Alterar(LobbyModel lobby)
        {

            _lobbyRepositorio.Atualizar(lobby);
            return RedirectToAction("Index");

        }
    }
}
