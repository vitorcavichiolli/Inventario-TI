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
    public class AppTiposLicencas
    {
        public List<TbTiposLicencas> ListarTodos()
        {
            List<TbTiposLicencas> lista = new List<TbTiposLicencas>();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    lista = db.TiposLicencas.ToList();
                }
            }
            catch (Exception)
            {
                lista = null;
                throw;
            }
            return lista;
        }

        public TbTiposLicencas ListarPorId(Int64 id)
        {
            TbTiposLicencas retorno = new TbTiposLicencas();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    retorno = db.TiposLicencas.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                retorno = null;
                throw;
            }
            return retorno;
        }

        public bool SalvarRegistro(TbTiposLicencas TbTiposLicencas)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.TiposLicencas.Add(TbTiposLicencas);
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

        public bool EditarRegistro(TbTiposLicencas TbTiposLicencas)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(TbTiposLicencas).State = EntityState.Modified;
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

        public List<ListItem> DropDown()
        {
            List<ListItem> lista = new List<ListItem>();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    List<TbTiposLicencas> TbTiposLicencas = db.TiposLicencas.ToList();

                    for (int i = 0; i <= TbTiposLicencas.Count - 1; i++)
                    {
                        ListItem item = new ListItem();
                        item.Value = TbTiposLicencas[i].Id.ToString();
                        item.Text = TbTiposLicencas[i].Descricao.ToUpper();
                        lista.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                lista = null;
                throw;
            }
            return lista;
        }
    }
}
