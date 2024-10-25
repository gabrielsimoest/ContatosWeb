using Contatos.Models;
using Contatos.Persistance;

namespace Contatos.Services
{
    public class TelefonesService
    {
        private BancoContext _bancoContext;

        public TelefonesService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Telefone> GetAllPhones(int contatoId) => _bancoContext.Telefone.Where(x => x.ContatoId == contatoId).ToList();

        public void Add(Telefone telefone)
        {
            _bancoContext.Telefone.Add(telefone);
            _bancoContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var telefone = _bancoContext.Telefone.FirstOrDefault(x => x.Id == id);
            if (telefone == null)
                return false;

            _bancoContext.Telefone.Remove(telefone);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
