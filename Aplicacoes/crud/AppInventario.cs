using Dominios;
using Dominios.crud;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Aplicacoes.crud
{
    public class AppInventario
    {
        public List<TbInventarios> ListarTodos()
        {
            List<TbInventarios> lista = new List<TbInventarios>();
            try
            {
                using(DbCrud db = new DbCrud())
                {
                    lista = db.Inventarios.ToList();
                }
            }
            catch (Exception)
            {
                lista = null;
                throw;
            }
            return lista;
        }

        public TbInventarios ListarPorId(Int64 id)
        {
            TbInventarios retorno = new TbInventarios();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    retorno = db.Inventarios.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                retorno = null;
                throw;
            }
            return retorno;
        }

        public bool SalvarRegistro(TbInventarios tbInventario)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Inventarios.Add(tbInventario);
                        db.SaveChanges();
                        transaction.Commit();
                        retorno = true;
                    }
                    catch (Exception)
                    {
                        retorno = false;
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return retorno;
        }

        public bool EditarRegistro(TbInventarios tbInventario)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(tbInventario).State = EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                        retorno = true;
                    }
                    catch (Exception)
                    {
                        retorno = false;
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return retorno;
        }

        public bool DeletarRegistro(TbInventarios tbInventario)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(tbInventario).State = EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                        retorno = true;
                    }
                    catch (Exception)
                    {
                        retorno = false;
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return retorno;
        }
    }
}
