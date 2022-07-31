using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominios
{
    public class Entities: DbContext
    {

    }
    public class DbCrud : DbContext
    {
        public DbCrud() : base("name=DBCRUD") { }

        public DbSet<crud.TbInventarios> Inventarios { get; set; }
        public DbSet<crud.TbFornecedores> Fornecedores { get; set; }
        public DbSet<crud.TbStatusDispositivos> StatusDispositivos { get; set; }
        public DbSet<crud.TbTiposDispositivos> TiposDispositivos { get; set; }
        public DbSet<crud.TbTiposLicencas> TiposLicencas { get; set; }
        public DbSet<crud.TbUsuarios> Usuarios { get; set; }


        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo " + eve.Entry.Entity.GetType().Name + " no estado" + eve.Entry.State + " tem o seguintes erros de validação:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: " + ve.PropertyName + " Erro: " + ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch(DbUpdateException e)
            {
                foreach (var eve in e.Entries)
                {
                    Console.WriteLine("Entidade do tipo " + eve.Entity.GetType().Name + " no estado " + eve.State + "tem os seguintes erros de validação:");
                }
                throw;
            }
            catch(SqlException e)
            {
                Console.WriteLine("- Mensagem: " + e.Message + " Data: " + e.Data);
                throw;
            }
            
        }

    }

   
}
