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
    public class CadUsuariosController : Controller
    {
        AppUsuarios appUsuarios = new AppUsuarios();

        [HttpGet]
        public ActionResult Index()
        {
            List<TbUsuarios> retorno = appUsuarios.ListarTodos();

            return View(retorno);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TbUsuarios retorno = new TbUsuarios();

            return View(retorno);
        }

        [HttpPost]
        public ActionResult Create(TbUsuarios tbUsuarios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    tbUsuarios.DataCadastro = DateTime.Now;
                    if (appUsuarios.SalvarRegistro(tbUsuarios))
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

            return View(tbUsuarios);
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            TbUsuarios retorno = appUsuarios.ListarPorId(id);

            return View(retorno);
        }

        public ActionResult Edit(TbUsuarios tbUsuarios)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (appUsuarios.EditarRegistro(tbUsuarios))
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

            return View(tbUsuarios);
        }
    }
}