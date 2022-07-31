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
    public class CadTiposDispositivosController : Controller
    {
        AppTiposDispositivos appTiposDispositivos = new AppTiposDispositivos();

        [HttpGet]
        public ActionResult Index()
        {
            List<TbTiposDispositivos> retorno = appTiposDispositivos.ListarTodos();

            return View(retorno);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TbTiposDispositivos retorno = new TbTiposDispositivos();

            return View(retorno);
        }

        [HttpPost]
        public ActionResult Create(TbTiposDispositivos tbTiposDispositivos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (appTiposDispositivos.SalvarRegistro(tbTiposDispositivos))
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

            return View(tbTiposDispositivos);
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            TbTiposDispositivos retorno = appTiposDispositivos.ListarPorId(id);

            return View(retorno);
        }

        public ActionResult Edit(TbTiposDispositivos tbTiposDispositivos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (appTiposDispositivos.EditarRegistro(tbTiposDispositivos))
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

            return View(tbTiposDispositivos);
        }
    }
}