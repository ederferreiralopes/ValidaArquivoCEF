using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ValidaArquivoSiteMVC.Models;

namespace ValidaArquivoSiteMVC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel usuario)
        {
            String[] login = Request.Form.GetValues("login");
            String[] senha = Request.Form.GetValues("senha");

            usuario.Login = login[0];
            usuario.Senha = senha[0];

            if (usuario.Login.Equals("eder") && usuario.Senha.Equals("lopes"))
            {
                FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(usuario.Login, false, 60);
                string encryptTicket = FormsAuthentication.Encrypt(authenticationTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                Response.Cookies.Add(authCookie);

                ViewData["mensagem"] = ", Seja bem vindo!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["mensagemErro"] = "Usuario ou senha invalidos!";
                return View("Index");
            }
            
        }

        public ActionResult Cadastro(UsuarioModel usuario)
        {
            return View("Cadastro");
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioModel usuario)
        {
            DBUsuario dbUsuario = new DBUsuario();
            dbUsuario.Usuario.Add(usuario);
            dbUsuario.SaveChanges();
            return View("Index");
        }
        public RedirectToRouteResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
 
            return RedirectToAction("Index");
        }

    }
}
