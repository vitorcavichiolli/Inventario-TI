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
    public class CadTiposLicencasController : Controller
    {
        AppTiposLicencas AppTiposLicencas = new AppTiposLicencas();

        [HttpGet]
        public ActionResult Index()
        {
            List<TbTiposLicencas> retorno = AppTiposLicencas.ListarTodos();

            return View(retorno);
        }

        [HttpGet]
        public ActionResult Create()
        {
            TbTiposLicencas retorno = new TbTiposLicencas();

            return View(retorno);
        }

        [HttpPost]
        public ActionResult Create(TbTiposLicencas TbTiposLicencas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (AppTiposLicencas.SalvarRegistro(TbTiposLicencas))
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

            return View(TbTiposLicencas);
        }

        [HttpGet]
        public ActionResult Edit(Int64 id)
        {
            TbTiposLicencas retorno = AppTiposLicencas.ListarPorId(id);

            return View(retorno);
        }

        public ActionResult Edit(TbTiposLicencas TbTiposLicencas)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (AppTiposLicencas.EditarRegistro(TbTiposLicencas))
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

            return View(TbTiposLicencas);
        }
    }
}