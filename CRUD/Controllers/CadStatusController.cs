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
    public class CadStatusController : Controller
    {
        AppStatusDispositivos appStatusDispositivos = new AppStatusDispositivos();

        [HttpGet]
        public ActionResult Index()
        {
            List<TbStatusDispositivos> retorno = appStatusDispositivos.ListarTodos();

            return View(retorno);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TbStatusDispositivos retorno = new TbStatusDispositivos();

            return View(retorno);
        }

        [HttpPost]
        public ActionResult Create(TbStatusDispositivos tbStatusDispositivos)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (appStatusDispositivos.SalvarRegistro(tbStatusDispositivos))
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

            return View(tbStatusDispositivos);
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            TbStatusDispositivos retorno = appStatusDispositivos.ListarPorId(id);   

            return View(retorno);
        }

        public ActionResult Edit(TbStatusDispositivos tbStatusDispositivos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (appStatusDispositivos.EditarRegistro(tbStatusDispositivos))
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

            return View(tbStatusDispositivos);
        }
    }
}