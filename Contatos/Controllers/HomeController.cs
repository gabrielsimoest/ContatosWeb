using Contatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    public class HomeController : Controller
    {
        private ContatosService _contatosService { get; set; }

        public HomeController(ContatosService contatosService)
        {
            _contatosService = contatosService;
        }

        [HttpGet]
        public IActionResult Index(string? search)
        {
            int skip = 0;
            int take = int.MaxValue;

            var listaContatos = _contatosService.GetAllContacts(skip, take, search);
            return View(listaContatos);
        }
    }
}
