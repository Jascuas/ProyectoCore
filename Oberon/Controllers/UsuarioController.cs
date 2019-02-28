using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oberon.Models;
using Oberon.Repositories;

namespace Oberon.Controllers
{
    public class UsuarioController : Controller
    {
        IRepositoryOberon repo;
        public UsuarioController(IRepositoryOberon repo)
        {
            this.repo = repo;
        }
        public IActionResult Perfil()
        {
            //H
            //Usuario user = HttpContext.User.Identity.;
            return View();
        }
    }
}