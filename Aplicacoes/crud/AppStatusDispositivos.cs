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
    public class AppStatusDispositivos
    {
        public List<TbStatusDispositivos> ListarTodos()
        {
            List<TbStatusDispositivos> lista = new List<TbStatusDispositivos>();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    lista = db.StatusDispositivos.ToList();
                }
            }
            catch (Exception)
            {
                lista = null;
                throw;
            }
            return lista;
        }

        public TbStatusDispositivos ListarPorId(Int64 id)
        {
            TbStatusDispositivos retorno = new TbStatusDispositivos();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    retorno = db.StatusDispositivos.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                retorno = null;
                throw;
            }
            return retorno;
        }

        public bool SalvarRegistro(TbStatusDispositivos tbStatusDispositivos)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.StatusDispositivos.Add(tbStatusDispositivos);
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

        public bool EditarRegistro(TbStatusDispositivos tbStatusDispositivos)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(tbStatusDispositivos).State = EntityState.Modified;
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
