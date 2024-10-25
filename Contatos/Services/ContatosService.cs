using Contatos.Models;
using Contatos.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Services
{
    public class ContatosService
    {
        private BancoContext _bancoContext;

        public ContatosService(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<Contato> GetAllContacts(int skip, int take, string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return _bancoContext.Contato.Include(c => c.Telefones).Skip(skip).Take(take).ToList();

            search = search.TrimStart().TrimEnd().Replace("  ", " ");
            var textos = search.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var query = _bancoContext.Contato.Include(c => c.Telefones).AsQueryable();

            foreach (var texto in textos)
            {
                var temp = texto;
                query = query.Where(c => c.Telefones.Any(t => EF.Functions.Like(t.Numero, $"%{temp}%")) ||
                                          EF.Functions.Like(c.Nome, $"%{temp}%"));
            }

            return query.Skip(skip).Take(take).ToList();
        }

        public Contato? Get(int id) => _bancoContext.Contato.FirstOrDefault(x => x.Id == id);

        public void Add(Contato contato)
        {
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();
        }

        public void Update(Contato contato)
        {
            _bancoContext.Contato.Update(contato);
            _bancoContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var contato = _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
            if (contato == null)
                return false;

            AddLogContatoExcluido(contato);

            _bancoContext.Contato.Remove(contato);
            _bancoContext.SaveChanges();

            return true;
        }
        private void AddLogContatoExcluido(Contato contato)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
            string logEntry = $"Contato excluído: ID={contato.Id}, Nome={contato.Nome}, Idade={contato.Idade}, Data={DateTime.Now}\n";

            File.AppendAllText(logFilePath, logEntry);
        }
    }
}
