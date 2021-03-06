﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EmailsEncriptados.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult EnviarCorreo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarCorreo(String para, String asunto, String mensaje
            , HttpPostedFileBase fichero)
        {
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("net.curso.2014@gmail.com");
                correo.To.Add(para);
                correo.Subject = asunto;
                correo.Body = mensaje;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
               

                //String ruta = Server.MapPath("../Temporal");
                //fichero.SaveAs(ruta + "\\" + fichero.FileName);

                //Attachment adjunto = new Attachment(ruta + "\\" + fichero.FileName);
                //correo.Attachments.Add(adjunto);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = true;
                string sCuentaCorreo = "unamuno321@gmail.com";
                string sPasswordCorreo = "Comandos-4";
                smtp.Credentials = new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);

                smtp.Send(correo);
                ViewBag.Mensaje = "Mensaje enviado correctamente";
                //System.IO.File.Delete(ruta + "\\" + fichero.FileName);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

    }
}