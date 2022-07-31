using Aplicacoes.crud;
using Dominios.crud;
using Dominios.crud.viewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class CadInventariosController : Controller
    {
        AppInventario appInventario = new AppInventario();
        AppUsuarios appUsuarios = new AppUsuarios();
        AppTiposDispositivos appTiposDispositivos = new AppTiposDispositivos(); 
        AppTiposLicencas appTiposLicencas = new AppTiposLicencas();
        AppStatusDispositivos appStatusDispositivos = new AppStatusDispositivos();
        AppFornecedores appFornecedores = new AppFornecedores();

        [HttpGet]
        public ActionResult Index()
        {
            List<TbInventarios> retorno = appInventario.ListarTodos();

            return View(retorno);
        }

        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.DDTiposLicencas = appTiposLicencas.DropDown();
            ViewBag.DDTiposDispositivos = appTiposDispositivos.DropDown();


            TbInventarios retorno = new TbInventarios();

            return View(retorno);
        }

        [HttpPost]
        public ActionResult Create(TbInventarios tbInventarios)
        {
            ViewBag.DDTiposLicencas = appTiposLicencas.DropDown();
            ViewBag.DDTiposDispositivos = appTiposDispositivos.DropDown();

            if (ModelState.IsValid)
            {
                try
                {
                    tbInventarios.DataCadastro = DateTime.Now;
                    tbInventarios.StatusId = 1; //ativo
                    if (appInventario.SalvarRegistro(tbInventarios))
                    {
                        ViewBag.Result = "ok";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Result = "ng";
                    var st = new StackTrace(ex, true);
                    var frame = st.GetFrame(0);
                    var line = frame.GetFileLineNumber();
                    ViewBag.Ex = "linha: " + line + " | " + ex.ToString();
                    
                }
            }

            return View(tbInventarios);
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            ViewBag.DDTiposLicencas = appTiposLicencas.DropDown();
            ViewBag.DDTiposDispositivos = appTiposDispositivos.DropDown();

           
            TbInventarios retorno = appInventario.ListarPorId(id);

            TbFornecedores tbFornecedores = appFornecedores.ListarPorId(retorno.FornecedorId);
            ViewBag.FornId = tbFornecedores.Id;
            ViewBag.FornNome = tbFornecedores.Nome.ToUpper();

            TbUsuarios tbUsuarios = appUsuarios.ListarPorId(retorno.Responsavel);
            ViewBag.UserId = tbUsuarios.Id;
            ViewBag.UserNome = tbUsuarios.Nome.ToUpper();

            return View(retorno);
        }

        [HttpPost]
        public ActionResult Edit(TbInventarios tbInventarios)
        {
            ViewBag.DDTiposLicencas = appTiposLicencas.DropDown();
            ViewBag.DDTiposDispositivos = appTiposDispositivos.DropDown();

            if (ModelState.IsValid)
            {
                try
                {
                    if (appInventario.EditarRegistro(tbInventarios))
                    {
                        ViewBag.Result = "ok";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Result = "ng";
                    var st = new StackTrace(ex, true);
                    var frame = st.GetFrame(0);
                    var line = frame.GetFileLineNumber();
                    ViewBag.Ex = "linha: " + line + " | " + ex.ToString();
                    
                }
            }

            return View(tbInventarios);
        }

        [HttpGet]
        public ActionResult Inactive(Int64 id)
        {
           
            TbInventarios retorno = appInventario.ListarPorId(id);


            return View(retorno);
        }

        [HttpPost]
        public ActionResult Inactive(TbInventarios tbInventarios)
        {
            tbInventarios.StatusId = 2;
            if (ModelState.IsValid)
            {
                try
                {
                    if (appInventario.EditarRegistro(tbInventarios))
                    {
                        ViewBag.Result = "ok";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Result = "ng";
                    var st = new StackTrace(ex, true);
                    var frame = st.GetFrame(0);
                    var line = frame.GetFileLineNumber();
                    ViewBag.Ex = "linha: " + line + " | " + ex.ToString();

                }
            }

            return View(tbInventarios);
        }

        [HttpGet]
        public ActionResult Delete(Int64 id)
        {

            TbInventarios retorno = appInventario.ListarPorId(id);


            return View(retorno);
        }

        [HttpPost]
        public ActionResult Delete(TbInventarios tbInventarios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (appInventario.DeletarRegistro(tbInventarios))
                    {
                        ViewBag.Result = "ok";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Result = "ng";
                    var st = new StackTrace(ex, true);
                    var frame = st.GetFrame(0);
                    var line = frame.GetFileLineNumber();
                    ViewBag.Ex = "linha: " + line + " | " + ex.ToString();

                }
            }

            return View(tbInventarios);
        }

        public JsonResult GetUsuario(string q)
        {
            List<TbUsuarios> lista = new List<TbUsuarios>();
            lista = appUsuarios.ListarTodos();

            List<MdlLista> listItems = new List<MdlLista>();
            for (int i = 0; i <= lista.Count - 1; i++)
            {
                MdlLista item = new MdlLista();
                item.id = lista[i].Id.ToString();
                item.text = lista[i].Nome.ToUpper();
                listItems.Add(item);
            }

            if (!(string.IsNullOrEmpty(q) || string.IsNullOrWhiteSpace(q)))
            {
                listItems = listItems.Where(x => x.text.ToUpper().Contains(q.ToUpper())).ToList();
            }

            return Json(new {items = listItems}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFornecedor(string q)
        {
            List<TbFornecedores> lista = new List<TbFornecedores>();
            lista = appFornecedores.ListarTodos();

            List<MdlLista> listItems = new List<MdlLista>();
            for (int i = 0; i <= lista.Count - 1; i++)
            {
                MdlLista item = new MdlLista();
                item.id = lista[i].Id.ToString();
                item.text = lista[i].Nome.ToUpper();
                listItems.Add(item);
            }

            if (!(string.IsNullOrEmpty(q) || string.IsNullOrWhiteSpace(q)))
            {
                listItems = listItems.Where(x => x.text.ToUpper().Contains(q.ToUpper())).ToList();
            }

            return Json(new { items = listItems }, JsonRequestBehavior.AllowGet);
        }
    }
}