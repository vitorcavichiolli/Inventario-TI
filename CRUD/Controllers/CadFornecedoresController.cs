using Aplicacoes.crud;
using Dominios.crud;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class CadFornecedoresController : Controller
    {
        AppFornecedores appFornecedores = new AppFornecedores();

        [HttpGet]
        public ActionResult Index()
        {
            List<TbFornecedores> retorno = appFornecedores.ListarTodos();

            return View(retorno);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TbFornecedores retorno = new TbFornecedores();

            return View(retorno);
        }

        [HttpPost]
        public ActionResult Create(TbFornecedores tbFornecedores)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    tbFornecedores.DataCadastro = DateTime.Now;
                    if (appFornecedores.SalvarRegistro(tbFornecedores))
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

            return View(tbFornecedores);
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            TbFornecedores retorno = appFornecedores.ListarPorId(id);

            return View(retorno);
        }

        public ActionResult Edit(TbFornecedores tbFornecedores)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (appFornecedores.EditarRegistro(tbFornecedores))
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

            return View(tbFornecedores);
        }
    }
}