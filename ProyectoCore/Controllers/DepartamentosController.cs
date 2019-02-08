using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoCore.Data;
using ProyectoCore.Models;
using ProyectoCore.Repositories;

namespace ProyectoCore.Controllers
{
    public class DepartamentosController : Controller
    {
        IRepositoryHospital repo;
        public DepartamentosController(IRepositoryHospital repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Departamento> departamentos = repo.GetDepartamentos();
            return View(departamentos);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Departamento d)
        {
            this.repo.InsertarDepartamento(d.Numero, d.Nombre, d.Localidad);
            return RedirectToAction("Index");
        }
    }
}