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
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioModel usuario)
        {
            DBUsuario db = new DBUsuario();
            List<UsuarioModel> usuarioBanco = db.Usuario.Where(usu => usu.Login == usuario.Login && usu.Senha == usuario.Senha).ToList();

            if (usuarioBanco.Count > 0)
            {
                FormsAuthenticationTicket authenticationTicket = new FormsAuthenticationTicket(usuario.Login, false, 60);
                string encryptTicket = FormsAuthentication.Encrypt(authenticationTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                Response.Cookies.Add(authCookie);

                TempData["mensagem"] = " Bem vindo, " + usuarioBanco[0].Nome;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["mensagemErro"] = " Usuario ou senha invalidos! ";
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
            usuario.Data_Criacao = DateTime.Now;
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
