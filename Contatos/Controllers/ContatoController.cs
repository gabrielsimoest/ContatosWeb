using Contatos.Models;
using Contatos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Controllers
{
    [Route("contato")]
    public class ContatoController : Controller
    {
        private ContatosService _contatosService { get; set; }

        public ContatoController(ContatosService contatosService)
        {
            _contatosService = contatosService;
        }

        [HttpGet("{id?}")]
        public IActionResult Get([FromServices] TelefonesService telefonesService, int id = 0)
        {
            try
            {
                var contato = new Contato();

                if (id != 0)
                {
                    contato = _contatosService.Get(id);
                    if (contato != null)
                        ViewBag.Telefones = telefonesService.GetAllPhones(contato.Id);
                }


                return View(contato);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public IActionResult Create([FromForm] Contato contato)
        {
            try
            {
                _contatosService.Add(contato);
                return RedirectToAction("Get", new { id = contato.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] Contato contato)
        {
            try
            {
                _contatosService.Update(contato);
                return RedirectToAction("Get", new { id = contato.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var wasFound = _contatosService.Delete(id);

                if (wasFound)
                    return RedirectToAction("Index", "Home");
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
