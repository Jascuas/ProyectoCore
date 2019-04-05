using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oberon.Models;
using Oberon.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oberon.ViewComponents
{
    public class MenuLogOutViewComponent : ViewComponent
    {
        IRepositoryAPIUsuarios repo;
        public MenuLogOutViewComponent(IRepositoryAPIUsuarios repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int? count = HttpContext.Session.GetInt32("carritoCount");
            Usuario user = await repo.GetUsuario(HttpContext.Session.GetString("token"));
            ViewBag.Count = count;
            return View(user);
        }
    }
}
