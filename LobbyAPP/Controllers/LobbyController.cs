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

        public IActionResult Apagar(int id)
        {
            LobbyModel lobby = _lobbyRepositorio.ListarPorId(id);
            return View(lobby);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            try
            {
               bool apagado =  _lobbyRepositorio.ApagarConfirmacao(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Lobby apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = $"Não foi possível apagar o lobby";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível apagar o lobby, mais detalhes sobre o erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost] 
        public IActionResult Criar(LobbyModel lobby)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    _lobbyRepositorio.Adicionar(lobby);
                    TempData["MensagemSucesso"] = "Lobby cadastrado com sucesso";
                    return RedirectToAction("Index");

                }


                return View(lobby);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível cadastrar o lobby, tente novamente, detalhe do erro: {erro.Message}" ;
                return RedirectToAction("Index");

            }
        }

        [HttpPost]
        public IActionResult Alterar(LobbyModel lobby)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _lobbyRepositorio.Atualizar(lobby);
                    TempData["MensagemSucesso"] = "Lobby alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", lobby);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível alterar o lobby, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");

            }

        }
    }
}
