using PH3A.Juros.UI.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PH3A.Juros.UI.Repositories
{
    public class Repository<TModel> : IRepository<TModel>, IDisposable where TModel : class
    {
        protected readonly PH3AContext _context = new PH3AContext();
        protected readonly DbSet<TModel> _table;

        public Repository()
        {
            _table = _context.Set<TModel>();
        }

        public void Alterar(TModel obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TModel Buscar(int id)
        {
            return _context.Set<TModel>().Find(id);
        }

        public List<TModel> BuscarTodos()
        {
            return _context.Set<TModel>().ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Excluir(TModel obj)
        {
            _context.Set<TModel>().Remove(obj);
            _context.SaveChanges();
        }

        public void Incluir(TModel obj)
        {
            _context.Set<TModel>().Add(obj);
            _context.SaveChanges();
        }
    }
}