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
    public class AppFornecedores
    {
        public List<TbFornecedores> ListarTodos()
        {
            List<TbFornecedores> lista = new List<TbFornecedores>();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    lista = db.Fornecedores.ToList();
                }
            }
            catch (Exception)
            {
                lista = null;
                throw;
            }
            return lista;
        }

        public TbFornecedores ListarPorId(Int64 id)
        {
            TbFornecedores retorno = new TbFornecedores();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    retorno = db.Fornecedores.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                retorno = null;
                throw;
            }
            return retorno;
        }

        public bool SalvarRegistro(TbFornecedores tbFornecedores)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Fornecedores.Add(tbFornecedores);
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

        public bool EditarRegistro(TbFornecedores tbFornecedores)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(tbFornecedores).State = EntityState.Modified;
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
