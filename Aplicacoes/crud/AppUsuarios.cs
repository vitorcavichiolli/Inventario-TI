using Dominios;
using Dominios.crud;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacoes.crud
{
    public class AppUsuarios
    {
        public List<TbUsuarios> ListarTodos()
        {
            List<TbUsuarios> lista = new List<TbUsuarios>();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    lista = db.Usuarios.ToList();
                }
            }
            catch (Exception)
            {
                lista = null;
                throw;
            }
            return lista;
        }

        public TbUsuarios ListarPorId(Int64 id)
        {
            TbUsuarios retorno = new TbUsuarios();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    retorno = db.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                retorno = null;
                throw;
            }
            return retorno;
        }

        public bool SalvarRegistro(TbUsuarios tbUsuarios)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Usuarios.Add(tbUsuarios);
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

        public bool EditarRegistro(TbUsuarios tbUsuarios)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(tbUsuarios).State = EntityState.Modified;
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
