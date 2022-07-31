using Aplicacoes.crud;
using Dominios.crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        AppInventario appInventario = new AppInventario();
        AppUsuarios appUsuarios = new AppUsuarios();
        AppTiposDispositivos appTiposDispositivos = new AppTiposDispositivos();
        AppTiposLicencas AppTiposLicencas = new AppTiposLicencas();
        AppStatusDispositivos appStatusDispositivos = new AppStatusDispositivos();
        AppFornecedores appFornecedores = new AppFornecedores();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetChartTiposDispositivos()
        {
            List<TbInventarios> tbInventarios = appInventario.ListarTodos().Where(x => x.StatusId == 1).ToList();
            List<TbTiposDispositivos> tbTiposDispositivos = appTiposDispositivos.ListarTodos();
            List<int> quantidade_itens = new List<int>();
            List<string> tipos = new List<string>();

            for (int i = 0; i <= tbTiposDispositivos.Count - 1; i++)
            {
                var itens = tbInventarios.Where(x => x.TipoDispositivoId == tbTiposDispositivos[i].Id).ToList();
                if(itens.Count > 0)
                {
                    tipos.Add(tbTiposDispositivos[i].Descricao.ToUpper());
                    quantidade_itens.Add(itens.Count);
                }
            }

            string json = new JavaScriptSerializer().Serialize(new
            {
                Tipos = tipos,
                Quantidade = quantidade_itens,
            });

            return Json(json);
        }

        public ActionResult GetChartAtivosInativos()
        {
            List<TbInventarios> tbInventarios = appInventario.ListarTodos();
            List<int> ativos = new List<int>();
            List<int> inativos = new List<int>();

            string[] months = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames;

            for (int i = 0; i < months.Length - 1; i++)
            {
                ativos.Add(tbInventarios.Where(x => x.StatusId == 1 && x.DataCadastro.Month == i +1 && x.DataCadastro.Year == DateTime.Now.Year).ToList().Count);
                inativos.Add(tbInventarios.Where(x => x.StatusId == 2 && x.DataCadastro.Month == i +1 && x.DataCadastro.Year == DateTime.Now.Year).ToList().Count);
            }

            

            string json = new JavaScriptSerializer().Serialize(new
            {
                Ativos = ativos,
                Inativos = inativos,
            });

            return Json(json);
        }

        public ActionResult GetChartLicencas()
        {
            List<int> anos = new List<int>();
            List<int> compra = new List<int>();
            List<int> aluguel = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                anos.Add(DateTime.Now.Year - i);
            }
            List<TbInventarios> tbInventarios = appInventario.ListarTodos();


            for (int i = 0; i <= anos.Count - 1; i++)
            {
                var count_aluguel = tbInventarios.Where(x => x.DataCadastro.Year == anos[i] && x.LincencaId == 1).ToList().Count;
                var count_compra = tbInventarios.Where(x => x.DataCadastro.Year == anos[i] && x.LincencaId == 2).ToList().Count;
                aluguel.Add(count_aluguel);
                compra.Add(count_compra);
            }


            string json = new JavaScriptSerializer().Serialize(new
            {
                Aluguel = aluguel,
                Compra = compra,
                Anos = anos
            });

            return Json(json);
        }
    }
}