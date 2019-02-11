﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoCore.Filters
{
    public class UsuarioAuthorizeAttribute : AuthorizeAttribute
            , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user.Identity.IsAuthenticated == false)
            {
                RouteValueDictionary rutaacceso =
                        new RouteValueDictionary(new
                        {
                            controller = "Validacion"
                            ,
                            action = "Login"
                        });
                RedirectToRouteResult actionlogin =
                    new RedirectToRouteResult(rutaacceso);
                context.Result = actionlogin;
            }
        }
    }

}
