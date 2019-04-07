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
    public class MenuPerfilViewComponent : ViewComponent
    {
        IRepositoryAPIUsuarios repo;
        public MenuPerfilViewComponent(IRepositoryAPIUsuarios repo)
        {
            this.repo = repo;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Usuario user = await repo.GetUsuario(HttpContext.Session.GetString("token"));
            return View(user);
        }
    }
}
