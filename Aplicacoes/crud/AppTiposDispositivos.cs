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
    public class AppTiposDispositivos
    {
        public List<TbTiposDispositivos> ListarTodos()
        {
            List<TbTiposDispositivos> lista = new List<TbTiposDispositivos>();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    lista = db.TiposDispositivos.ToList();
                }
            }
            catch (Exception)
            {
                lista = null;
                throw;
            }
            return lista;
        }

        public TbTiposDispositivos ListarPorId(Int64 id)
        {
            TbTiposDispositivos retorno = new TbTiposDispositivos();
            try
            {
                using (DbCrud db = new DbCrud())
                {
                    retorno = db.TiposDispositivos.Where(x => x.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                retorno = null;
                throw;
            }
            return retorno;
        }

        public bool SalvarRegistro(TbTiposDispositivos tbTiposDispositivos)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.TiposDispositivos.Add(tbTiposDispositivos);
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

        public bool EditarRegistro(TbTiposDispositivos tbTiposDispositivos)
        {
            bool retorno = false;
            using (DbCrud db = new DbCrud())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Entry(tbTiposDispositivos).State = EntityState.Modified;
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
                    List<TbTiposDispositivos> tbTiposDispositivos = db.TiposDispositivos.ToList();

                    for (int i = 0; i <= tbTiposDispositivos.Count - 1; i++)
                    {
                        ListItem item = new ListItem();
                        item.Value = tbTiposDispositivos[i].Id.ToString();
                        item.Text = tbTiposDispositivos[i].Descricao.ToUpper();
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
