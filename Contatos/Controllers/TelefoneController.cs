using Contatos.Models;
using Contatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    [Route("telefone")]
    public class TelefoneController : Controller
    {
        private TelefonesService _telefonesService { get; set; }

        public TelefoneController(TelefonesService contatosService)
        {
            _telefonesService = contatosService;
        }

        [HttpPost]
        public IActionResult Create([FromForm] Telefone telefone)
        {
            try
            {
                _telefonesService.Add(telefone);
                return RedirectToAction("Get", "Contato", new { id = telefone.ContatoId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete([FromForm] Telefone telefone)
        {
            try
            {
                var wasFound = _telefonesService.Delete(telefone.Id);

                if (wasFound)
                    return RedirectToAction("Get", "Contato", new { id = telefone.ContatoId });
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
